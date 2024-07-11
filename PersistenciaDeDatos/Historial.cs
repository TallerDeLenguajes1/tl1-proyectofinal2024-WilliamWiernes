using EspacioPersonaje;
using System.Text.Json;

namespace EspacioPersistencia;

public class PersonajeGanador(Personaje Personaje, DateTime Dia)
{
    private Personaje personaje = Personaje;
    private DateTime dia = Dia;

    public Personaje Personaje { get => personaje; set => personaje = value; }
    public DateTime Dia { get => dia; set => dia = value; }
}

public class HistorialJson
{
    // Función para guardar el Personaje Ganador en un Json
    public static void GuardarGanador(PersonajeGanador PersonajeGanador, string NombreArchivo)
    {
        List<PersonajeGanador> ListPersonajesGanadores = LeerGanadores(NombreArchivo); // Leo la Lista de Personajes Ganadores anteriores
        ListPersonajesGanadores.Add(PersonajeGanador);                                 // Y añado el nuevo Personaje Ganador a esa lista

        string ListPersonajesGanadoresJson = JsonSerializer.Serialize(ListPersonajesGanadores);

        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Create))
        {
            using (StreamWriter StrWriter = new StreamWriter(Archivo))
            {
                StrWriter.WriteLine("{0}", ListPersonajesGanadoresJson);
                StrWriter.Close();
            }
        }
    }

    // Función que retorna una Lista de Personajes Ganadores desde un Json
    public static List<PersonajeGanador> LeerGanadores(string NombreArchivo)
    {
        if (!Existe(NombreArchivo)) // Si el archivo no existe o exite pero no tiene datos, retorno una Lista vacía
        {
            return new List<PersonajeGanador>();
        }

        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Open))
        {
            using (StreamReader StrReader = new StreamReader(Archivo))
            {
                string PersonajesGanadoresJson = StrReader.ReadToEnd();
                Archivo.Close();
                
                List<PersonajeGanador> ListPersonajesGanadores = JsonSerializer.Deserialize<List<PersonajeGanador>>(PersonajesGanadoresJson);

                return ListPersonajesGanadores;
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
