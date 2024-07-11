using System.Drawing;
using EspacioGameplay;

namespace EspacioConsola;

public class Consola(int Ancho, int Altura, Point LimiteSuperior, Point LimiteInferior)
{
    private int ancho = Ancho;
    private int altura = Altura;
    private Point limiteSuperior = LimiteSuperior;
    private Point limiteInferior = LimiteInferior;

    public int Ancho { get => ancho; set => ancho = value; }
    public int Altura { get => altura; set => altura = value; }
    public Point LimiteSuperior { get => limiteSuperior; set => limiteSuperior = value; }
    public Point LimiteInferior { get => limiteInferior; set => limiteInferior = value; }

    // Función para Dibujar el Marco dentro de la Consola, Desarrollo de Gameplay
    public void DibujarMarco()
    {
        Console.ForegroundColor = ConsoleColor.DarkCyan;

        for (int i = LimiteSuperior.X; i <= LimiteInferior.X; i++)
        {
            Console.SetCursorPosition(i, LimiteSuperior.Y);
            Console.Write("═");
            Console.SetCursorPosition(i, LimiteInferior.Y);
            Console.Write("═");
        }

        for (int i = LimiteSuperior.Y; i <= LimiteInferior.Y; i++)
        {
            Console.SetCursorPosition(LimiteSuperior.X, i);
            Console.Write("║");
            Console.SetCursorPosition(LimiteInferior.X, i);
            Console.Write("║");
        }

        Console.SetCursorPosition(LimiteSuperior.X, LimiteSuperior.Y);
        Console.Write("╔");

        Console.SetCursorPosition(LimiteSuperior.X, LimiteInferior.Y);
        Console.Write("╚");

        Console.SetCursorPosition(LimiteInferior.X, LimiteSuperior.Y);
        Console.Write("╗");

        Console.SetCursorPosition(LimiteInferior.X, LimiteInferior.Y);
        Console.Write("╝");
    }

    // Función para Configurar la Consola antes de Comenzar la Introducción
    public void ConfiguracionIncial()
    {
        Console.SetWindowSize(Ancho, Altura); // Establece el Ancho y Alto de la Ventana
        Console.Title = "Harry Potter y el Club de Duelos";
        Console.CursorVisible = false; // Esconde el Cursor
        Console.ForegroundColor = ConsoleColor.DarkCyan; // Cambia el Color del Texto
        Console.Clear();   
    }

    public static void Continuar()
    {
        Console.WriteLine();
        Console.WriteLine("Presiona una tecla para continuar...");
        Console.ReadKey();
    }
}