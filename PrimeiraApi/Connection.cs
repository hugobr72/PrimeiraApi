using System.Data;
using System.Data.SqlClient;

namespace PrimeiraApi {
    public class Connect {
        public DataTable Query(
            string query
            ) {
            SqlConnection conexao = new SqlConnection();
            conexao.ConnectionString = "Data Source=HUGO\\HUGOSQLSERVER;Initial Catalog=Teste1;Integrated Security=True";
            conexao.Open();
            SqlCommand comando = new SqlCommand();
            comando.CommandText = query;
            comando.Connection = conexao;
            comando.ExecuteReader();
            DataTable table = new DataTable();
            if (query.Contains("select")) {
                SqlDataAdapter data = new SqlDataAdapter(comando);
                conexao.Close();
                data.Fill(table);
            }
            else {
                conexao.Close();
                Query("select * from users");
            }
            
            return table;
        }    

    }
}
