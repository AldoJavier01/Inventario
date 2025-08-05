namespace El_Almacen.Dto
{
    public class AgregarVentasDto
    {
        public long IdTienda { get; set; }
        public long IdArticulo { get; set; }
        public List<tallasDto> Tallas { get; set; } = new();
        public double PrecioVenta { get; set; }
    }

    public class tallasDto
    {
        public long Cantidad { get; set; }
        public string Talla { get; set; }
    }

}
