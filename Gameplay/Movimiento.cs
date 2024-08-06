using System.Drawing;
using System.Dynamic;
using EspacioConsola;
using EspacioPersistencia;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioHechizo;

namespace EspacioGameplay;
public partial class PersonajeASCII
{
    // Función para Dibujar al Personaje ASCII
    public void Dibujar()
    {
        int X = Posicion.X;
        int Y = Posicion.Y;

        // Seteo el Cursor y Dibujo al Personaje
        Console.SetCursorPosition(X, Y);
        Console.Write(@"__/\__");
        Console.SetCursorPosition(X, Y + 1);
        Console.Write(@"\\''//");
        Console.SetCursorPosition(X, Y + 2);
        Console.Write(@"/_||_\");
        Console.SetCursorPosition(X, Y + 3);
        Console.Write(@"\_()_/");
        Console.SetCursorPosition(X + 1, Y + 4);
        Console.Write(@"| . |");
        Console.SetCursorPosition(X + 1, Y + 5);
        Console.Write(@"| .  \");
        Console.SetCursorPosition(X + 1, Y + 6);
        Console.Write(@"\____'.");

        PosicionesPersonajePrincipal.Clear(); // Se borran todas las Posiciones. Sirve para cuando se ejecuta Mover()

        // Posiciones donde el Personaje tiene Caracteres
        PosicionesPersonajePrincipal.Add(new Point(X, Y));
        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y));
        PosicionesPersonajePrincipal.Add(new Point(X + 2, Y));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y));
        PosicionesPersonajePrincipal.Add(new Point(X + 4, Y));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y));

        PosicionesPersonajePrincipal.Add(new Point(X, Y + 1));
        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 1));
        PosicionesPersonajePrincipal.Add(new Point(X + 2, Y + 1));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 1));
        PosicionesPersonajePrincipal.Add(new Point(X + 4, Y + 1));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y + 1));

        PosicionesPersonajePrincipal.Add(new Point(X, Y + 2));
        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 2));
        PosicionesPersonajePrincipal.Add(new Point(X + 2, Y + 2));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 2));
        PosicionesPersonajePrincipal.Add(new Point(X + 4, Y + 2));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y + 2));

        PosicionesPersonajePrincipal.Add(new Point(X, Y + 3));
        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 3));
        PosicionesPersonajePrincipal.Add(new Point(X + 2, Y + 3));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 3));
        PosicionesPersonajePrincipal.Add(new Point(X + 4, Y + 3));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y + 3));

        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 4));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 4));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y + 4));

        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 5));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 5));
        PosicionesPersonajePrincipal.Add(new Point(X + 6, Y + 5));

        PosicionesPersonajePrincipal.Add(new Point(X + 1, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 2, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 3, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 4, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 5, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 6, Y + 6));
        PosicionesPersonajePrincipal.Add(new Point(X + 7, Y + 6));
    }

    // Función que imprime un caracter en blanco en cada Punto donde el Personaje Principal tiene caracteres
    public void Borrar()
    {
        foreach (Point Posicion in PosicionesPersonajePrincipal)
        {
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.Write(" ");
        }
    }

    // Función que detecta la tecla pulsada, y reajusta la Posición del Personaje Principal
    public static void Teclado(ref Point PosicionActual, int Velocidad) // Se pasa por Referencia la PosicionActual
    {
        ConsoleKeyInfo Tecla = Console.ReadKey(true);

        if (Tecla.Key == ConsoleKey.W || Tecla.Key == ConsoleKey.UpArrow)
            PosicionActual = new Point(0, -1);

        if (Tecla.Key == ConsoleKey.S || Tecla.Key == ConsoleKey.DownArrow)
            PosicionActual = new Point(0, 1);

        if (Tecla.Key == ConsoleKey.D || Tecla.Key == ConsoleKey.RightArrow)
            PosicionActual = new Point(1, 0);

        if (Tecla.Key == ConsoleKey.A || Tecla.Key == ConsoleKey.LeftArrow)
            PosicionActual = new Point(-1, 0);

        PosicionActual.X *= Velocidad;
        PosicionActual.Y *= Velocidad;
    }

    // Función para el Movimiento del Personaje Principal, teniendo en cuenta la tecla pulsada y las colisiones con el marco y los Personajes Secundarios,
    // donde si colisiona con uno se activa el sistema de combate
    public void Mover(int Velocidad, List<PersonajeASCII> ListPersonajesSecundariosASCII, PersonajeASCII PersonajePrincipalASCII, Consola ConsolaASCII, List<HechizoAPI> ListHechizosAPI)
    {
        if (Console.KeyAvailable)
        {
            Borrar();

            Point PosicionActual = new Point();

            Teclado(ref PosicionActual, Velocidad);

            Colisiones(PosicionActual);

            Combate(ColisionesPersonajes(Posicion, ListPersonajesSecundariosASCII), PersonajePrincipalASCII, ConsolaASCII, ListPersonajesSecundariosASCII, ListHechizosAPI);
        }
        
        Console.CursorVisible = false;
        Dibujar();
    }
}