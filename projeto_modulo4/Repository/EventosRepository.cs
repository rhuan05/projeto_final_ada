using Dapper;
using MySqlConnector;

namespace projeto_modulo4.Repository
{
    public class EventosRepository
    {

        //String de conexão com o banco de dados
        private string _stringConnection { get; set; }

        //Construtor
        public EventosRepository()
        {
            _stringConnection = Environment.GetEnvironmentVariable("DATABASE_CONFIG");
        }

        //Método adicionar evento
        public bool AdicionarEvento(Eventos evento)
        {
            string query = "INSERT INTO CityEvent (idEvent, title, description, dateHourEvent, local, address, price, status) VALUES (@idEvento, @titulo, @descricao, @dataHora, @local, @endereco, @preco, @status)";

            DynamicParameters parametros = new(evento);

            MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;
        }

        //Método editar evento
        public bool EditarEvento(Eventos evento, int id)
        {
            string query = "UPDATE CityEvent SET title = @titulo, description = @descricao, dateHourEvent = @dataHora, local = @local, address = @endereco, price = @preco, status = @status WHERE idEvent = @id";

            var parametros = new DynamicParameters(new
            {
                evento.Titulo,
                evento.Descricao,
                evento.DataHora,
                evento.Local,
                evento.Endereco,
                evento.Preco,
                evento.Status
            });

            parametros.Add("id", id);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;
        }

        //Método deletar evento
        public bool DeletarEvento(Eventos evento, int id)
        {
            string query = "DELETE FROM CityEvent WHERE idEvent = @id";

            DynamicParameters parametros = new(id);

            using MySqlConnection conn = new(_stringConnection);

            int linhasAfetadas = conn.Execute(query, parametros);

            return linhasAfetadas > 0;
        }

        //Método verifica status
        public bool VerificarStatus(Eventos evento, int id)
        {
            string query = "SELECT * FROM CityEvento WHERE idEvent = @id";

            DynamicParameters parametros = new(id);

            using MySqlConnection conn = new(_stringConnection);

            bool queryResult = conn.QueryFirst(query, parametros);

            return queryResult;
        }

        //Método buscar por título
        public List<Eventos> BuscarPorTitulo(string titulo)
        {
            string query = "SELECT * FROM CityEvent WHERE title LIKE @titulo";

            titulo = $"%{titulo}%";

            DynamicParameters parametros = new();
            parametros.Add("titulo", titulo);

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<Eventos>(query, parametros).ToList();
        }

        //Método buscar por local
        public List<Eventos> BuscarPorLocal(string local)
        {
            string query = "SELECT * FROM CityEvent WHERE local LIKE @local";

            local = $"%{local}%";

            DynamicParameters parametros = new();
            parametros.Add("local", local);

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<Eventos>(query, parametros).ToList();
        }

        //Método buscar por data
        public List<Eventos> BuscarPorPrecoeData(string data, int precoMin, int precoMax)
        {
            string query = "SELECT* FROM CityEvent WHERE dateHourEvent LIKE @data AND PRICE BETWEEN @precoMin AND @precoMax";

            data = $"%{data}%";

            DynamicParameters parametros = new();

            using MySqlConnection conn = new(_stringConnection);

            return conn.Query<Eventos>(query, parametros).ToList();
        }

    }
}
