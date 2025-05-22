using System.Data.SqlClient;
using System.Threading.Tasks;

namespace ProyectoFinal1
{
    public class DatabaseService
    {
        private readonly string connectionString;
        public DatabaseService(string connectionString) => this.connectionString = connectionString;

        public async Task GuardarInvestigacionAsync(string prompt, string resultado)
        {
            using (var conn = new SqlConnection(connectionString))
            {
                await conn.OpenAsync();
                var cmd = new SqlCommand(
                    "INSERT INTO Investigaciones (Prompt, Resultado) VALUES (@p, @r)", conn);
                cmd.Parameters.AddWithValue("@p", prompt);
                cmd.Parameters.AddWithValue("@r", resultado);
                await cmd.ExecuteNonQueryAsync();
            }
        }
    }
}