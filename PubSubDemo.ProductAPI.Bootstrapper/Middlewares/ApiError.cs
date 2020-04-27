using System;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.IO;
using System.Net;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Linq;

namespace PubSubDemo.ProductAPI.Bootstrapper
{
    public class ApiError
    {
        public bool IsError { get; set; }
        public string ExceptionMessage { get; set; }
        public string Details { get; set; }
        public string ReferenceErrorCode { get; set; }
        public string ReferenceDocumentLink { get; set; }
        public IEnumerable<ValidationError> ValidationErrors { get; set; }

        public ApiError(string message)
        {
            this.ExceptionMessage = message;
            this.IsError = true;
        }

        public ApiError(ModelStateDictionary modelState)
        {
            this.IsError = true;
            if (modelState != null && modelState.Any(m => m.Value.Errors.Count > 0))
            {
                this.ExceptionMessage = "Please correct the specified validation errors and try again.";
                this.ValidationErrors = modelState.Keys
                .SelectMany(key => modelState[key].Errors.Select(x => new ValidationError(key, x.ErrorMessage)))
                .ToList();

            }
        }
    }
}
