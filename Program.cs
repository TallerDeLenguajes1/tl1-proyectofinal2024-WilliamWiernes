using EspacioConsola;
using EspacioPersonajeASCII;
using EspacioMenu;
using System.Drawing;
using System.Media;
using EspacioPersonaje;

// Configuración de Consola antes de comenzar
List<PersonajeAPI> ListPersonajesAPI = await PersonajeAPI.GetPersonajesAsync(); // Genero la lista de Personajes API al comienzo del Programa
if (ListPersonajesAPI == null) // Si hay algún error con la API corto la ejecución del Programa
    Environment.Exit(0);

Consola ConsolaASCII = new Consola(170, 60, new Point(5, 3), new Point(165, 55)); // Ancho, Altura, Límites Superior e Inferior
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
string NombreArchivoJugar = "Personajes.json";
string NombreArchivoGanadores = "HistorialGanadores.json";

while (true)
{
    Seleccion = Menu.Opciones(ConsolaASCII); // 1. Jugar, 2. Ver Ganadores, 3. Salir
    switch (Seleccion)
    {
        case "1":
        case "i":
        case "I":
            Menu.Opcion1(NombreArchivoJugar, ConsolaASCII, ListPersonajesAPI);
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