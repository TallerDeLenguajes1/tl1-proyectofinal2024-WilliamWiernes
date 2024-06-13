using EspacioPersonaje;
using EspacioPersonajesASCII;

// Datos para el Personaje Principal
string nombrePP, generoPP;
Console.CursorVisible = false;
Console.Clear();
Console.WriteLine("Antes de comenzar");
Console.Write("Ingresa tu Nombre: ");
nombrePP = Console.ReadLine();

do
{
    Console.Write("Y tu Género (F o M): ");
    generoPP = Console.ReadLine();
} while (generoPP != "F" && generoPP != "M" && generoPP != "f" && generoPP != "m"); // Puede continuar únicamente cuando ingresa el género de forma correcta

// Creo el personaje pricipal
Personaje personajePrincipal = new(nombrePP, generoPP, 10, 10); // hacer aleatorio

// Introducción
Console.Clear();
Animacion.Dibujar(Animacion.TituloInicio, 0);
Console.WriteLine("Presiona una tecla para continuar...");
Console.ReadKey();

Console.Clear();
Animacion.Dibujar(Animacion.HarryPotter, 1);
Animacion.PresentacionInicio(personajePrincipal.Descripcion.Nombre, personajePrincipal.Descripcion.Genero);
Console.SetCursorPosition(45, 24);
Console.WriteLine("Presiona una tecla para continuar...");
Console.ReadKey();