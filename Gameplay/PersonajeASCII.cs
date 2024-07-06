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
}