using Microsoft.EntityFrameworkCore;

namespace FoodTrakker_WebBusinessLogic.Model
{
    [Keyless]
    public class User : Iindexable
    {
        public int Id { get; set; } 
        public string Login { get;set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public List<int> FavouriteFoodTrucksID { get; set; }
        public List<int> ReviewsID { get; set; }
        //public override string ToString()
        //{
        //    return $" User: {Id},{Login},{Name},{FavouriteFoodTrucksID},{Reviews}";
        //}
        public void UpdateIndex(int i)
        {
            Id = i;
        }
        
    }
}
