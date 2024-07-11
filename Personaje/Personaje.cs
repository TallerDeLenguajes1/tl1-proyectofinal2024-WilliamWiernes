using System.Text.Json.Serialization;
using System.Text.Json;
using EspacioPersonajeASCII;
using EspacioPersistencia;
using EspacioConsola;
using System.Runtime.CompilerServices;

namespace EspacioPersonaje;

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
    public static Personaje CrearPersonajePrincipal(Consola ConsolaASCII)
    {
        // Datos para el Personaje Principal
        string NombrePP, SexoPP;
        Console.Clear();
        Animacion.Centrar(["Antes de comenzar"], ConsolaASCII, 0, 0);
        Animacion.Centrar(["Ingresa tu Nombre: "], ConsolaASCII, 1, 0);
        NombrePP = Console.ReadLine();

        // Puede continuar únicamente cuando ingresa el género de forma correcta
        do
        {
            Animacion.Centrar(["                                                                                                                                                   "], ConsolaASCII, 2, 0);
            Animacion.Centrar(["Y tu Sexo (F o M): "], ConsolaASCII, 2, 0);
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
    public static List<Personaje> ListPersonajes(string NombreArchivo, Consola ConsolaASCII, List<PersonajeAPI> ListPersonajesAPI)
    {
        List<Personaje> ListPersonajes = new List<Personaje>();

        if (PersonajesJson.Existe(NombreArchivo)) // Si existe y tiene datos
        {
            ListPersonajes = PersonajesJson.LeerPersonajes(NombreArchivo);
        }
        else // No existe, o existe pero no tiene datos
        {
            // Creación del Personaje Principal
            Personaje PersonajePrincipal = CrearPersonajePrincipal(ConsolaASCII);            

            ListPersonajes.Add(PersonajePrincipal); // El Personaje Principal es siempre el primero

            for (int i = 0; i < 9; i++)
            {
                Personaje PersonajeParaLista = PersonajeAleatorio(ListPersonajesAPI);
                ListPersonajes.Add(PersonajeParaLista); // El resto de personajes son aleatorios
            }

            PersonajesJson.GuardarPersonajes(ListPersonajes, NombreArchivo);
        }

        return ListPersonajes;
    }
}

// Función para mostrar lista de personajes, destacando sus datos y características
public class MostrarPersonajes
{
    public static void Mostrar(List<Personaje> ListPersonajes, Consola ConsolaASCII)
    {
        Console.Clear();
        Animacion.Centrar(ASCII.Participantes, ConsolaASCII, 0, 0);

        int Y = 16;

        foreach (Personaje Personaje in ListPersonajes)
        {
            // Dibujo ASCII por encima de los Datos del Personaje
            if (Personaje.Descripcion.Sexo == "Femenino")
            {
                Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, Y, 0);
            }
            else
            {
                Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, Y, 0);
            }
            Animacion.Centrar([$"Nombre: {Personaje.Descripcion.Nombre}", $"Sexo: {Personaje.Descripcion.Sexo}", $"Ataque: {Personaje.Habilidades.Ataque}", $"Bloqueo: {Personaje.Habilidades.Bloqueo}", $"Salud: {Personaje.Habilidades.Salud}"], ConsolaASCII, Y + 21, 0);
            Y += 25;
        }

        Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, Y + 2, 1);
        Animacion.EvitarTeclas();
        Console.ReadKey();
    }
}