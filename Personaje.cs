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
    private string sexo; // female o male por tema de la API

    public string Nombre { get => nombre; set => nombre = value; }
    public string Sexo { get => sexo; set => sexo = value; }
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
    // Función para crear al Personaje Principal
    public static Personaje CrearPersonajePrincipal()
    {
        // Datos para el Personaje Principal
        string NombrePP, SexoPP;
        Console.WriteLine("Antes de comenzar");
        Console.Write("Ingresa tu Nombre: ");
        NombrePP = Console.ReadLine();

        // Puede continuar únicamente cuando ingresa el género de forma correcta
        do
        {
            Console.Write("Y tu Sexo (F o M): ");
            SexoPP = Console.ReadLine();
        } while (SexoPP != "F" && SexoPP != "M" && SexoPP != "f" && SexoPP != "m");

        // Creo el personaje pricipal a mano, el resto de forma aleatoria
        SexoPP = (SexoPP == "F" || SexoPP == "f") ? "Femenino" : "Masculino";

        Datos Descripcion = new Datos
        {
            Nombre = NombrePP,
            Sexo = SexoPP
        };

        var Aleatorio = new Random();
        int AtaqueAle = Aleatorio.Next(1, 5);
        int BloqueoAle = Aleatorio.Next(1, 5);

        Caracteristicas Habilidades = new Caracteristicas
        {
            Ataque = AtaqueAle,
            Bloqueo = BloqueoAle,
            Salud = 100
        };

        Personaje PersonajePrincipal = new Personaje(Descripcion, Habilidades);

        return PersonajePrincipal;
    }

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

    // Función para generar un personaje aleatorio
    public static Personaje PersonajeAleatorio(List<PersonajeAPI> ListPersonajesAPI)
    {
        Random Aleatorio = new Random();
        int IndexAle = Aleatorio.Next(0, ListPersonajesAPI.Count + 1);

        PersonajeAPI PersonajeAleAPI = ListPersonajesAPI[IndexAle];

        // Nombre y Género que vienen desde la API
        string SexoAle = (PersonajeAleAPI.Gender == "female") ? "Femenino" : "Masculino";
        Datos Descripcion = new Datos
        {
            Nombre = PersonajeAleAPI.Name,
            Sexo = SexoAle
        };

        // Ataque y Bloqueo son aleatorios, la salud es de 100
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

    // Función para devolver ListPersonajes en base a si existe o no un Archivo Json
    public async static Task<List<Personaje>> ListPersonajes(string NombreArchivo)
    {
        List<Personaje> ListPersonajes = new List<Personaje>();

        if (PersonajesJson.Existe(NombreArchivo)) // Si existe y tiene datos
        {
            ListPersonajes = PersonajesJson.LeerPersonajes(NombreArchivo);
            Console.WriteLine("Lista de Personajes Creada desde Json");
        }
        else // No existe, o existe pero no tiene datos
        {
            // Creación del Personaje Principal
            Personaje PersonajePrincipal = CrearPersonajePrincipal();

            // Lista Personajes API
            List<PersonajeAPI> ListPersonajesAPI = await GetPersonajesAsync();

            if (ListPersonajesAPI == null) // Si hay algún error con la API, corto la ejecución de la función
            {
                return null;
            }

            ListPersonajes.Add(PersonajePrincipal); // El Personaje Principal es siempre el primero

            for (int i = 0; i < 9; i++)
            {
                Personaje PersonajeParaLista = PersonajeAleatorio(ListPersonajesAPI);
                ListPersonajes.Add(PersonajeParaLista); // El resto de personajes son aleatorios
            }

            PersonajesJson.GuardarPersonajes(ListPersonajes, NombreArchivo);

            Console.WriteLine("Lista y Json de Personajes Creada desde API");
        }

        return ListPersonajes;
    }
}

public class MostrarPersonajes
{
    public static void Mostrar(List<Personaje> ListPersonajes)
    {
        Console.Clear();
        Console.WriteLine("Participantes del Torneo:");

        foreach (Personaje Personaje in ListPersonajes)
        {
            // Dibujo ASCII por encima de los Datos del Personaje
            if (Personaje.Descripcion.Sexo == "Femenino")
            {
                Animacion.Dibujar(Animacion.PersonajeFemenino, 0);
            }
            else
            {
                Animacion.Dibujar(Animacion.PersonajeMasculino, 0);
            }

            Console.WriteLine($"Nombre: {Personaje.Descripcion.Nombre}\nSexo: {Personaje.Descripcion.Sexo}\nAtaque: {Personaje.Habilidades.Ataque}\nBloqueo: {Personaje.Habilidades.Bloqueo}\nSalud: {Personaje.Habilidades.Salud}");
        }
    }
}