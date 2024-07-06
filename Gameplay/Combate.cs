using System.Drawing;
using System.Dynamic;
using EspacioConsola;
using EspacioPersistencia;
using EspacioPersonaje;
using EspacioPersonajeASCII;

namespace EspacioGameplay;

public partial class PersonajeASCII
{
    // Función para el sistema de combate cuando el Personaje Principal colisiona con uno Secundario
    public static void Combate(PersonajeASCII PersonajeSecundarioASCII, PersonajeASCII PersonajePrincipalASCII, Consola ConsolaASCII, List<PersonajeASCII> ListPersonajesSecundariosASCII)
    {
        if (PersonajeSecundarioASCII != null)
        {
            // Animación inicio de cada Combate
            Console.Clear();
            Console.SetCursorPosition(ConsolaASCII.Ancho / 2 - PersonajePrincipalASCII.Personaje.Descripcion.Nombre.Length - 4, ConsolaASCII.Altura / 2);
            Animacion.Escribir($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} VS {PersonajeSecundarioASCII.Personaje.Descripcion.Nombre}", 150);
            Thread.Sleep(1000);
            Console.Clear();

            // Combate
            bool Turno = true; // Cambia su valor booleano continuamente, en base a esto se determina que personaje ataca y cuál defiende
            while (PersonajePrincipalASCII.Personaje.Habilidades.Salud > 0 && PersonajeSecundarioASCII.Personaje.Habilidades.Salud > 0)
            {
                int DanioProvocado;
                if (Turno)
                {
                    // Inicio
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} Ataca");

                    Console.SetCursorPosition(0, 1);
                    Console.Write($"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} Defiende");

                    Console.SetCursorPosition(0, 2);
                    if (PersonajePrincipalASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(ASCII.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(ASCII.PersonajeMasculino, 0);
                    }

                    Console.SetCursorPosition(0, 22);
                    if (PersonajeSecundarioASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(ASCII.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(ASCII.PersonajeMasculino, 0);
                    }

                    // Daño y Actualización de Salud 
                    DanioProvocado = Danio(PersonajePrincipalASCII.Personaje, PersonajeSecundarioASCII.Personaje, Turno);
                    PersonajeSecundarioASCII.Personaje.Habilidades.Salud -= DanioProvocado;

                    // Datos
                    Console.SetCursorPosition(0, 45);
                    Console.Write($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} hace {DanioProvocado} de Daño");

                    Console.SetCursorPosition(0, 46);
                    Console.Write($"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} salud restante {PersonajeSecundarioASCII.Personaje.Habilidades.Salud}");
                    Console.WriteLine();
                    Consola.Continuar();
                }
                else
                {
                    // Inicio
                    Console.Clear();
                    Console.SetCursorPosition(0, 0);
                    Console.Write($"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} Ataca");

                    Console.SetCursorPosition(0, 1);
                    Console.Write($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} Defiende");

                    Console.SetCursorPosition(0, 2);
                    if (PersonajeSecundarioASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(ASCII.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(ASCII.PersonajeMasculino, 0);
                    }

                    Console.SetCursorPosition(0, 22);
                    if (PersonajePrincipalASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(ASCII.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(ASCII.PersonajeMasculino, 0);
                    }

                    // Daño y actualización de salud 
                    DanioProvocado = Danio(PersonajePrincipalASCII.Personaje, PersonajeSecundarioASCII.Personaje, Turno);
                    PersonajePrincipalASCII.Personaje.Habilidades.Salud -= DanioProvocado;

                    // Datos
                    Console.SetCursorPosition(0, 45);
                    Console.Write($"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} hace {DanioProvocado} de Daño");

                    Console.SetCursorPosition(0, 46);
                    Console.Write($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} tiene salud restante {PersonajePrincipalASCII.Personaje.Habilidades.Salud}");
                    Console.WriteLine();
                    Consola.Continuar();
                }

                Turno = !Turno; // Cambia el turno
            }

            // Después del combate
            Console.Clear();

            // Si perdió el Personaje Principal
            if (PersonajePrincipalASCII.Personaje.Habilidades.Salud <= 0)
            {
                Animacion.Dibujar(ASCII.Derrota, 0);
                Environment.Exit(0); // Termina el juego y el programa
            }

            // Mensaje de Victoria
            Console.WriteLine("Haz derrotado a tu rival!");

            // Salud reestablecida al 100
            PersonajePrincipalASCII.Personaje.Habilidades.Salud = 100;

            // Eliminar al personaje secundario derrotado
            ListPersonajesSecundariosASCII.Remove(PersonajeSecundarioASCII);

            // Si hay Personajes Secundarios, se hace mejora. Sino pide mejorar cuando no quedán más personajes para derrotar
            if (ListPersonajesSecundariosASCII.Count > 0)
            {
                // Mejora de habilidades al Personaje Principal
                int SeleccionMejora;

                Console.WriteLine("Elige tu mejora");
                Console.WriteLine("1. +1 en Ataque");
                Console.WriteLine("2. +1 en Bloqueo");

                do
                {
                    Console.WriteLine("Selección: ");
                    int.TryParse(Console.ReadLine(), out SeleccionMejora);
                } while (SeleccionMejora != 1 && SeleccionMejora != 2);

                if (SeleccionMejora == 1)
                {
                    // Evito que el Ataque aumente si ya está al máximo
                    if (PersonajePrincipalASCII.Personaje.Habilidades.Ataque < 5)
                    {
                        PersonajePrincipalASCII.Personaje.Habilidades.Ataque += 1;
                        Console.WriteLine("Se otorgó +1 en Ataque");
                    }
                    else
                    {
                        Console.WriteLine("El Ataque está al máximo!");
                    }

                }
                else
                {
                    // Evito que el Bloqueo aumente si ya está al máximo
                    if (PersonajePrincipalASCII.Personaje.Habilidades.Bloqueo < 5)
                    {
                        PersonajePrincipalASCII.Personaje.Habilidades.Bloqueo += 1;
                        Console.WriteLine("Se otorgó +1 en Bloqueo");
                    }
                    else
                    {
                        Console.WriteLine("El Bloqueo está al máximo!");
                    }
                }
            }

            Consola.Continuar();
            Console.Clear();

            ConsolaASCII.DibujarMarco();
            PersonajePrincipalASCII.MostrarNombre(new Point(20, 45));
        }
    }

    // Función que determina el daño provocado en base al turno, al ataque y el bloqueo de los Personajes
    public static int Danio(Personaje PersonajePrincipal, Personaje PersonajeSecundario, bool Turno)
    {
        var Aleatorio = new Random();
        int Efectividad = Aleatorio.Next(1, 101);
        int ConstanteAjuste = 20;
        int Danio;

        if (Turno)
        {
            Danio = ((PersonajePrincipal.Habilidades.Ataque * Efectividad) - PersonajeSecundario.Habilidades.Bloqueo) / ConstanteAjuste;
        }
        else
        {
            Danio = ((PersonajeSecundario.Habilidades.Ataque * Efectividad) - PersonajePrincipal.Habilidades.Bloqueo) / ConstanteAjuste;

        }

        return Danio;
    }
}