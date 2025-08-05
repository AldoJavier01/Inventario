namespace Tiendas.Domain.Aggregates
{
    public class ArticulosStock
    {
         readonly int _id;
        public int Id => _id;

        public string Name { get;  set; }

        public string Description { get;  set; }

        public string Category { get;  set; }

        public string UrlImgs { get;  set; }

        public double Price { get;  set; }

        public double Weight { get;  set; }

        public double PrecioDeCompra { get;  set; }
        public string Tipos { get;  set; }

        public int IdShein { get;  set; }

        public string SKU { get;  set; }

        public byte[] Image { get;  set; }
        public ArticulosStock(string name,
                              string description,
                              string category,
                              string urlImgs,
                              double price,
                              double weight,
                             
                              string tipos,
                              int idShein,
                              string sKU,
                              byte[] image)
        {
            Name = name;
            Description = description;
            Category = category;
            UrlImgs = urlImgs;
            Price = price;
            Weight = weight;
           
            Tipos = tipos;
            IdShein = idShein;
            SKU = sKU;
            Image = image;
        }
    }
}
