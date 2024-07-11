using System.Drawing;
using System.Dynamic;
using System.Text;
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
            Animacion.Centrar([$"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} VS {PersonajeSecundarioASCII.Personaje.Descripcion.Nombre}"], ConsolaASCII, ConsolaASCII.Altura / 2, 150);
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
                    Animacion.Centrar(ASCII.Combate, ConsolaASCII, 0, 0);

                    Animacion.Centrar([$"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} Ataca"], ConsolaASCII, 10, 0);

                    if (PersonajePrincipalASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, 11, 0);
                    }
                    else
                    {
                        Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, 11, 0);
                    }

                    Animacion.Centrar([$"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} Defiende"], ConsolaASCII, 33, 0);

                    if (PersonajeSecundarioASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, 34, 0);
                    }
                    else
                    {
                        Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, 34, 0);
                    }

                    // Daño y Actualización de Salud 
                    DanioProvocado = Danio(PersonajePrincipalASCII.Personaje, PersonajeSecundarioASCII.Personaje, Turno);
                    PersonajeSecundarioASCII.Personaje.Habilidades.Salud -= DanioProvocado;

                    // Datos
                    Animacion.Centrar([$"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} hace {DanioProvocado} de Daño"], ConsolaASCII, 55, 0);

                    Animacion.Centrar([$"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} salud restante {PersonajeSecundarioASCII.Personaje.Habilidades.Salud}"], ConsolaASCII, 56, 0);

                    Console.WriteLine();
                    Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 58, 1);
                    Animacion.EvitarTeclas();
                    Console.ReadKey();
                }
                else
                {
                    // Inicio
                    Console.Clear();
                    Animacion.Centrar(ASCII.Combate, ConsolaASCII, 0, 0);

                    Animacion.Centrar([$"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} Ataca"], ConsolaASCII, 10, 0);

                    if (PersonajeSecundarioASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, 11, 0);
                    }
                    else
                    {
                        Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, 11, 0);
                    }

                    Animacion.Centrar([$"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} Defiende"], ConsolaASCII, 33, 0);

                    if (PersonajePrincipalASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, 34, 0);
                    }
                    else
                    {
                        Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, 34, 0);
                    }

                    // Daño y Actualización de Salud 
                    DanioProvocado = Danio(PersonajePrincipalASCII.Personaje, PersonajeSecundarioASCII.Personaje, Turno);
                    PersonajePrincipalASCII.Personaje.Habilidades.Salud -= DanioProvocado;

                    // Datos
                    Animacion.Centrar([$"{PersonajeSecundarioASCII.Personaje.Descripcion.Nombre} hace {DanioProvocado} de Daño"], ConsolaASCII, 55, 0);

                    Animacion.Centrar([$"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} salud restante {PersonajePrincipalASCII.Personaje.Habilidades.Salud}"], ConsolaASCII, 56, 0);

                    Console.WriteLine();
                    Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 58, 1);
                    Animacion.EvitarTeclas();
                    Console.ReadKey();
                }

                Turno = !Turno; // Cambia el turno
            }

            // Después del combate
            Console.Clear();

            // Si perdió el Personaje Principal
            if (PersonajePrincipalASCII.Personaje.Habilidades.Salud <= 0)
            {
                Animacion.Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

                Animacion.Centrar(["Hay que tener un gran valor para enfretarse a nuestros enemigos."], ConsolaASCII, 30, 60);
                Thread.Sleep(1500);
                Animacion.Centrar(["Recuerda... La fuerza de tus convicciones determina tu éxito."], ConsolaASCII, 31, 60);
                Thread.Sleep(1500);
                Animacion.Centrar(["Espero verte pronto..."], ConsolaASCII, 32, 60);

                Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 34, 1);
                Animacion.EvitarTeclas();
                Console.ReadKey();

                Console.Clear();
                Animacion.Centrar(ASCII.Derrota, ConsolaASCII, 0, 0);

                Environment.Exit(0); // Termina el juego y el programa
            }

            // Mensaje de Victoria
            Animacion.Centrar(ASCII.GanarCombate, ConsolaASCII, 0, 0);

            // Salud reestablecida al 100
            PersonajePrincipalASCII.Personaje.Habilidades.Salud = 100;

            // Eliminar al personaje secundario derrotado
            ListPersonajesSecundariosASCII.Remove(PersonajeSecundarioASCII);

            // Si hay Personajes Secundarios, se hace mejora. Sino pide mejorar cuando no quedán más personajes para derrotar
            if (ListPersonajesSecundariosASCII.Count > 0)
            {
                // Mejora de habilidades al Personaje Principal
                string SeleccionMejora;

                Animacion.Centrar(["Elige tu mejora"], ConsolaASCII, 15, 0);
                Animacion.Centrar(["1. +1 en Ataque"], ConsolaASCII, 17, 0);
                Animacion.Centrar(["2. +1 en Bloqueo"], ConsolaASCII, 18, 0);

                do
                {
                    Animacion.Centrar(["                                   "], ConsolaASCII, 20, 0);
                    Animacion.Centrar(["Selección: "], ConsolaASCII, 20, 0);
                    SeleccionMejora = Console.ReadLine();
                } while (SeleccionMejora != "1" && SeleccionMejora != "2");

                if (SeleccionMejora == "1")
                {
                    // Evito que el Ataque aumente si ya está al máximo
                    if (PersonajePrincipalASCII.Personaje.Habilidades.Ataque < 5)
                    {
                        PersonajePrincipalASCII.Personaje.Habilidades.Ataque += 1;
                        Animacion.Centrar(["Se otorgó +1 en Ataque"], ConsolaASCII, 25, 0);
                    }
                    else
                    {
                        Animacion.Centrar(["El Ataque está al máximo!"], ConsolaASCII, 25, 0);
                    }

                }
                else
                {
                    // Evito que el Bloqueo aumente si ya está al máximo
                    if (PersonajePrincipalASCII.Personaje.Habilidades.Bloqueo < 5)
                    {
                        PersonajePrincipalASCII.Personaje.Habilidades.Bloqueo += 1;
                        Animacion.Centrar(["Se otorgó +1 en Bloqueo"], ConsolaASCII, 25, 0);
                    }
                    else
                    {
                        Animacion.Centrar(["El Bloqueo está al máximo!"], ConsolaASCII, 25, 0);
                    }
                }
            }

            Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 27, 1);
            Animacion.EvitarTeclas();
            Console.ReadKey();
            Console.Clear();

            ConsolaASCII.DibujarMarco();
            PersonajePrincipalASCII.MostrarNombre(new Point(ConsolaASCII.LimiteInferior.X / 2, ConsolaASCII.LimiteInferior.Y - 8));
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