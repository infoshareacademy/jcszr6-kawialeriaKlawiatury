﻿using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class Review : Iindexable
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int AuthorID { get; set; }
        public int FoodTruckId { get; set; }
        public void UpdateIndex(int i)
        {
            Id = i;
        }

        public override string ToString()
        {
            return $"Review: Id:{Id} Title:{Title} ({Date.ToString("dd/MM/yyyy", CultureInfo.InvariantCulture)}),\nDescription: {Description},\nRate: {Rating},\nAuthor: {AuthorID},Food Truck Id: {FoodTruckId}";
        }

    }
}
