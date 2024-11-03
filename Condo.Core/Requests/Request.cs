using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Condo.Core.Requests
{
    public abstract class Request
    {
        [JsonIgnore]
        public string UserId { get; set; } = string.Empty;
    }
}
