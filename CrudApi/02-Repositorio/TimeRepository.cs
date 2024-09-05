using Crud.Entidades;
using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repositorio
{
    public class TimeRepository
    {
        private readonly string ConnectionString;

        //Construtor
        public TimeRepository(IConfiguration configuration)//Interface que me ajuda apegar valores do appsettings.json
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Time t)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Time>(t);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Time novoTime = BuscarPorId(id);
            connection.Delete<Time>(novoTime);
        }

        public void Editar(Time t)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Time>(t);
        }

        public List<Time> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Time>().ToList();
        }

        public Time BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Time>(id);
        }
    }
  
}
