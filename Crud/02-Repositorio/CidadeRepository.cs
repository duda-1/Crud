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
        public SimuladorBD bd { get; set; }
        private const string ConnectionString = "Data Source=CRUD.db";

        public CidadeRepository(SimuladorBD bdprenxido)
        {
            bd = bdprenxido;
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

        public void Editar(int id , string nomeCidade, int numHabitante)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var updateCommand = @"UPDATE Cidade
                                SET NomeCidade = @NomeCidade,  NumHabitante = @NumHabitante
                                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@NomeCidade", nomeCidade);
                    command.Parameters.AddWithValue("@ NumHabitante", numHabitante);
                    command.ExecuteNonQuery();
                }
            }
        }

        public List<Cidade> Listar()
        {
            return bd.Cidades.ToList();
        }

        public Cidade BuscarPorId(int id)
        {
            foreach (Cidade c in bd.Cidades)
            {
                if (id == c.Id)
                {
                    return c;
                }
            }
            return null;
        }

    }
}
