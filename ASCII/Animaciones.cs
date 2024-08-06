using System.Drawing;
using System.Text;
using EspacioConsola;

namespace EspacioPersonajeASCII;

public class Animacion
{
    public static void PresentacionInicio(string NombrePP, string SexoPP, Consola ConsolaASCII)
    {
        string Texto = "Pulsa Espacio para esquipear";
        Console.SetCursorPosition(ConsolaASCII.LimiteInferior.X - Texto.Length - 1, ConsolaASCII.LimiteInferior.Y - 1);
        Console.Write(Texto);
        
        CentrarYEsquipear(["Viajando..."], ConsolaASCII, 0, 100);
        Thread.Sleep(2000);
        CentrarYEsquipear(ASCII.Hogsmeade, ConsolaASCII, 1, 0);
        CentrarYEsquipear(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();

        CentrarYEsquipear(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        if (SexoPP == "Femenino")
        {
            CentrarYEsquipear([$"Bienvenida {NombrePP}, te estaba esperando."], ConsolaASCII, 30, 60);
        }
        else
        {
            CentrarYEsquipear([$"Bienvenido {NombrePP}, te estaba esperando."], ConsolaASCII, 30, 60);
        }
        Thread.Sleep(1500); // Tiempo para leer cada frase
        CentrarYEsquipear(["Finalmente llegaste al Club de los Duelos."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["Pensé que Hedwig se había perdido en el camino."], ConsolaASCII, 32, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["¿Tienes lo que se necesita para ganar? Demuéstralo..."], ConsolaASCII, 33, 60);

        CentrarYEsquipear(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
    }

    public static void PresentacionPersonajes(string SexoPP, Consola ConsolaASCII)
    {
        CentrarYEsquipear(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        CentrarYEsquipear(["Estos serán tus contrincantes."], ConsolaASCII, 30, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["Aprende sus fortalezas y debilidades."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        if (SexoPP == "Femenino")
        {
            CentrarYEsquipear(["Solo así podrás vencer a todos y coronarte como la Mejor."], ConsolaASCII, 32, 60);
        }
        else
        {
            CentrarYEsquipear(["Solo así podrás vencer a todos y coronarte como el Mejor."], ConsolaASCII, 32, 60);
        }

        CentrarYEsquipear(["Presiona una tecla para continuar..."], ConsolaASCII, 34, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
    }

    public static void PresentacionCombate(Consola ConsolaASCII)
    {
        CentrarYEsquipear(ASCII.HarryPotter, ConsolaASCII, 0, 0);

        CentrarYEsquipear(["Ahora podrás moverte dentro de los límites del mapa (A, W, S, D / ←, ↑, →, ↓)."], ConsolaASCII, 30, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["Piensa contra quién deseas luchar. Colócate a su misma altura. Tócalo para entrar en Combate."], ConsolaASCII, 31, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["En caso de Perder deberás comenzar de nuevo. Elije sabiamente a quién atacar primero."], ConsolaASCII, 32, 60);
        Thread.Sleep(1500);
        CentrarYEsquipear(["En caso de Ganar podrás mejorar tus estadísticas."], ConsolaASCII, 33, 60);

        CentrarYEsquipear(["Presiona una tecla para continuar..."], ConsolaASCII, 35, 1);
        EvitarTeclas();
        Console.ReadKey();
        Console.Clear();
    }

    // Función para centrar Textos 
    public static void CentrarYEsquipear(string[] Texto, Consola ConsolaASCII, int Y, int Velocidad)
    {
        foreach (string Linea in Texto)
        {
            Console.SetCursorPosition((ConsolaASCII.LimiteInferior.X - Linea.Length) / 2, Y);

            foreach (char Letra in Linea)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo Tecla = Console.ReadKey(true);
                    if (Tecla.Key == ConsoleKey.Spacebar) // Tecla para esquipear la animación
                    {
                        // Mostrar el resto del texto instantáneamente
                        Console.Write(Linea[Linea.IndexOf(Letra)..]); // Console.Write(Linea.Substring(Linea.IndexOf(Letra)));
                        break;
                    }
                }

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