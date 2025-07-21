using El_Almacen.Models;
using Newtonsoft.Json;
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
string SKU);
public class ApiService
{
    private readonly HttpClient _httpClient;

    public ApiService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
   
    public async Task<int> GetObjetosAsync()
    {
        var response = await _httpClient.GetAsync("api/objetos");
        response.EnsureSuccessStatusCode();
        var content = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<int>(content);
    }

    public async Task<long> GolpearApiAsync(AgregarArticulosStockCommand command)
    {
        var response = await _httpClient.PostAsJsonAsync("tiendas/ArticulosStock", command);
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<long>(result);
    }
    public async Task<IEnumerable<ArticulosStock>> ObtenerArticulosStockAsync()
    {
        var response = await _httpClient.GetAsync("tiendas/ArticulosStock");
        response.EnsureSuccessStatusCode();
        var result = await response.Content.ReadAsStringAsync();
        return JsonConvert.DeserializeObject<IEnumerable<ArticulosStock>>(result);
    }
}