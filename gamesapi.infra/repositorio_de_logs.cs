using gamesapi.infra.modelo;
using MySql.Data.MySqlClient;

namespace gamesapi.infra;

public class repositorio_de_logs
{
    private const string conn = "Host=localhost;Port=3366;user=root;database=amiiboo;password=my-secret-pw;";
    private const string date = ", current_date()";
    public bool LogInformation(Amiibo[] itens)
    {
        string[] insertCom = new string[]
        {
            "insert into amiibooLog (amiiboSeries, thecharacter, gameSeries, head, image, name, tail, type, searchdata)",
            "insert into amiibooData (amiiboSeries, thecharacter, gameSeries, head, image, name, tail, type)"
        };
        

        foreach (var insert in insertCom)
        {
            itens.ToList().ForEach((x) =>
            {
                string sqlToInsert =
                    $@"{insert} values ('{x.amiiboSeries}','{x.character}','{x.gameSeries}','{x.head}','{x.image}','{x.name}','{x.tail}','{x.type}'{ insertDate(insert) });";
                
                try
                {
                    using (MySqlConnection connection = new MySqlConnection(conn))
                    {
                        connection.Open();
                        using (MySqlCommand cmd = new MySqlCommand(sqlToInsert, connection))
                        {
                            int rowsAffected = cmd.ExecuteNonQuery();
                        }
                    }
                }
                catch
                {
                }
            });
        }

        return true;
    }

    public string insertDate(string insertCom)
    {
        return insertCom.Contains("searchdata") ? date : string.Empty;
    }
}