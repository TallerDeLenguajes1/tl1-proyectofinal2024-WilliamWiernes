using EspacioConsola;
using EspacioPersonaje;
using EspacioPersonajeASCII;
using EspacioPersistencia;

// Configuración de Consola antes de comenzar
ConfiguracionConsola.Inicio();

// Introducción
Console.ForegroundColor = ConsoleColor.DarkCyan;
Console.Clear();
Animacion.Dibujar(Animacion.TituloInicio, 0);
ConfiguracionConsola.Continuar(); // Presiona para continuar...

// Implementación del juego
string NombreArchivo = "Personajes.json";
List<Personaje> ListPersonajes = new List<Personaje>(); // Lista Principal de Personajes

// Comprobando la existencia de Json de Personajes
if (PersonajesJson.Existe(NombreArchivo)) // Si existe y tiene datos
{
    ListPersonajes = PersonajesJson.LeerPersonajes(NombreArchivo);
    Console.WriteLine("Lista de Personajes Creada desde Json");

    Console.Clear();
    Animacion.Dibujar(Animacion.HarryPotter, 1);
    // El Personaje Principal tiene que ser el primero del Json
    Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo);
    Console.SetCursorPosition(45, 24);
    ConfiguracionConsola.Continuar();
}
else // No existe, o existe pero no tiene datos
{
    // Creación del Personaje Principal
    Personaje PersonajePrincipal = FabricaDePersonajes.CrearPersonajePrincipal();

    // Lista Personajes API
    List<PersonajeAPI> ListPersonajesAPI = await FabricaDePersonajes.GetPersonajesAsync();
    if (ListPersonajesAPI == null) // Si hay algún error con la API, corto la ejecución del programa
    {
        return;
    }

    ListPersonajes.Add(PersonajePrincipal); // El Personaje Principal es siempre el primero

    Console.Clear();
    Animacion.Dibujar(Animacion.HarryPotter, 1);
    Animacion.PresentacionInicio(ListPersonajes[0].Descripcion.Nombre, ListPersonajes[0].Descripcion.Sexo);
    Console.SetCursorPosition(45, 24);
    ConfiguracionConsola.Continuar();

    for (int i = 0; i < 9; i++)
    {
        Personaje PersonajeParaLista = FabricaDePersonajes.PersonajeAleatorio(ListPersonajesAPI);
        ListPersonajes.Add(PersonajeParaLista); // El resto de personajes son aleatorios
    }

    PersonajesJson.GuardarPersonajes(ListPersonajes, NombreArchivo);

    Console.WriteLine("Lista de Personajes Creada desde API");
}

// Mostrar por pantalla los Personajes
foreach (var Personaje in ListPersonajes)
{
    Console.WriteLine($"Nombre: {Personaje.Descripcion.Nombre}\nSexo: {Personaje.Descripcion.Sexo}\nAtaque: {Personaje.Habilidades.Ataque}\nBloqueo: {Personaje.Habilidades.Bloqueo}\nSalud: {Personaje.Habilidades.Salud}");
}