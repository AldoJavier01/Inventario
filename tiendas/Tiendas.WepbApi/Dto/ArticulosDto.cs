namespace Tiendas.WepbApi.Dto
{ 
    public class ArticulosDto
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string Category { get; set; }

        public string UrlImgs { get; set; }

        public double Price { get; set; }

        public double Weight { get; set; }

       

        public string Tipos { get; set; }

        public int IdShein { get; set; }

        public string SKU { get; set; }
        public IFormFile image {  get; set; }




        public ArticulosDto() { }

       
    }
}
