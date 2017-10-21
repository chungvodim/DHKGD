using System;
using System.Collections.Generic;
using System.Text;
using Tearc.Entity.Enum;

namespace Tearc.Entity.Mongo
{
    public class Advert : BaseEntity
    {
        public long AdvertID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public AdvertType AdvertType { get; set; }
        public Currency Currency { get; set; }
        public decimal Price { get; set; }
        public DeliverType DeliverType { get; set; }
        public List<KeyValuePair<string, string>> Features { get; set; }
        public string[] ImageUrls { get; set; }
        public string[] VideoUrls { get; set; }
    }
}
