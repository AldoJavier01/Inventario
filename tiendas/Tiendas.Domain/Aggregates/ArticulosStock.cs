namespace Tiendas.Domain.Aggregates
{
    public class ArticulosStock
    {
        private readonly int _id;
        public int Id => _id;

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Category { get; private set; }

        public string UrlImgs { get; private set; }

        public double Price { get; private set; }

        public double Weight { get; private set; }

        public string Tallas { get; private set; }

        public string Tipos { get; private set; }

        public int IdShein { get; private set; }

        public string SKU { get; private set; }

        public byte[] Image { get; private set; }
        public ArticulosStock(string name,
                              string description,
                              string category,
                              string urlImgs,
                              double price,
                              double weight,
                              string tallas,
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
            Tallas = tallas;
            Tipos = tipos;
            IdShein = idShein;
            SKU = sKU;
            Image = image;
        }
    }
}
