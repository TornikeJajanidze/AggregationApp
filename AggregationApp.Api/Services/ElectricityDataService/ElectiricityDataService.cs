using AggregationApp.Api.Configuratrions;
using AggregationApp.Api.Mapping;
using AggregationApp.Application.Database;
using AggregationApp.Application.Models;
using CsvHelper;
using CsvHelper.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;
using System.IO;

namespace AggregationApp.Api.Services.ElectricityDataService
{
    public class ElectiricityDataService : IElectricityDataService
    {
        private readonly AppSettings _settings;
        private readonly HttpClient _httpClient;
        private readonly AggregationDbContext _dbcontext;
        public ElectiricityDataService(HttpClient httpClient, AggregationDbContext dbcontext,
            IOptions<AppSettings> options)
        {
            _settings = options.Value;
            _httpClient = httpClient;
            _dbcontext = dbcontext;
        }
        public async Task ProcessElectricityDataAsync()
        {
            await ClearAllRecordsAsync();
            var data = await DownloadElectricityDataAsync();
            var filteredData = FilterApartmentData(data);
            var aggregatedData = AggregateDataByRegion(filteredData);
            await SaveAggregatedDataAsync(aggregatedData);
        }
        private async Task SaveAggregatedDataAsync(List<AggregatedData> aggregatedData)
        {
            await _dbcontext.AggregatedData.AddRangeAsync(aggregatedData);
            await _dbcontext.SaveChangesAsync();
        }
        private async Task<List<ElectricityData>> DownloadElectricityDataAsync()
        {
            var data = new List<ElectricityData>();
     
            foreach (var url in _settings.ElectricityDataUrls)
            {
                var streamData = await _httpClient.GetStreamAsync(url);
                  var parsedData = ParseCsvData(streamData);
                data.AddRange(parsedData);
            }
            return data;
        }
        private static List<ElectricityData> ParseCsvData(Stream streamData)
        {
            using (var reader = new StreamReader(streamData))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                csv.Context.RegisterClassMap<ElectricityDataMap>();
                var records = csv.GetRecords<ElectricityData>().ToList();
                return records;
            }
        }
        private static List<ElectricityData> FilterApartmentData(List<ElectricityData> data)
        {
            return data.Where(d => d.ObjectName == "Butas").ToList();
        }
        private static List<AggregatedData> AggregateDataByRegion(List<ElectricityData> data)
        {
            var aggregatedData = data.GroupBy(d => d.Region)
                                     .Select(g => new AggregatedData
                                     {
                                         Region = g.Key,
                                         PPlus = g.Sum(d => d.PPlus),
                                         PMinus = g.Sum(d => d.PMinus)
                                     })
                                     .ToList();
            return aggregatedData;
        }
        private async Task ClearAllRecordsAsync()
        {
            _dbcontext.AggregatedData.RemoveRange(_dbcontext.AggregatedData);
            await _dbcontext.SaveChangesAsync();
        }
    }
}
