using System.Text.Json.Serialization;
using System.Text.Json;

namespace EspacioHechizo;

public class HechizoAPI
{
    [JsonPropertyName("id")]
    public string id { get; set; }

    [JsonPropertyName("name")]
    public string name { get; set; }

    [JsonPropertyName("description")]
    public string description { get; set; }

    public static async Task<List<HechizoAPI>> GetHechizoAsync()
    {
        var Url = "https://hp-api.onrender.com/api/spells";

        try
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage Response = await Client.GetAsync(Url);
            Response.EnsureSuccessStatusCode();

            string ResponseBody = await Response.Content.ReadAsStringAsync();
            List<HechizoAPI> ListHechizosAPI = JsonSerializer.Deserialize<List<HechizoAPI>>(ResponseBody);
            return ListHechizosAPI;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Problemas de acceso a la API");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }

    // Función que devuelve un Hechizo aleatorio
    public static HechizoAPI HechizoAleatorio(List<HechizoAPI> ListHechizosAPI)
    {
        HechizoAPI HechizoAleAPI = new HechizoAPI();
        if (ListHechizosAPI != null)
        {
            Random Aleatorio = new Random();
            int IndexAle = Aleatorio.Next(0, ListHechizosAPI.Count);
            HechizoAleAPI = ListHechizosAPI[IndexAle];
        }
        else
        {
            HechizoAleAPI.name = "un Ataque";
        }

        return HechizoAleAPI;
    }
}

