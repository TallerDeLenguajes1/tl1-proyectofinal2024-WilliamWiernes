using EspacioPersonaje;
using System.Text.Json;

namespace EspacioPersistencia;

public class PersonajesJson
{
    // Función para guardar una Lista de Personajes en un Json
    public static void GuardarPersonajes(List<Personaje> ListPersonajes, string NombreArchivo)
    {
        string ListPersonajesJson = JsonSerializer.Serialize(ListPersonajes); // Serializo la lista de personajes

        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Create))
        {
            using (StreamWriter StrWriter = new StreamWriter(Archivo))
            {
                StrWriter.WriteLine("{0}", ListPersonajesJson);
                StrWriter.Close();
            }
        }
    }

    // Función que retorna una Lista de Personajes desde un Json
    public static List<Personaje> LeerPersonajes(string NombreArchivo)
    {
        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Open))
        {
            using (StreamReader StrReader = new StreamReader(Archivo))
            {
                string ListPersonajesJson = StrReader.ReadToEnd();
                Archivo.Close();

                List<Personaje> ListPersonajes = JsonSerializer.Deserialize<List<Personaje>>(ListPersonajesJson);

                return ListPersonajes;
            }
        }
    }

    // Función que determina si un Archivo existe, no existe o existe pero no tiene datos
    public static bool Existe(string NombreArchivo)
    {
        if (File.Exists(NombreArchivo)) // Si el archivo existe
        {
            using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Open))
            {
                using (StreamReader StrReader = new StreamReader(Archivo))
                {
                    string ListPersonajesJson = StrReader.ReadToEnd();
                    Archivo.Close();

                    if (string.IsNullOrEmpty(ListPersonajesJson) != true)
                    {
                        return true; // Si existe y tiene datos
                    }
                    else
                    {
                        return false; // Si existe pero no tiene datos
                    }
                }
            }
        }
        else
        {
            return false; // Si el archivo no existe
        }
    }
}