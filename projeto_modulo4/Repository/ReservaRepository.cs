using Dapper;
using MySqlConnector;

namespace projeto_modulo4.Repository
{
    public class ReservaRepository
    {

        private string _stringConnection { get; set; }

        public ReservaRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //Método compra ingresso 

        //Método edita ingresso

        //Método consulta ingresso
        public List<ReservaRepository> ConsultaPersonTitle(string nome, string tituloEvento)
        {
            string query = "SELECT & FROM CityEvent INNER JOIN CityEvent ON CityEvent.IdEvent = EventReservation.IdEvent WHERE PersonName = @nome AND Title LIKE @tituloEvento";

            tituloEvento = $"%{tituloEvento}%";

            DynamicParameters parametros = new();
            parametros.Add("nome", nome);
            parametros.Add("tituloEvento", tituloEvento);
            using MySqlConnection conn = new MySqlConnection(_stringConnection);

            return conn.Query<ReservaRepository>(query, parametros).ToList();
        }

        //Método deleta ingresso
        public bool Deletar(int id)
        {
            string query = "DELETE FROM EventReservation WHERE idReservation = @id";

            DynamicParameters parametros = new();
            parametros.Add("id", id);

            using MySqlConnection conn = new MySqlConnection(_stringConnection);

            int linhasafetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;

        }

    }
}
