using EspacioPersonaje;
using System.Text.Json;

namespace EspacioPersistencia;

public class PersonajesJson
{
    public static void GuardarPersonajes(List<Personaje> ListPersonajes, string NombreArchivo)
    {
        string ListPersonajesJson = JsonSerializer.Serialize(ListPersonajes); // Serializo la lista de personajes

        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Create))
        {
            using (StreamWriter StrWriter = new StreamWriter(Archivo))
            {
                StrWriter.WriteLine("{0}", ListPersonajesJson);
                StrWriter.Close();
                Console.WriteLine("Json de Personajes creado.");
            }
        }
    }

    public static List<Personaje> LeerPersonajes(string NombreArchivo)
    {
        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Open))
        {
            using (StreamReader StrReader = new StreamReader(Archivo))
            {
                string ListPersonajesJson = StrReader.ReadToEnd();
                Archivo.Close();
                Console.WriteLine("Lista de Personajes leída.");

                List<Personaje> ListPersonajes = JsonSerializer.Deserialize<List<Personaje>>(ListPersonajesJson);

                return ListPersonajes;
            }
        }
    }

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