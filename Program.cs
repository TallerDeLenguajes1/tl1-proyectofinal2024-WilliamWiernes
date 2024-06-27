using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioGameplay;
using System.Drawing;

// Configuración de Consola antes de comenzar
Consola ConsolaASCII = new Consola(170, 60, new Point(5, 3), new Point(165, 55)); // Ancho, Altura, Límites Superior e Inferior
ConsolaASCII.ConfiguracionIncial();

// Introducción
Animacion.Dibujar(Animacion.TituloInicio, 0);
Consola.Continuar(); // Presiona para continuar...
Console.Clear();

// Implementación del juego, Lista de Personajes
string NombreArchivo = "Personajes.json";
List<Personaje> ListPersonajes = await FabricaDePersonajes.ListPersonajes(NombreArchivo); // Lista Principal de Personajes

if (ListPersonajes == null) // Si hay un problema con ListPersonajes, corto la ejecución del programa
    return;

Consola.Continuar();
Console.Clear();

/* Animacion.Dibujar(Animacion.HarryPotter, 1);
Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo);// El Personaje Principal es el Primero de la lista
Console.SetCursorPosition(45, 24);
Consola.Continuar();
Console.Clear(); */

// Mostrar por pantalla los Personajes
MostrarPersonajes.Mostrar(ListPersonajes);
Consola.Continuar();
Console.Clear();

// Gameplay
ConsolaASCII.DibujarMarco();

PersonajeASCII PersonajePrincipalASCII = new PersonajeASCII(new Point(20, 45), ConsolaASCII, ListPersonajes[0]);
PersonajePrincipalASCII.MostrarNombre(PersonajePrincipalASCII.Posicion); // Mostrar Nombre del Personaje Principal

// Lista de los Personajes Secundarios y Dibujado de los mismos
List<PersonajeASCII> ListPersonajesSecundariosASCII = PersonajePrincipalASCII.ListPersonajesSecundariosASCII(ListPersonajes, ConsolaASCII);

bool Jugar = true;

while (Jugar)
{
    PersonajePrincipalASCII.Mover(1, ListPersonajesSecundariosASCII, PersonajePrincipalASCII, ConsolaASCII);
    foreach (PersonajeASCII PersonajeSecundarioASCII in ListPersonajesSecundariosASCII)
    {
        if (ListPersonajesSecundariosASCII != null)
        {
            PersonajeSecundarioASCII.MostrarNombre(PersonajeSecundarioASCII.Posicion);
            PersonajeSecundarioASCII.Dibujar();
        }
        else
        {
            Jugar = false;
            return;
        }
    }
}