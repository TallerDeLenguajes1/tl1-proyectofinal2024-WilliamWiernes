using EspacioConsola;
using EspacioPersonajeASCII;
using EspacioMenu;
using System.Drawing;
using System.Media;
using EspacioPersonaje;
using EspacioPersistencia;
using EspacioHechizo;
using System.ComponentModel.DataAnnotations;

// Genero la lista de Personajes API al comienzo del Programa
List<PersonajeAPI> ListPersonajesAPI = await PersonajeAPI.GetPersonajesAsync();
string NombreArchivoJugar = "Personajes.json";
if (ListPersonajesAPI == null) // Si hay algún error con la API y NO existe Json de Personajes corto la ejecución del Programa
    if (!PersonajesJson.Existe(NombreArchivoJugar))
    {
        Console.WriteLine("Error en la API y Json de Personajes.");
        Environment.Exit(0);
    }

// Genero la lista de Hechizos API
List<HechizoAPI> ListHechizosAPI = await HechizoAPI.GetHechizoAsync();

// Configuración de Consola antes de comenzar
int Ancho = 135; // 135 por defecto, no menos de 135 - no más de 150 (depende del monitor)
int Altura = 60; // 60 por defecto, no menos de 30 - no más de 60 (depende del monitor) 
Consola ConsolaASCII = new Consola(Ancho, Altura, new Point(5, 3), new Point(Ancho - 5, Altura - 5)); // Ancho, Altura, Límites Superior e Inferior
ConsolaASCII.ConfiguracionIncial();

// Música loopeada
SoundPlayer Cancion = new SoundPlayer(@"Musica\HedwigsTheme.wav");
Cancion.PlayLooping();

// Background
Animacion.Centrar(ASCII.Fondo, ConsolaASCII, 0, 0);

// Introducción
Animacion.Centrar(ASCII.TituloInicio, ConsolaASCII, 15, 0);
Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 30, 3);
Animacion.EvitarTeclas();
Console.ReadKey();

// Menú de Opciones
string Seleccion;
string NombreArchivoGanadores = "HistorialGanadores.json";

while (true)
{
    Seleccion = Menu.Opciones(ConsolaASCII); // 1. Jugar, 2. Ver Ganadores, 3. Salir
    switch (Seleccion)
    {
        case "1":
        case "i":
        case "I":
            Menu.Opcion1(NombreArchivoJugar, ConsolaASCII, ListPersonajesAPI, ListHechizosAPI);
            break;
        case "2":
        case "ii":
        case "II":
            Menu.Opcion2(NombreArchivoGanadores, ConsolaASCII);
            break;
        case "3":
        case "iii":
        case "III":
            Menu.Opcion3(ConsolaASCII);
            break;
    }
}