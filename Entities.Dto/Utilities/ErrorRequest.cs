using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace Entities.Dto.Utilities
{
    public class ErrorRequest
    {
        public int StatusCode { get; set; }
        public string Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
