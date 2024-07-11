using System.Drawing;
using System.Dynamic;
using EspacioConsola;
using EspacioPersistencia;
using EspacioPersonaje;
using EspacioPersonajeASCII;

namespace EspacioGameplay;
public partial class PersonajeASCII
{
    private Point posicion; // Posición Inicial dentro del marco
    private Consola consolaPP; // Para el sistema de colisiones con el marco
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

    // Función para poner el nombre del personaje sobre su cabeza, tomando en cuenta la Posición con la que fue creado
    public void MostrarNombre(Point Posicion)
    {
        Console.SetCursorPosition(Posicion.X, Posicion.Y - 1);
        Console.Write($"[{Personaje.Descripcion.Nombre}]");
    }

    // Función para crear Lista de Personajes Secundarios junto a sus Posiciones dentro del Marco
    public static List<PersonajeASCII> ListPersonajesSecundariosASCII(List<Personaje> ListPersonajes, Consola ConsolaASCII)
    {
        List<PersonajeASCII> ListPersonajesSecundariosASCII = new List<PersonajeASCII>();

        int j = ConsolaASCII.LimiteSuperior.X + 1;
        for (int i = 0; i < 5; i++)
        {
            PersonajeASCII PersonajeSecundarioASCII = new PersonajeASCII(new Point(j, ConsolaASCII.LimiteSuperior.Y + 2), ConsolaASCII, ListPersonajes[i + 1]); // i + 1 debido a que la Posición 0 es del Personaje Principal
            ListPersonajesSecundariosASCII.Add(PersonajeSecundarioASCII);
            j += 25;
        }

        return ListPersonajesSecundariosASCII;
    }
}