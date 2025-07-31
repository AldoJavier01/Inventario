using El_Almacen.Models;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Microsoft.SqlServer.Server;
using Newtonsoft.Json;
using System.Globalization;
using System.Net.Http.Headers;
using Tiendas.Domain.Aggregates;
public sealed record AgregarArticulosStockCommand(
string Name,
string Description,
string Category,
string UrlImgs,
double Price,
double Weight,
string Tallas,
string Tipos,
int IdShein,
IFormFile Imagen,
string SKU);
public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }


    #region Stock
    public async Task<long> AgregarArticulosAsync(ArticulosDto model)
    {
        using var formData = new MultipartFormDataContent();

        formData.Add(new StringContent(model.Name ?? ""), "Name");
        formData.Add(new StringContent(model.Description ?? ""), "Description");
        formData.Add(new StringContent(model.Category ?? ""), "Category");
        formData.Add(new StringContent(model.UrlImgs ?? ""), "UrlImgs");
        formData.Add(new StringContent(model.Price.ToString(CultureInfo.InvariantCulture)), "Price");
        formData.Add(new StringContent(model.Weight.ToString(CultureInfo.InvariantCulture)), "Weight");
        formData.Add(new StringContent(model.Tipos ?? ""), "Tipos");
        formData.Add(new StringContent(model.IdShein.ToString()), "IdShein");
        formData.Add(new StringContent(model.SKU ?? ""), "SKU");

        if (model.image != null && model.image.Length > 0)
        {
            var fileContent = new StreamContent(model.image.OpenReadStream());
            fileContent.Headers.ContentType = new MediaTypeHeaderValue(model.image.ContentType);
            formData.Add(fileContent, "image", model.image.FileName);
        }

        var response = await _httpClient.PostAsync("tiendas/ArticulosStock", formData);

        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<long>(result);
    }

    public async Task<ArticulosStock> ObtenerDetails (long Id)
    {
        var response = await _httpClient.GetAsync($"tiendas/ArticulosStock/Details/{Id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<ArticulosStock>(result);

    }

    public async Task<int> Delete(long Id,string Delete)
    {
        var response = await _httpClient.DeleteAsync($"{Delete}{Id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return 200 ;

    }

    public async Task<IEnumerable<ArticulosStock>> ObtenerArticulosStockAsync()
    {
        var response = await _httpClient.GetAsync("tiendas/ArticulosStock");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<ArticulosStock>>(result);
    }
    #endregion

    public async Task<IEnumerable<ArticulosVentas>> ObtenerDetailsVentas(long Id)
    {
        var response = await _httpClient.GetAsync($"tiendas/ArticulosVentas/Codigo/{Id}");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<ArticulosVentas>>(result);

    }

    

    public async Task<IEnumerable<ArticulosVentas>> ObtenerArticulosVentasAsync()
    {
        var response = await _httpClient.GetAsync("tiendas/ArticulosVentas");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<ArticulosVentas>>(result);
    }

    public async  Task<long> AgregarVentas (ArticulosVentas model)
    {
        var command = new
        {
            IdTienda = model.IdTienda,
            IdArticulo = model.IdArticulo,
            Cantidad = model.Cantidad,
            Price = model.PrecioVenta ,// Asegúrate de mapear correctamente
            Talla = model.Talla
        };

        var response = await _httpClient.PostAsJsonAsync("tiendas/ArticulosVentas", command);
        response.EnsureSuccessStatusCode();
        response.EnsureSuccessStatusCode();

        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<long>(result);
    }
}