namespace EspacioPersonaje;

class Datos
{
    private string nombre;
    private string genero; // F o M

    public string Nombre { get => nombre; set => nombre = value; }
    public string Genero { get => genero; set => genero = value; }
}

class Caracteristicas
{
    private int ataque;
    private int bloqueo;
    private int salud;

    public int Ataque { get => ataque; set => ataque = value; }
    public int Bloqueo { get => bloqueo; set => bloqueo = value; }
    public int Salud { get => salud; set => salud = value; }
}
public class Personaje
{
    private Datos descripcion;
    private Caracteristicas habilidades;

    // Constructor para cada personaje
    public Personaje(string nombre, string genero, int ataque, int bloqueo)
    {
        descripcion = new Datos
        {
            Nombre = nombre,
            Genero = genero
        };

        habilidades = new Caracteristicas
        {
            Ataque = ataque,
            Bloqueo = bloqueo,
            Salud = 100 // Inicialmente, la salud de todos los personajes es 100
        };
    }

    internal Datos Descripcion { get => descripcion; set => descripcion = value; }
    internal Caracteristicas Habilidades { get => habilidades; set => habilidades = value; }

}