﻿using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioGameplay;
using System.Drawing;
using EspacioPersistencia;

// Configuración de Consola antes de comenzar
Consola ConsolaASCII = new Consola(170, 60, new Point(5, 3), new Point(165, 55)); // Ancho, Altura, Límites Superior e Inferior
ConsolaASCII.ConfiguracionIncial();

// Introducción
Animacion.Dibujar(ASCII.TituloInicio, 0);
Consola.Continuar(); // Presiona para continuar...
Console.Clear();

// Implementación del juego, Lista de Personajes
string NombreArchivo = "Personajes.json";
List<Personaje> ListPersonajes = await FabricaDePersonajes.ListPersonajes(NombreArchivo); // Lista Principal de Personajes

if (ListPersonajes == null) // Si hay un problema con ListPersonajes, corto la ejecución del programa
    return;

Consola.Continuar();
Console.Clear();

/* Animacion.Dibujar(Animacion.HarryPotter, 0);
Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo); // El Personaje Principal es el Primero de la lista
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
PersonajePrincipalASCII.MostrarNombre(PersonajePrincipalASCII.Posicion);

// Lista de los Personajes Secundarios
List<PersonajeASCII> ListPersonajesSecundariosASCII = PersonajeASCII.ListPersonajesSecundariosASCII(ListPersonajes, ConsolaASCII);
string NombreArchivoHistorial = "HistorialGanadores.json";

bool Jugar = true;

while (Jugar)
{
    PersonajePrincipalASCII.Mover(1, ListPersonajesSecundariosASCII, PersonajePrincipalASCII, ConsolaASCII);

    foreach (PersonajeASCII PersonajeSecundarioASCII in ListPersonajesSecundariosASCII)
    {
        if (PersonajeSecundarioASCII != null)
        {
            PersonajeSecundarioASCII.MostrarNombre(PersonajeSecundarioASCII.Posicion);
            PersonajeSecundarioASCII.Dibujar();
        }
    }

    // Verificar si todos los personajes secundarios han sido derrotados
    if (ListPersonajesSecundariosASCII.Count == 0)
    {
        // Guardo el Personaje en el Historial de Ganadores
        DateTime Dia = DateTime.Now;
        PersonajeGanador PersonajePrincipalGanador = new PersonajeGanador(PersonajePrincipalASCII.Personaje, Dia);

        HistorialJson.GuardarGanador(PersonajePrincipalGanador, NombreArchivoHistorial);

        Console.Clear();
        Animacion.Dibujar(ASCII.Victoria, 0); // Animación de Victoria
        Jugar = false; // Termina el juego
    }
}
