using MySql.Data.MySqlClient;
using System.Windows.Forms;

public class Database
{
    private MySqlConnection connection;

    public Database(string server, string database, string uid, string password)
    {
        string srv = "///";
        string db = "///";
        string user = "///";
        string pass = "///";
        string connectionString = $"SERVER={srv};PORT=3306;DATABASE={db};UID={user};PASSWORD={pass};";

        connection = new MySqlConnection(connectionString);


    }

    public MySqlConnection GetConnection() => connection;

    public bool OpenConnection()
    {
        try
        {
            connection.Open();
            return true;
        }
        catch (MySqlException ex)
        {
            MessageBox.Show("Ошибка подключения: " + ex.Message);
            return false;
        }
    }

    public void CloseConnection()
    {
        if (connection.State == System.Data.ConnectionState.Open)
            connection.Close();
    }
}