using System.Drawing;
using System.Text;
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
            EvitarTeclas();
        }
        Console.WriteLine(); // Salto de línea entre textos
    }

    public static void PresentacionInicio(string NombrePP, string SexoPP, Consola ConsolaASCII)
    {
        Centrar(["Viajando..."], ConsolaASCII, 0, 100);
        Thread.Sleep(2000);
        Centrar(ASCII.Hogsmeade, ConsolaASCII, 1, 0);
        Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();

        Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        if (SexoPP == "Femenino")
        {
            Centrar([$"Bienvenida {NombrePP}, te estaba esperando."], ConsolaASCII, 30, 60);
        }
        else
        {
            Centrar([$"Bienvenido {NombrePP}, te estaba esperando."], ConsolaASCII, 30, 60);
        }
        Thread.Sleep(1500); // Tiempo para leer cada frase
        Centrar(["Finalmente llegaste al Club de los Duelos."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        Centrar(["Pensé que Hedwig se había perdido en el camino."], ConsolaASCII, 32, 60);
        Thread.Sleep(1500);
        Centrar(["¿Tienes lo que se necesita para ganar? Demuéstralo..."], ConsolaASCII, 33, 60);

        Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
    }

    public static void PresentacionPersonajes(string SexoPP, Consola ConsolaASCII)
    {
        Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        Centrar(["Estos serán tus contrincantes."], ConsolaASCII, 30, 60);
        Thread.Sleep(1500);
        Centrar(["Aprende sus fortalezas y debilidades."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        if (SexoPP == "Femenino")
        {
            Centrar(["Solo así podrás vencer a todos y coronarte como la Mejor."], ConsolaASCII, 32, 60);
        }
        else
        {
            Centrar(["Solo así podrás vencer a todos y coronarte como el Mejor."], ConsolaASCII, 32, 60);
        }

        Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 34, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
    }

    public static void PresentacionCombate(Consola ConsolaASCII)
    {
        Centrar(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        Centrar(["Ahora podrás moverte dentro de los límites del mapa (A, W, S, D / ←, ↑, →, ↓)."], ConsolaASCII, 30, 60);
        Thread.Sleep(1500);
        Centrar(["Piensa contra quién deseas luchar. Colócate a su misma altura. Tócalo para entrar en Combate."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        Centrar(["En caso de Perder deberás comenzar de nuevo. Elije sabiamente a quién atacar primero."], ConsolaASCII, 32, 60);
        Thread.Sleep(1500);
        Centrar(["En caso de Ganar podrás mejorar tus estadísticas."], ConsolaASCII, 33, 60);

        Centrar(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
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

    // Función para centrar Textos
    public static void Centrar(string[] Texto, Consola ConsolaASCII, int Y, int Velocidad)
    {
        foreach (string Linea in Texto)
        {
            Console.SetCursorPosition((Console.WindowWidth - Linea.Length) / 2, Y);

            foreach (char Letra in Linea)
            {
                Console.Write(Letra);
                Thread.Sleep(Velocidad); // Tiempo que demora hasta escribir otra letra, en ms
            }
            Y++;
        }
    }

    // Función para evitar que las teclas que se presionen durante una animación tengan efecto
    public static void EvitarTeclas()
    {
        while (Console.KeyAvailable)
        {
            Console.ReadKey(true);
        }
    }
}