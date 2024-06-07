using ServerShopDisplay.Model;

namespace ServerShopDisplay.Services
{
    public class DataService
    {
        public List<Item> Basket {  get; set; }

        public DataService() 
        { 
            Basket = new List<Item>();
        }
    }
}
