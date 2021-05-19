namespace API.Entities
{
    public class ProductsModel
    {
       
        public int Id { get; set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }     
        public virtual Category Category { get; set; }
    }
}
