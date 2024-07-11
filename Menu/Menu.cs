using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioGameplay;
using EspacioPersistencia;
using System.Drawing;
using System.Media;

namespace EspacioMenu;

public class Menu
{
    public static string Opciones(Consola ConsolaASCII)
    {
        string Seleccion;

        Console.Clear();
        Animacion.Centrar(ASCII.Menu, ConsolaASCII, 0, 0);
        do
        {
            Animacion.Centrar(["                                                                                                                                                   "], ConsolaASCII, 25, 0);
            Animacion.Centrar(["Selección: "], ConsolaASCII, 25, 0);
            Seleccion = Console.ReadLine();
        } while (Seleccion != "1" && Seleccion != "2" && Seleccion != "3" && Seleccion != "i" && Seleccion != "ii" && Seleccion != "iii" && Seleccion != "I" && Seleccion != "II" && Seleccion != "III");

        return Seleccion;
    }

    public static void Opcion1(string NombreArchivo, Consola ConsolaASCII, List<PersonajeAPI> ListPersonajesAPI)
    {
        // Implementación del juego, Lista de Personajes
        List<Personaje> ListPersonajes = FabricaDePersonajes.ListPersonajes(NombreArchivo, ConsolaASCII, ListPersonajesAPI); // Lista Principal de Personajes

        // Introducción - Presentación Inicio
        Console.Clear();
        Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo, ConsolaASCII); // El Personaje Principal es el Primero de la lista

        // Mostrar por pantalla los Personajes
        Animacion.PresentacionPersonajes(ListPersonajes[0].Descripcion.Sexo, ConsolaASCII);

        MostrarPersonajes.Mostrar(ListPersonajes, ConsolaASCII);
        Console.Clear();

        // Antes de dibujar el marco
        Animacion.PresentacionCombate(ConsolaASCII);

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
                Animacion.Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

                Animacion.Centrar(["Bien hecho."], ConsolaASCII, 30, 60);
                Thread.Sleep(1500);
                Animacion.Centrar(["Recuerda... Trabajar duro es importante, pero hay algo que importa más: creer en ti mismo."], ConsolaASCII, 31, 60);
                Thread.Sleep(1500);
                Animacion.Centrar(["Espero verte pronto..."], ConsolaASCII, 32, 60);

                Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 34, 1);
                Animacion.EvitarTeclas();
                Console.ReadKey();

                Console.Clear();
                Animacion.Centrar(ASCII.Victoria, ConsolaASCII, 0, 0); // Animación de Victoria
                Jugar = false; // Termina el juego

                Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 10, 1);
                Animacion.EvitarTeclas();
                Console.ReadKey();
            }
        }
    }

    public static void Opcion2(string NombreArchivo, Consola ConsolaASCII)
    {
        Console.Clear();
        Animacion.Centrar(ASCII.Ganadores, ConsolaASCII, 0, 0);

        List<PersonajeGanador> ListPersonajesGanadores = HistorialJson.LeerGanadores(NombreArchivo);

        if (ListPersonajesGanadores.Count > 0) // Por cómo funciona LeerGanadores. Si el Archivo no existe o existe pero no tiene datos, se retorna una Lista vacía
        {
            int Y = 10;

            foreach (PersonajeGanador PersonajeGanador in ListPersonajesGanadores)
            {
                // Dibujo ASCII por encima de los Datos del Personaje
                if (PersonajeGanador.Personaje.Descripcion.Sexo == "Femenino")
                {
                    Animacion.Centrar(ASCII.PersonajeFemenino, ConsolaASCII, Y, 0);
                }
                else
                {
                    Animacion.Centrar(ASCII.PersonajeMasculino, ConsolaASCII, Y, 0);
                }
                Animacion.Centrar([$"Nombre: {PersonajeGanador.Personaje.Descripcion.Nombre}", $"Sexo: {PersonajeGanador.Personaje.Descripcion.Sexo}", $"Día: {PersonajeGanador.Dia}"], ConsolaASCII, Y + 21, 0);
                Y += 25;
            }

            Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, Y + 2, 1);
            Animacion.EvitarTeclas();
            Console.ReadKey();
        }
        else
        {
            Animacion.Centrar(["Todavía no hay Ganadores. ¿Serás el Próximo?"], ConsolaASCII, 15, 0);
            Animacion.Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 17, 1);
            Animacion.EvitarTeclas();
            Console.ReadKey();
        }
    }

    public static void Opcion3(Consola ConsolaASCII)
    {
        Console.Clear();
        Animacion.Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        Thread.Sleep(1500);
        Animacion.Centrar(["Mi filosofía es que el que teme sufre dos veces, por eso no hay nada que temer."], ConsolaASCII, 30, 60);
        Thread.Sleep(1500);
        Animacion.Centrar(["Espero verte pronto..."], ConsolaASCII, 31, 60);

        Environment.Exit(0);
    }
}