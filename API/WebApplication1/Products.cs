namespace WebApplication1
{
    public class Products
    {
        public string name { get; set; }

        public string description { get; set; }

        public string category { get; set; }

        public double price { get; set; }   

        public Products(string name,string category,string description, double price) { 
            this.name = name;
            this.category = category;
            this.description = description;
            this.price = price;
        }

    
    }
}