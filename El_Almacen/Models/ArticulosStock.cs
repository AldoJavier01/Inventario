namespace El_Almacen.Models
{
    public class ArticulosStock
    {
        public long Id { get; set; }

        public string Name { get; private set; }

        public string Description { get; private set; }

        public string Category { get; private set; }

        public string UrlImgs { get; private set; }

        public double Price { get; private set; }

        public double Weight { get; private set; }

        public double PrecioDeCompra { get; private set; }
        public string Tipos { get; private set; }

        public int IdShein { get; private set; }

        public string SKU { get; private set; }

        public byte[] Image { get; private set; }
        public ArticulosStock(long id,
                              string name,
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
            Id = id;
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
