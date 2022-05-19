using LabManager.Models;
using Microsoft.Data.Sqlite;
namespace LabManager.Repositories;

class LabRepository
{
    public List<Lab> GetAll()
    {
        var labs = new List<Lab>();
        var connection = new SqliteConnection("Data Source=database.db");
        connection.Open();

        var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM Labs";

        var reader = command.ExecuteReader();
        while(reader.Read())
        {
            var id = reader.GetInt32(0);
            var number = reader.GetString(1);
            var name = reader.GetString(2);
            var block = reader.GetString(3);
            var lab = new Lab(id, number, name, block);
            labs.Add(lab);
        }
        connection.Close();
        return labs;
    }
}