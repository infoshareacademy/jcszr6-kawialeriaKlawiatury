﻿using System.ComponentModel.DataAnnotations;

namespace FoodTrakker.BusinessLogic.Models
{
    public class FoodTruck : Iindexable
    {
        public int Id { get; set; }
        [MinLength(3)]
        [MaxLength(100)]
        public string Name { get; set; }
        [MinLength(150)]
        [MaxLength(1000)]
        public string Description { get; set; }
        public Location Location { get; set; }
        public FoodTruckType Type { get; set; }
        public int OwnerId { get; set; }

        public void UpdateIndex(int i)
        {
            Id = i;
        }
        public override string ToString()
        {
            return $" FoodTruck: Name: {Name},Description: {Description},Location: {Location},Type: {Type}";
        }
    }
}
