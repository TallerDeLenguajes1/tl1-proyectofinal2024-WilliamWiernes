using System.Drawing;
using System.Dynamic;
using EspacioConsola;
using EspacioPersistencia;
using EspacioPersonaje;
using EspacioPersonajeASCII;

namespace EspacioGameplay;

public partial class PersonajeASCII
{
    // Función que se fija si el Personaje Principal tocó el marco y reajusta su Posición
    public void Colisiones(Point PosicionActual)
    {
        Point PosicionAux = new Point(Posicion.X + PosicionActual.X, Posicion.Y + PosicionActual.Y);

        if (PosicionAux.X <= ConsolaPP.LimiteSuperior.X) // Marco izquierdo
            PosicionAux.X = ConsolaPP.LimiteSuperior.X + 1;

        if (PosicionAux.X + 7 >= ConsolaPP.LimiteInferior.X) // Marco derecho
            PosicionAux.X = ConsolaPP.LimiteInferior.X - 8;

        if (PosicionAux.Y <= ConsolaPP.LimiteSuperior.Y) // Marco arriba
            PosicionAux.Y = ConsolaPP.LimiteSuperior.Y + 1;

        if (PosicionAux.Y + 6 >= ConsolaPP.LimiteInferior.Y) // Marco abajo
            PosicionAux.Y = ConsolaPP.LimiteInferior.Y - 7;

        Posicion = PosicionAux;
    }

    // Función que detecta la colisión del Personaje Principal con uno Secundario, y retorna al Secundario
    public PersonajeASCII ColisionesPersonajes(Point Posicion, List<PersonajeASCII> ListPersonajesSecundariosASCII)
    {
        foreach (PersonajeASCII PersonajeSecundarioASCII in ListPersonajesSecundariosASCII)
        {
            if (PersonajeSecundarioASCII.Posicion.X <= 20)
            {
                if (Posicion.X - 6 == PersonajeSecundarioASCII.Posicion.X && Posicion.Y == PersonajeSecundarioASCII.Posicion.Y)
                    return PersonajeSecundarioASCII;
            }
            else
            {
                if (Posicion.X + 6 == PersonajeSecundarioASCII.Posicion.X && Posicion.Y == PersonajeSecundarioASCII.Posicion.Y)
                    return PersonajeSecundarioASCII;
            }
        }

        return null;
    }
}