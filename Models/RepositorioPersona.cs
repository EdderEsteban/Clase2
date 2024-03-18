using MySql.Data.MySqlClient;

namespace Clase_2.Models;

public class RepositorioPersona
{
    readonly string ConnectionString = "Server=localhost;Database=testdotnet_clase_2;User=root;Password=;";

    public RepositorioPersona()
    {

    }

    public IList<Persona> GetPersonas()
    {
        var personas = new List<Persona>();
        using (var connection = new MySqlConnection(ConnectionString))
        {
            var sql = @$"Select {nameof(Persona.Id)}, {nameof(Persona.Nombre)}, {nameof(Persona.DNI)}, {nameof(Persona.Correo)} FROM personas";
            using (var comand = new MySqlCommand(sql, connection))
            {
                connection.Open();
                using (var reader = comand.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        personas.Add(new Persona
                        {
                            Id = reader.GetInt32(nameof(Persona.Id)),
                            Nombre = reader.GetString(nameof(Persona.Nombre)),
                            DNI = reader.GetInt32(nameof(Persona.DNI)),
                            Correo = reader.GetString(nameof(Persona.Correo))

                        });
                    }
                }
            }
        }
        return personas;
    }
}
