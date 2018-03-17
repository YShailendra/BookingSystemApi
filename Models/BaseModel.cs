using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    public class BaseModel
    {
        public Guid ID { get; set;}
        public DateTime CreatedDate {get; set;}
        public DateTime? UpdatedDate {get; set;}
        public Guid? CreatedBy {get; set;}
        public Guid? UpdatedBy {get; set;}
    }
}