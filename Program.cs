using EspacioConsola;
using EspacioPersonajeASCII;
using EspacioMenu;
using System.Drawing;
using System.Media;

// Configuración de Consola antes de comenzar
Consola ConsolaASCII = new Consola(170, 60, new Point(5, 3), new Point(165, 55)); // Ancho, Altura, Límites Superior e Inferior
ConsolaASCII.ConfiguracionIncial();

// Música loopeada
SoundPlayer Cancion = new SoundPlayer(@"Musica\HedwigsTheme.wav");
Cancion.PlayLooping();

// Introducción
Animacion.Dibujar(ASCII.TituloInicio, 0);
Consola.Continuar(); // Presiona para continuar...
Console.Clear();

// Menú de Opciones
int Seleccion;
string NombreArchivoJugar = "Personajes.json";
string NombreArchivoGanadores = "HistorialGanadores.json";

while (true)
{
    Seleccion = Menu.Opciones(); // 1. Jugar, 2. Ver Ganadores, 3. Salir

    switch (Seleccion)
    {
        case 1:
            Menu.Opcion1(ConsolaASCII, NombreArchivoJugar);
            break;
        case 2:
            Menu.Opcion2(NombreArchivoGanadores);
            break;
        case 3:
            Menu.Opcion3();
            break;
    }
}