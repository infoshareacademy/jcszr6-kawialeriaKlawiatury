using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FoodTrakker.BusinessLogic.Models
{
    public class Review
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public int Rating { get; set; }
        public int AuthorID { get; set; }
        public int FoodTruckId { get; set; }
    }
}
