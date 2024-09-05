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
    public class AlunoRepository
    {

        //Essa classe passa todos os dados para o nosso banco de dados
        private readonly string ConnectionString;//Chamar o banco de dados

        public AlunoRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Aluno a)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Insert<Aluno>(a);
        }

        public void Remover(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            Aluno novoAluno = BuscarPorId(id);
            connection.Delete<Aluno>(novoAluno);
        }

        public void Editar(Aluno a)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Update<Aluno>(a);

        }

        public List<Aluno> Listar()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.GetAll<Aluno>().ToList();
        }

        public Aluno BuscarPorId(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            return connection.Get<Aluno>(id);
        }
    }
}
