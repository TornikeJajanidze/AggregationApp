﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.AspNetCore.Mvc.Filters;
using System.Net;

namespace AggregationApp.Api
{
    public class GlobalExceptionFilter:IExceptionFilter
    {
        private readonly IHostEnvironment hostEnvironment;
        public GlobalExceptionFilter(IHostEnvironment hostEnvironment)
        {
            this.hostEnvironment = hostEnvironment;
        }
        public void OnException(ExceptionContext context)
        {
            string errorMessage = GetErrorMessage(context);
            var payload = new ObjectResult(errorMessage);
            context.Result = new ObjectResult(payload) { StatusCode = (int) HttpStatusCode.InternalServerError };
        }
        private string GetErrorMessage(ExceptionContext context)
        {
            if(hostEnvironment.IsDevelopment())
            {
                return context.Exception.Message;
            }
            return "Unknown error has occured";
        }
    }
}
