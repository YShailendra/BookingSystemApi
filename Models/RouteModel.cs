using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace BookingSystemApi.Models
{
    public class RouteModel
    {   
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string RouteName { get; set; }
    }
    public class StationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }
        public string StationName { get; set; }
        
    }
    public class RouteStationModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID {get; set;}
        public int RouteID { get; set; }
        public int StationID { get; set; }
        public int Sequence {get; set;}

        [ForeignKey("StationID")]
        public StationModel StationModel { get; set; }

        [ForeignKey("RouteID")]
        public RouteModel RouteModel { get; set; }
        public int Price { get; set; }
    }
    public class BusRouteModel
    {

        public int ID {get; set;}
        public int RouteID { get; set; }
        public Guid BusID { get; set; }
        
        [ForeignKey("RouteID")]
        public RouteModel RouteModel { get; set; } 

        [ForeignKey("BusID")]
        public BusDetailModel BusDetail { get; set; } 
    }
    
}