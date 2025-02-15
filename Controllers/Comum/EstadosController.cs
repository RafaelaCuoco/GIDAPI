using System;
using GIDAPI.Models.Comum;
using Microsoft.AspNetCore.Mvc;
using MySql.Data.MySqlClient;

namespace GIDAPI.Controllers.Comum
{
    [ApiController]
    [Route("api/[controller]")]
    public class EstadosController : ControllerBase
    {
        private readonly MySqlDatabase _db;

        public EstadosController(MySqlDatabase db) => _db = db;

        // Rota padrão para obter todos os estados
        [HttpGet(Name = "Estados")]
        public IEnumerable<Estados> Get()
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstState;";
            var reader = _db.ExecuteQuery(query);

            List<Estados> lstEstados = new List<Estados>();

            while (reader.Read())
            {
                var estado = new Estados
                {
                    ID = reader.GetInt32("ID"),
                    Estado = reader.GetString("Nome"),
                    Sigla = reader.GetString("Sigla")
                };
                lstEstados.Add(estado);
            }

            _db.CloseConnection();

            return lstEstados;
        }

        // Rota para obter um estado por ID
        [HttpGet("ID/{id}", Name = "Estados por Id")]
        public IEnumerable<Estados> Get(int id)
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstState WHERE ID = @ID;";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@ID", id)
            };

            var reader = _db.ExecuteQuery(query, parameters);

            List<Estados> lstEstados = new List<Estados>();

            while (reader.Read())
            {
                var estado = new Estados
                {
                    ID = reader.GetInt32("ID"),
                    Estado = reader.GetString("Nome"),
                    Sigla = reader.GetString("Sigla")
                };
                lstEstados.Add(estado);
            }

            _db.CloseConnection();

            return lstEstados;

        }

        // Rota para obter um estado pela sigla
        [HttpGet("Sigla/{sigla}", Name = "Estados por Sigla")]
        public IEnumerable<Estados> GetBySigla(string sigla)
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstState WHERE Sigla = @Sigla;";
            var parameters = new MySqlParameter[]
            {
            new MySqlParameter("@Sigla", sigla.ToUpper())
            };

            var reader = _db.ExecuteQuery(query, parameters);

            List<Estados> lstEstados = new List<Estados>();

            while (reader.Read())
            {
                var estado = new Estados
                {
                    ID = reader.GetInt32("ID"),
                    Estado = reader.GetString("Nome"),
                    Sigla = reader.GetString("Sigla")
                };
                lstEstados.Add(estado);
            }

            _db.CloseConnection();

            return lstEstados;

        }
    }
}
