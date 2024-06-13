namespace EspacioPersonajesASCII;

public class Animacion
{
    // Esta función hace el efecto de escribir letra a letra
    public static void Escribir(string texto, int velocidad)
    {
        foreach (char letra in texto)
        {
            Console.Write(letra);
            Thread.Sleep(velocidad); // Tiempo que demora hasta escribir otra letra, en ms
        }
        Console.WriteLine(); // Salto de línea entre textos
    }

    public static void PresentacionInicio(string nombrePP, string generoPP)
    {
        Console.SetCursorPosition(45, 10);
        if (generoPP == "F" || generoPP == "f")
        {
            Escribir($"Bienvenida {nombrePP}, te estaba esperando.", 60);
        }
        else
        {
            Escribir($"Bienvenido {nombrePP}, te estaba esperando.", 60);
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

    public static string[] TituloInicio = new string[]{
        @"                                          _ __",
        @"         ___                             | '  \",
        @"    ___  \ /  ___         ,'\_           | .-. \        /|",
        @"    \ /  | |,'__ \  ,'\_  |   \          | | | |      ,' |_   /|",
        @"  _ | |  | |\/  \ \ |   \ | |\_|    _    | |_| |   _ '-. .-',' |_   _",
        @" // | |  | |____| | | |\_|| |__    //    |     | ,'_`. | | '-. .-',' `. ,'\_",
        @" \\_| |_,' .-, _  | | |   | |\ \  //    .| |\_/ | / \ || |   | | / |\  \|   \",
        @"  `-. .-'| |/ / | | | |   | | \ \//     |  |    | | | || |   | | | |_\ || |\_|",
        @"    | |  | || \_| | | |   /_\  \ /      | |`    | | | || |   | | | .---'| |",
        @"    | |  | |\___,_\ /_\ _      //       | |     | \_/ || |   | | | |  /\| |",
        @"    /_\  | |           //_____//       .||`      `._,' | |   | | \ `-' /| |",
        @"         /_\           `------'        \ |    Y         `.\  | |  `._,' /_\",
        @"                                        \|       EL           `.\",
        @"                                             ___ _  _ _  _ _  _",
        @"                                              | / \|_)|\ ||_ / \",
        @"                                              | \_/| \| \||__\_/",
        @"                                                      _  _  _  ___ _ __ _",
        @"                                                      |\/| /_\ | __||  / \",
        @"                                                      |  |/   \|__|||__\_/"
    };

    public static string[] HarryPotter = new string[]{
        @"           ⢀",
        @"⠀⠀⠀⠀⠀⠀⠀⠀⠀⣼⡄⠀⠀⠀⡀",
        @"⠀⠀⠀⠀⠀⠀⠀⠀⣰⡿⣷⠀⠀⠀⢣",
        @"⠀⠀⠀⢀⣤⠀⠀⣰⠿⠡⢿⣷⡄⠀⠘⣷⡀⠀⢡⡀⠀⠀⢠",
        @"⠀⠀⠀⣾⡟⣠⣾⡿⢂⣴⣾⣿⣿⣦⡀⠘⢿⣦⡈⢳⣄⠀⠘⣧",
        @"⠀⠀⢸⡟⠐⠛⠿⠷⠿⢿⣿⣿⣿⣿⣿⡷⠌⠉⠛⠀⢉⣡⣶⣬",
        @"⠀⠀⢸⡷⠂⠀⠀⠀⠀⢄⠘⢿⣿⣿⡏⠀⠀⠀⠀⠀⠀⢈⠻⣿",
        @"⠀⠈⠀⢀⠀⡀⠀⢀⣔⣀⡀⠀⠛⡛⠂⣄⣴⣷⣤⣴⣶⣿⣧⠈⢠⠆",
        @"⡄⢰⣄⢸⣿⣿⣿⣿⣿⣿⣿⠆⢸⣿⡀⣿⣿⣿⣿⣿⣿⣿⣿⢠⣿",
        @"⠈⢻⣿⡄⢻⣿⣿⣿⣿⣿⠟⣠⣿⣿⣧⠙⢿⣿⣿⣿⣿⡿⢃⣼⣿",
        @"⠀⠀⣿⣿⣦⣬⣙⣛⣋⣥⠄⣿⣿⣿⣿⣷⣦⣍⣙⣋⣩⣴⣿⣿⡇",
        @"⠀⠀⠘⣿⣿⣿⣿⣿⣿⣿⣌⠛⠿⠿⣿⣋⣿⣿⣿⣿⣿⣿⣿⡿",
        @"⠀⠀⠀⢘⣿⣿⣿⣿⣿⢿⣿⣿⣷⣶⣾⣿⣿⣿⣿⣿⣿⣿⡿⠁",
        @"⠀⠀⠀⣾⣿⠹⣿⣿⣿⣦⣤⣤⢤⣭⣥⣤⣤⣶⣿⣿⣿⠟⢁⠀⢠",
        @"⠀⠀⢸⣿⣿⡇⠙⠿⣿⣿⣿⣿⣶⣶⣶⣿⣿⣿⣿⠟⢁⠔⠀⠀⢸⠆",
        @"⠀⠀⠀⣿⣿⣷⡀⠀⠈⠛⢿⣿⣿⣿⣿⣿⡿⠟⠁⠐⠁⠀⠀⠀⠜",
        @"⠀⠀⠀⣿⣿⣿⣿⣦⣄⡀⠀⠀⠈⠉⠉⠀⣠⣶⣦⡄⠀⠀⠀⠈",
        @"⠀⠀⠀⢹⣿⣿⣿⣿⣿⣿⣿⣶⠶⠀⠐⠛⠛⠛⠿⢿",
        @"⠀⠀⠀⠘⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⢁⣀⣀⣤",
        @"⠀⠀⠀⠀⠘⣿⣿⣿⠟⠁⢈⣷⠀⠀⠀⠀⢠⣶⣶⣾⣿⣿⣿⠇",
        @"⠀⠀⠀⠀⠀⠘⢿⢃⣤⣶⣿⣿⠀⠀⠀⠀⢸⣿⣿⣿⣿⣿⠏",
        @"⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⠏⠀⠀⠀⠀⠈⢿⣿⣿⣿⠏",
        @"⠀⠀⠀⠀⠀⠀⠀⠈⢿⣿⣿⠀⠀⠀⠀⠀⠀⠸⣿⡿⠋"
    };

    // Esta función printea línea a línea un array de strings. Velocidad en ms
    public static void Dibujar(string[] Dibujo, int velocidad)
    {
        Console.WriteLine();

        foreach (string linea in Dibujo)
        {
            Escribir(linea, velocidad);
        }

        Console.WriteLine();
    }
}
