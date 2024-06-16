using EspacioPersonaje;
using EspacioConsola;
using EspacioPersonajeASCII;

// Configuración de Consola antes de comenzar
ConfiguracionConsola.Inicio();

// Datos para el Personaje Principal
string NombrePP, GeneroPP;
Console.WriteLine("Antes de comenzar");
Console.Write("Ingresa tu Nombre: ");
NombrePP = Console.ReadLine();

// Puede continuar únicamente cuando ingresa el género de forma correcta
do
{
    Console.Write("Y tu Género (F o M): ");
    GeneroPP = Console.ReadLine();
} while (GeneroPP != "F" && GeneroPP != "M" && GeneroPP != "f" && GeneroPP != "m");

// Creo el personaje pricipal a mano, el resto de forma aleatoria
GeneroPP = (GeneroPP == "F" || GeneroPP == "f") ? "female" : "male"; // Para normalizar los datos del PP con los de la API

Datos Descripcion = new Datos
{
    Nombre = NombrePP,
    Genero = GeneroPP
};

var Aleatorio = new Random();
int AtaqueAle = Aleatorio.Next(1, 5);
int BloqueoAle = Aleatorio.Next(1, 5);

Caracteristicas Habilidades = new Caracteristicas
{
    Ataque = AtaqueAle,
    Bloqueo = BloqueoAle,
    Salud = 100
};

Personaje PersonajePrincipal = new Personaje(Descripcion, Habilidades);

// Introducción
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Clear();
Animacion.Dibujar(Animacion.TituloInicio, 0);
ConfiguracionConsola.Continuar(); // Presiona para continuar...

Console.Clear();
Animacion.Dibujar(Animacion.HarryPotter, 1);
Animacion.PresentacionInicio(PersonajePrincipal.Descripcion.Nombre, PersonajePrincipal.Descripcion.Genero);
Console.SetCursorPosition(45, 24);
ConfiguracionConsola.Continuar();


// Prueba personaje aleatorio que llega desde la API
List<PersonajeAPI> listPersonajesAPI = await FabricaDePersonajes.GetPersonajesAsync();
Personaje personajePrueba = FabricaDePersonajes.PersonajeAleatorio(listPersonajesAPI);

Console.WriteLine($"Nombre: {personajePrueba.Descripcion.Nombre}\nGenero: {personajePrueba.Descripcion.Genero}\nAtaque: {personajePrueba.Habilidades.Ataque}\nBloqueo: {personajePrueba.Habilidades.Bloqueo}\nSalud: {personajePrueba.Habilidades.Salud}");