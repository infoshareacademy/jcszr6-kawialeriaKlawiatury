using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodTrakker.BusinessLogic.Repository;

namespace FoodTrakker.BusinessLogic.Models
{
    public class Review : Iindexable
    {

        public int Id { get; internal set; }
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
    }
}
