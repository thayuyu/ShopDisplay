namespace ServerShopDisplay.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string PictureLink { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }

        public Item() { }
    }
}
