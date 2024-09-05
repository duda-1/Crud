using Crud.Entidades;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Crud.Repositorio
{
    public class CidadeRepository
    {

        private readonly string ConnectionString;

        public CidadeRepository(IConfiguration configuration)
        {
            ConnectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public void Adicionar(Cidade c)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @"INSERT INTO Cidades(NomeCidade,NumHabitantes) 
                                    VALUES (@NomeCidade,@NumHabitantes)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@NomeCidade", c.NomeCidade);
                    command.Parameters.AddWithValue("@NumHabitantes", c.NumHabitantes);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Cidades WHERE Id = @Id;";

                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int id , string nomeCidade, int numHabitantes)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var updateCommand = @"UPDATE Cidades
                                SET NomeCidade = @NomeCidade,  NumHabitantes = @NumHabitantes
                                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NomeCidade", nomeCidade);
                    command.Parameters.AddWithValue("@NumHabitantes", numHabitantes);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cidade> Listar()
        {
            List<Cidade> cidade = new List<Cidade>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, NomeCidade, NumHabitantes FROM Cidades;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Cidade c = new Cidade();
                            c.Id = int.Parse(reader["Id"].ToString());
                            c.NomeCidade = reader["NomeCidade"].ToString();
                            c.NumHabitantes = int.Parse(reader["NumHabitantes"].ToString());
                            cidade.Add(c);
                        }
                    }
                }
            }
            return cidade;
        }

        public void BuscarPorId(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, NomeCidade, NumHabitantes FROM Cidades WHERE Id = @Id;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id: {reader["Id"]} - NomeCidade: {reader["NomeCidade"]} - NumHabitantes: {reader["NumHabitantes"]}");
                        }
                    }
                }
            }
        }

    }
}
