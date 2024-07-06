using System.Text.Json.Serialization;
using System.Text.Json;
using EspacioPersonajeASCII;
using EspacioPersistencia;
using EspacioConsola;

namespace EspacioPersonaje;

public class PersonajeAPI
{
    [JsonPropertyName("id")]
    public string Id { get; set; }

    [JsonPropertyName("name")]
    public string Name { get; set; }

    [JsonPropertyName("alternate_names")]
    public List<string> AlternateNames { get; set; }

    [JsonPropertyName("species")]
    public string Species { get; set; }

    [JsonPropertyName("gender")]
    public string Gender { get; set; }

    [JsonPropertyName("house")]
    public string House { get; set; }

    [JsonPropertyName("dateOfBirth")]
    public string DateOfBirth { get; set; }

    [JsonPropertyName("yearOfBirth")]
    public int? YearOfBirth { get; set; }

    [JsonPropertyName("wizard")]
    public bool Wizard { get; set; }

    [JsonPropertyName("ancestry")]
    public string Ancestry { get; set; }

    [JsonPropertyName("eyeColour")]
    public string EyeColour { get; set; }

    [JsonPropertyName("hairColour")]
    public string HairColour { get; set; }

    [JsonPropertyName("wand")]
    public Wand Wand { get; set; }

    [JsonPropertyName("patronus")]
    public string Patronus { get; set; }

    [JsonPropertyName("hogwartsStudent")]
    public bool HogwartsStudent { get; set; }

    [JsonPropertyName("hogwartsStaff")]
    public bool HogwartsStaff { get; set; }

    [JsonPropertyName("actor")]
    public string Actor { get; set; }

    [JsonPropertyName("alternate_actors")]
    public List<string> AlternateActors { get; set; }

    [JsonPropertyName("alive")]
    public bool Alive { get; set; }

    [JsonPropertyName("image")]
    public string Image { get; set; }

    // Función para desearilizar el json de la url
    public static async Task<List<PersonajeAPI>> GetPersonajesAsync()
    {
        var Url = "https://hp-api.onrender.com/api/characters/students";

        try
        {
            HttpClient Client = new HttpClient();
            HttpResponseMessage Response = await Client.GetAsync(Url);
            Response.EnsureSuccessStatusCode();

            string ResponseBody = await Response.Content.ReadAsStringAsync();
            List<PersonajeAPI> ListPersonajesAPI = JsonSerializer.Deserialize<List<PersonajeAPI>>(ResponseBody);
            return ListPersonajesAPI;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Problemas de acceso a la API");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }
}

public class Wand
{
    [JsonPropertyName("wood")]
    public string Wood { get; set; }

    [JsonPropertyName("core")]
    public string Core { get; set; }

    [JsonPropertyName("length")]
    public double? Length { get; set; }
}

