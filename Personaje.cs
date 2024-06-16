using System.Text.Json.Serialization;
using System.Text.Json;

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

public class Datos
{
    private string nombre;
    private string genero; // female o male por tema de la API

    public string Nombre { get => nombre; set => nombre = value; }
    public string Genero { get => genero; set => genero = value; }
}

public class Caracteristicas
{
    private int ataque; // 1 a 5
    private int bloqueo; // 1 a 5
    private int salud; // 100

    public int Ataque { get => ataque; set => ataque = value; }
    public int Bloqueo { get => bloqueo; set => bloqueo = value; }
    public int Salud { get => salud; set => salud = value; }
}

public class Personaje(Datos Descripcion, Caracteristicas Habilidades)
{
    private Datos descripcion = Descripcion;
    private Caracteristicas habilidades = Habilidades;

    public Datos Descripcion { get => descripcion; set => descripcion = value; }
    public Caracteristicas Habilidades { get => habilidades; set => habilidades = value; }
}

public class FabricaDePersonajes
{
    // Función para desearilizar el json de la url
    public static async Task<List<PersonajeAPI>> GetPersonajesAsync()
    {
        var url = "https://hp-api.onrender.com/api/characters/students";

        try
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            response.EnsureSuccessStatusCode();

            string responseBody = await response.Content.ReadAsStringAsync();
            List<PersonajeAPI> listPersonajesAPI = JsonSerializer.Deserialize<List<PersonajeAPI>>(responseBody);
            return listPersonajesAPI;
        }
        catch (HttpRequestException e)
        {
            Console.WriteLine("Problemas de acceso a la API");
            Console.WriteLine("Message :{0} ", e.Message);
            return null;
        }
    }

    public static Personaje PersonajeAleatorio(List<PersonajeAPI> listPersonajesAPI)
    {
        var Aleatorio = new Random();
        int IndexAle = Aleatorio.Next(0, listPersonajesAPI.Count);

        PersonajeAPI PersonajeAleAPI = listPersonajesAPI[IndexAle];

        // Nombre y Género vienen desde la API
        Datos Descripcion = new Datos
        {
            Nombre = PersonajeAleAPI.Name,
            Genero = PersonajeAleAPI.Gender
        };

        // Ataque y Bloque son aleatorios, la salud es de 100
        int AtaqueAle = Aleatorio.Next(1, 6); // 1 a 5
        int BloqueoAle = Aleatorio.Next(1, 6);

        Caracteristicas Habilidades = new Caracteristicas
        {
            Ataque = AtaqueAle,
            Bloqueo = BloqueoAle,
            Salud = 100
        };

        Personaje PersonajeAle = new Personaje(Descripcion, Habilidades);

        return PersonajeAle;
    }
}