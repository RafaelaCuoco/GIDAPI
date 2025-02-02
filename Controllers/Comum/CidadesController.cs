using System;
using GIDAPI.Models.Comum;
using Microsoft.AspNetCore.Mvc;

namespace GIAPI.Controllers.Comum
{
    [ApiController]
    [Route("api/[controller]")]
    public class CidadesController : ControllerBase
    {
        private readonly MySqlDatabase _db;

        public CidadesController(MySqlDatabase db)
        {
            _db = db;
        }

        // Rota padrão para obter todos os Cidades
        [HttpGet(Name = "Cidades")]
        public IEnumerable<Cidades> Get()
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstCity;";
            var reader = _db.ExecuteQuery(query);

            List<Cidades> lstCidades = new List<Cidades>();

            while (reader.Read())
            {
                var cidade = new Cidades
                {
                    ID = reader.GetString("ID"),
                    IDstate = reader.GetInt32("IDstate"),
                    Cidade = reader.GetString("City")
                };
                lstCidades.Add(cidade);
            }

            _db.CloseConnection();

            return lstCidades;
        }

        // Rota para obter um estado por ID
        [HttpGet("ID/{id}", Name = "Cidades por ID")]
        public IEnumerable<Cidades> Get(string id)
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstCity where ID = '" + id + "';";
            var reader = _db.ExecuteQuery(query);

            List<Cidades> lstCidades = new List<Cidades>();

            while (reader.Read())
            {
                var cidade = new Cidades
                {
                    ID = reader.GetString("ID"),
                    IDstate = reader.GetInt32("IDstate"),
                    Cidade = reader.GetString("City")
                };
                lstCidades.Add(cidade);
            }

            _db.CloseConnection();

            return lstCidades;
        }

        [HttpGet("IDstate/{IDstate}", Name = "Cidades por ID de Estado")]
        public IEnumerable<Cidades> Get(int IDstate)
        {
            _db.OpenConnection();

            var query = "SELECT * FROM lstCity where IDstate = " + IDstate + ";";
            var reader = _db.ExecuteQuery(query);

            List<Cidades> lstCidades = new List<Cidades>();

            while (reader.Read())
            {
                var cidade = new Cidades
                {
                    ID = reader.GetString("ID"),
                    IDstate = reader.GetInt32("IDstate"),
                    Cidade = reader.GetString("City")
                };
                lstCidades.Add(cidade);
            }

            _db.CloseConnection();

            return lstCidades;
        }
    }
}
