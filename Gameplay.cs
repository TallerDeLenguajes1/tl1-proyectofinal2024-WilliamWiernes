using System.Drawing;
using EspacioConsola;

namespace EspacioGameplay;
internal class PersonajePrincipalASCII
{
    private Point posicion; // Posición inicial Dentro del Marco
    private Consola consolaPP; // Para el Sistema de Colisiones con el Marco
    private List<Point> posicionesPersonajePrincipal;

    public Point Posicion { get => posicion; set => posicion = value; }
    public Consola ConsolaPP { get => consolaPP; set => consolaPP = value; }
    public List<Point> PosicionesPersonajePrincipal { get => posicionesPersonajePrincipal; set => posicionesPersonajePrincipal = value; }

    public PersonajePrincipalASCII(Point Posicion, Consola ConsolaPP)
    {
        posicion = Posicion;
        consolaPP = ConsolaPP;
        PosicionesPersonajePrincipal = new List<Point>();
    }

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

    // Función que Imprime un Caracter en Blanco en cada Punto donde el Personaje tiene Caracteres
    public void Borrar()
    {
        foreach (Point Posicion in PosicionesPersonajePrincipal)
        {
            Console.SetCursorPosition(Posicion.X, Posicion.Y);
            Console.Write(" ");
        }
    }

    // Función que Detecta la Tecla pulsada, y Reajusta la Posición del Personaje
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

    // Función que se fija si el Personaje tocó el Marco y Reajusta su Posición
    public void Colisiones(Point PosicionActual)
    {
        Point PosicionAux = new Point(Posicion.X + PosicionActual.X, Posicion.Y + PosicionActual.Y);

        if (PosicionAux.X <= ConsolaPP.LimiteSuperior.X) // Marco Izquierdo
            PosicionAux.X = ConsolaPP.LimiteSuperior.X + 1;

        if (PosicionAux.X + 7 >= ConsolaPP.LimiteInferior.X) // Marco Derecho
            PosicionAux.X = ConsolaPP.LimiteInferior.X - 8;

        if (PosicionAux.Y <= ConsolaPP.LimiteSuperior.Y) // Marco Arriba
            PosicionAux.Y = ConsolaPP.LimiteSuperior.Y + 1;

        if (PosicionAux.Y + 6 >= ConsolaPP.LimiteInferior.Y) // Marco Abajo
            PosicionAux.Y = ConsolaPP.LimiteInferior.Y - 7;

        Posicion = PosicionAux;
    }

    // Función para el Movimiento del Personaje, teniendo en cuenta la Tecla Pulsada y las Colisiones con el Marco
    public void Mover(int Velocidad)
    {
        if (Console.KeyAvailable)
        {
            Borrar();

            Point PosicionActual = new Point();

            Teclado(ref PosicionActual, Velocidad);

            Colisiones(PosicionActual);
        }

        Dibujar();
    }

    public static void Combate()
    {
        Console.Write("COMBATE");
    }
}