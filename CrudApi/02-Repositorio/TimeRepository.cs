using Crud.Entidades;
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
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @"INSERT INTO Times(Nome,AnoCriacao) 
                                    VALUES (@Nome,@AnoCriacao)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", t.Nome);
                    command.Parameters.AddWithValue("@AnoCriacao", t.AnoCriacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Times WHERE Id = @Id;";

                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int id, string nome, int anocriacao)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var updateCommand = @"UPDATE Times
                                SET Nome = @Nome, AnoCriacao = @AnoCriacao
                                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@AnoCriacao", anocriacao);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Time> Listar()
        {
            List<Time> time = new List<Time>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, Nome, AnoCriacao FROM Times;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {//Construir um objeto de Time
                            Time t = new Time();
                            t.Id = int.Parse(reader["Id"].ToString());
                            t.Nome = reader["Nome"].ToString();
                            t.AnoCriacao = int.Parse(reader["AnoCriacao"].ToString());
                           time.Add(t);
                         //adicionar na lista
                         
                         // Console.WriteLine($" Id: {reader["Id"]} - Nome: {reader["Nome"]} - AnoCriacao: {reader["AnoCriacao"]}");
                        }
                    }
                }
            }
            return time;
        }

        public void BuscarPorId(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, Nome, AnoCriacao FROM Times WHERE Id = @Id;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id: {reader["Id"]} - Nome: {reader["Nome"]} - AnoCriacao: {reader["AnoCriacao"]}");
                        }
                    }
                }
            }
        }
    }
  
}
