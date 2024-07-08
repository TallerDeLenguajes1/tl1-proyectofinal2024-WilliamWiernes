using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioGameplay;
using EspacioPersistencia;
using System.Drawing;

namespace EspacioMenu;

public class Menu
{
    public static int Opciones()
    {
        int Seleccion;

        Console.Clear();
        Console.WriteLine("1. Jugar");
        Console.WriteLine("2. Ver Ganadores");
        Console.WriteLine("3. Salir");

        do
        {
            Console.WriteLine("Selección: ");
            int.TryParse(Console.ReadLine(), out Seleccion);
        } while (Seleccion != 1 && Seleccion != 2 && Seleccion != 3);

        return Seleccion;
    }

    public static async void Opcion1(Consola ConsolaASCII, string NombreArchivo)
    {
        // Implementación del juego, Lista de Personajes
        List<Personaje> ListPersonajes = await FabricaDePersonajes.ListPersonajes(NombreArchivo); // Lista Principal de Personajes

        Consola.Continuar();
        Console.Clear();

        Animacion.Dibujar(ASCII.HarryPotter, 0);
        Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo); // El Personaje Principal es el Primero de la lista
        Console.SetCursorPosition(45, 24);
        Consola.Continuar();
        Console.Clear();

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
        Consola.Continuar();
    }

    public static void Opcion2(string NombreArchivo)
    {
        Console.Clear();
        Console.WriteLine("Ganadores de Torneos Anteriores:");

        List<PersonajeGanador> ListPersonajesGanadores = HistorialJson.LeerGanadores(NombreArchivo);

        if (ListPersonajesGanadores.Count > 0) // Por cómo funciona LeerGanadores. Si el Archivo no existe o existe pero no tiene datos, se retorna una Lista vacía
        {
            foreach (PersonajeGanador PersonajeGanador in ListPersonajesGanadores)
            {
                Console.WriteLine($"Nombre: {PersonajeGanador.Personaje.Descripcion.Nombre}");
                Console.WriteLine($"Día: {PersonajeGanador.Dia}");
                Console.WriteLine();
            }
            Consola.Continuar();
        }
        else
        {
            Console.WriteLine("Todavía no hay Ganadores. ¿Serás el Próximo?");
            Consola.Continuar();
        }
    }

    public static void Opcion3()
    {
        Console.Clear();
        Console.WriteLine("Saliendo...");

        Environment.Exit(0);
    }
}