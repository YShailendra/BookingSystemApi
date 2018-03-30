using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookingSystemApi.Models
{
    public class BaseModel
    {
        public Guid ID { get; set;}
        public DateTime CreatedDate {get; set;}
        [JsonIgnore]
        public DateTime? UpdatedDate {get; set;}
        [JsonIgnore]
        public Guid? CreatedBy {get; set;}
        [JsonIgnore]
        public Guid? UpdatedBy {get; set;}
    }
}