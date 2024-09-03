using Crud.Entidades;
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
        private const string ConnectionString = "Data Source=CRUD.db";//Chamar o banco de dados

        public AlunoRepository()
        {

        }

        public void Adicionar(Aluno a)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string commandInsert = @"INSERT INTO Alunos(Nome,Idade,Peso) 
                                    VALUES (@Nome,@Idade,@Peso)";

                using (var command = new SQLiteCommand(commandInsert, connection))
                {
                    command.Parameters.AddWithValue("@Nome", a.Nome);
                    command.Parameters.AddWithValue("@Idade", a.Idade);
                    command.Parameters.AddWithValue("@Peso", a.Peso);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Remover(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                string deleteCommand = "DELETE FROM Alunos WHERE Id = @Id;";

                using (var command = new SQLiteCommand(deleteCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.ExecuteNonQuery();
                }
            }
        }

        public void Editar(int id,string nome,int idade, double peso)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var updateCommand = @"UPDATE Alunos
                                SET Nome = @Nome, Idade = @Idade ,Peso = @Peso
                                WHERE Id = @Id;";

                using (var command = new SQLiteCommand(updateCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    command.Parameters.AddWithValue("@Nome", nome);
                    command.Parameters.AddWithValue("@Idade", idade);
                    command.Parameters.AddWithValue("@Peso", peso);
                    command.ExecuteNonQuery();
                }
            }

        }

        public List<Aluno> Listar()
        {
            List<Aluno> aluno = new List<Aluno>();
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, Nome, Idade, Peso FROM Alunos;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {//Construir um objeto de Time
                            Aluno a = new Aluno();
                            a.Id = int.Parse(reader["Id"].ToString());
                            a.Nome = reader["Nome"].ToString();
                            a.Idade = int.Parse(reader["Idade"].ToString());
                            a.Peso = double.Parse(reader["Peso"].ToString());
                            aluno.Add(a);
                            //adicionar na lista

                            // Console.WriteLine($" Id: {reader["Id"]} - Nome: {reader["Nome"]} - AnoCriacao: {reader["AnoCriacao"]}");
                        }
                    }
                }
            }
            return aluno;
        }

        public void BuscarPorId(int id)
        {
            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();
                var selectCommand = "SELECT Id, Nome, Idade, Peso FROM Alunos WHERE Id = @Id;";

                using (var command = new SQLiteCommand(selectCommand, connection))
                {
                    command.Parameters.AddWithValue("@Id", id);
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($" Id: {reader["Id"]} - Nome: {reader["Nome"]} - Idade: {reader["Idade"]}  - Peso: {reader["Peso"]}");
                        }
                    }
                }
            }
        }
    }
}
