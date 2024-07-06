using System.Drawing;
using EspacioConsola;

namespace EspacioPersonajeASCII;

public class Animacion
{
    // Esta función hace el efecto de escribir letra a letra
    public static void Escribir(string Texto, int Velocidad)
    {
        foreach (char Letra in Texto)
        {
            Console.Write(Letra);
            Thread.Sleep(Velocidad); // Tiempo que demora hasta escribir otra letra, en ms
        }
        Console.WriteLine(); // Salto de línea entre textos
    }

    public static void PresentacionInicio(string NombrePP, string GeneroPP)
    {
        Console.SetCursorPosition(45, 10);
        if (GeneroPP == "Femenino")
        {
            Escribir($"Bienvenida {NombrePP}, te estaba esperando.", 60);
        }
        else
        {
            Escribir($"Bienvenido {NombrePP}, te estaba esperando.", 60);
        }
        Thread.Sleep(1500);
        Console.SetCursorPosition(45, 11);
        Escribir("Finalmente llegaste al torneo anual de Hogsmeade.", 60);
        Thread.Sleep(1500);
        Console.SetCursorPosition(45, 12);
        Escribir("Pensé que Hedwig se había perdido en el camino.", 60);
        Thread.Sleep(1500);
        Console.SetCursorPosition(45, 13);
        Escribir("¿Tienes lo que se necesita para ganar? Demuéstralo...", 60);
    }

    // Esta función printea línea a línea un array de strings. Velocidad en ms
    public static void Dibujar(string[] Dibujo, int Velocidad)
    {
        Console.WriteLine();

        foreach (string Linea in Dibujo)
        {
            Escribir(Linea, Velocidad);
        }

        Console.WriteLine();
    }
}