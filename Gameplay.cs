using System.Drawing;
using System.Dynamic;
using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;

namespace EspacioGameplay;
public class PersonajeASCII
{
    private Point posicion; // Posición inicial Dentro del Marco
    private Consola consolaPP; // Para el Sistema de Colisiones con el Marco
    private List<Point> posicionesPersonajePrincipal;

    private Personaje personaje;

    public Point Posicion { get => posicion; set => posicion = value; }
    public Consola ConsolaPP { get => consolaPP; set => consolaPP = value; }
    public List<Point> PosicionesPersonajePrincipal { get => posicionesPersonajePrincipal; set => posicionesPersonajePrincipal = value; }
    public Personaje Personaje { get => personaje; set => personaje = value; }

    public PersonajeASCII(Point Posicion, Consola ConsolaPP, Personaje Personaje)
    {
        posicion = Posicion;
        consolaPP = ConsolaPP;
        PosicionesPersonajePrincipal = new List<Point>();
        personaje = Personaje;
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

    // Función que Detecta al Colisión del Personaje Principal con uno Secundario, y retorna el Peronsaje Secundario
    public PersonajeASCII ColisionesPersonajes(Point Posicion, List<PersonajeASCII> ListPersonajesSecundariosASCII)
    {
        int i = 0;
        foreach (PersonajeASCII PersonajeSecundarioASCII in ListPersonajesSecundariosASCII)
        {
            if (i < 4)
            {
                if (Posicion.X - 6 == PersonajeSecundarioASCII.Posicion.X && Posicion.Y == PersonajeSecundarioASCII.Posicion.Y)
                    return PersonajeSecundarioASCII;
            }
            else
            {
                if (Posicion.X + 6 == PersonajeSecundarioASCII.Posicion.X && Posicion.Y == PersonajeSecundarioASCII.Posicion.Y)
                    return PersonajeSecundarioASCII;
            }
            i++;
        }

        return null;
    }

    // Función para el Movimiento del Personaje, teniendo en cuenta la Tecla Pulsada y las Colisiones con el Marco y los Personajes Secundarios,
    // donde si Colisiona con uno se activa el Sistema de Combate
    public void Mover(int Velocidad, List<PersonajeASCII> ListPersonajesSecundariosASCII, PersonajeASCII PersonajePrincipalASCII, Consola ConsolaASCII)
    {
        if (Console.KeyAvailable)
        {
            Borrar();

            Point PosicionActual = new Point();

            Teclado(ref PosicionActual, Velocidad);

            Colisiones(PosicionActual);

            Combate(ColisionesPersonajes(Posicion, ListPersonajesSecundariosASCII), PersonajePrincipalASCII, ConsolaASCII, ListPersonajesSecundariosASCII);
        }

        Dibujar();
    }


    public void MostrarNombre(Point Posicion)
    {
        Console.SetCursorPosition(Posicion.X, Posicion.Y - 1); // Poner el Nombre del Personaje sobre su Cabeza
        Console.Write($"[{Personaje.Descripcion.Nombre}]");
    }

    // Función para crear Lista de Personajes Secundarios junto a sus Posiciones dentro del Marco
    public List<PersonajeASCII> ListPersonajesSecundariosASCII(List<Personaje> ListPersonajes, Consola ConsolaASCII)
    {
        List<PersonajeASCII> ListPersonajesSecundariosASCII = new List<PersonajeASCII>();
        int j = 0;

        for (int i = 0; i < 9; i++)
        {
            if (i < 4) // Se dibujan 4 a la Izquierda, el quinto es el Personaje Principal
            {
                PersonajeASCII PersonajeSecundarioASCII = new PersonajeASCII(new Point(20, 5 + (i * 10)), ConsolaASCII, ListPersonajes[i + 1]); // i + 1 debido a que la Posición 0 es del Personaje Principal
                ListPersonajesSecundariosASCII.Add(PersonajeSecundarioASCII);
            }
            else // Los otros 5 a la Derecha
            {
                PersonajeASCII PersonajeSecundarioASCII = new PersonajeASCII(new Point(145, 5 + (j * 10)), ConsolaASCII, ListPersonajes[i + 1]);
                ListPersonajesSecundariosASCII.Add(PersonajeSecundarioASCII);
                j++;
            }
        }

        return ListPersonajesSecundariosASCII;
    }

    // Función para el Sistema de Combate cuando el Personaje Principal Colisiona con una Secundario
    public static void Combate(PersonajeASCII PersonajeSecundarioASCII, PersonajeASCII PersonajePrincipalASCII, Consola ConsolaASCII, List<PersonajeASCII> ListPersonajesSecundariosASCII)
    {
        if (PersonajeSecundarioASCII != null)
        {
            // Animación Inicio de cada Combate
            Console.Clear();
            Console.SetCursorPosition(ConsolaASCII.Ancho / 2 - PersonajePrincipalASCII.Personaje.Descripcion.Nombre.Length - 4, ConsolaASCII.Altura / 2);
            Animacion.Escribir($"{PersonajePrincipalASCII.Personaje.Descripcion.Nombre} VS {PersonajeSecundarioASCII.Personaje.Descripcion.Nombre}", 150);
            Thread.Sleep(1000);
            Console.Clear();

            // Combate
            bool Turno = true;
            do
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
                        Animacion.Dibujar(Animacion.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(Animacion.PersonajeMasculino, 0);
                    }

                    Console.SetCursorPosition(0, 22);
                    if (PersonajeSecundarioASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(Animacion.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(Animacion.PersonajeMasculino, 0);
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
                        Animacion.Dibujar(Animacion.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(Animacion.PersonajeMasculino, 0);
                    }

                    Console.SetCursorPosition(0, 22);
                    if (PersonajePrincipalASCII.Personaje.Descripcion.Sexo == "Femenino")
                    {
                        Animacion.Dibujar(Animacion.PersonajeFemenino, 0);
                    }
                    else
                    {
                        Animacion.Dibujar(Animacion.PersonajeMasculino, 0);
                    }

                    // Daño y Actualización de Salud 
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

                Turno = !Turno;
            } while (PersonajePrincipalASCII.Personaje.Habilidades.Salud > 0 && PersonajeSecundarioASCII.Personaje.Habilidades.Salud > 0);

            // Después del Combate
            Console.Clear();
            if (PersonajePrincipalASCII.Personaje.Habilidades.Salud > 0)
            {
                // Devolver salud al 100
                PersonajePrincipalASCII.Personaje.Habilidades.Salud = 100;

                // Mejora de Habilidades al Personaje Principal
                PersonajePrincipalASCII.Personaje.Habilidades.Ataque += 1;
                PersonajePrincipalASCII.Personaje.Habilidades.Bloqueo += 1;

                // Eliminar al Personaje Secundario Derrotado
                ListPersonajesSecundariosASCII.Remove(PersonajeSecundarioASCII);

                // Guardar Datos de la Batalla


                Animacion.Dibujar(Animacion.Victoria, 0);
                Console.WriteLine("Mejora otorgada. +1 en Ataque y Bloqueo");
                Consola.Continuar();
                Console.Clear();
            }
            else
            {
                Animacion.Dibujar(Animacion.Derrota, 0);
                Consola.Continuar();
                Console.Clear();
                Environment.Exit(0); // Terminar el juego y el programa
            }

            ConsolaASCII.DibujarMarco();
            PersonajePrincipalASCII.MostrarNombre(new Point(20, 45));
        }
    }

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