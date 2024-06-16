namespace EspacioConsola;

public class ConfiguracionConsola
{
    public static void Inicio()
    {
        //Console.SetWindowSize(100, 45); // Ancho y altura
        Console.Title = "Harry Potter y el Torneo Mágico"; // Título
        Console.CursorVisible = false; // Visibilidad del cursor
        Console.Clear(); // Limpiar consola
    }

    public static void Continuar()
    {
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }
}