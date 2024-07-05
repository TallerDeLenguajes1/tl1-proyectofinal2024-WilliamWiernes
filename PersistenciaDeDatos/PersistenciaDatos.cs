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

public class InformacionPartida(Personaje Personaje1, Personaje Personaje2, string NombreGanador, DateTime Dia)
{
    private Personaje personaje1 = Personaje1;
    private Personaje personaje2 = Personaje2;
    private string nombreGanador = NombreGanador;
    private DateTime dia = Dia;

    public Personaje Personaje1 { get => personaje1; set => personaje1 = value; }
    public Personaje Personaje2 { get => personaje2; set => personaje2 = value; }
    public string Ganador { get => nombreGanador; set => nombreGanador = value; }
    public DateTime Dia { get => dia; set => dia = value; }
}

public class HistorialJson
{
    public class Historial(List<Personaje> ListPersonajesGanadores, List<InformacionPartida> ListInformacionPartidas)
    {
        private List<Personaje> listPersonajesGanadores = ListPersonajesGanadores;
        private List<InformacionPartida> listInformacionPartidas = ListInformacionPartidas;

        public List<Personaje> ListPersonajesGanadores { get => listPersonajesGanadores; set => listPersonajesGanadores = value; }
        public List<InformacionPartida> ListInformacionPartidas { get => listInformacionPartidas; set => listInformacionPartidas = value; }
    }

    public void GuardarGanadores(List<Personaje> ListPersonajesGanadores, List<InformacionPartida> ListInformacionPartidas, string NombreArchivo)
    {
        Historial HistorialGanadoresInformacionPartidas = new Historial(ListPersonajesGanadores, ListInformacionPartidas);

        string HistorialGanadoresInformacionPartidasJson = JsonSerializer.Serialize(HistorialGanadoresInformacionPartidas);

        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Create))
        {
            using (StreamWriter StrWriter = new StreamWriter(Archivo))
            {
                StrWriter.WriteLine("{0}", HistorialGanadoresInformacionPartidasJson);
                StrWriter.Close();
                Console.WriteLine("Json de Personaje Ganador e Información de Partidas creado.");
            }
        }
    }

    public static List<Personaje> LeerGanadores(string NombreArchivo)
    {
        using (FileStream Archivo = new FileStream(NombreArchivo, FileMode.Open))
        {
            using (StreamReader StrReader = new StreamReader(Archivo))
            {
                string HistorialGanadoresInformacionPartidasJson = StrReader.ReadToEnd();
                Archivo.Close();
                Console.WriteLine("Lista de Ganadores e Información de Partidas leída.");

                Historial HistorialGanadoresInformacionPartidas = JsonSerializer.Deserialize<Historial>(HistorialGanadoresInformacionPartidasJson);

                return HistorialGanadoresInformacionPartidas.ListPersonajesGanadores;
            }
        }
    }

    public static bool Existe(string NombreArchivo)
    {
        if (File.Exists(NombreArchivo)) // Si el archivo no existe
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