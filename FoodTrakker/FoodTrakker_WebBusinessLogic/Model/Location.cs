using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;


namespace FoodTrakker.Core.Model
{
    public class Location : Iindexable<int>
    {
        public int Id { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        [DefaultValue(123456)]
        public int ZIPCode { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }

}
