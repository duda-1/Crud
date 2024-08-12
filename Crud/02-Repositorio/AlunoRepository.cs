using Crud.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repositorio
{
    public class AlunoRepository
    {
        //Essa classe passa todos os dados para o nosso banco de dados
        public SimuladorBD bd { get; set; }//Chamar o banco de dados

        public AlunoRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Aluno alunos)
        {
            //Nesse metodo passamos um parametro com o tipo Aluno
            //Bd => chamar o banco de dados
            //Alunos => Nome da lista que colocamos dessa pagina
            //Add => Comando que iremos realizar 
            bd.Alunos.Add(alunos);
        }

        public void Remover(Aluno alunos)
        {
            //Nesse metodo passamos um parametro com o tipo Aluno
            //Bd => chamar o banco de dados
            //Alunos => Nome da lista que colocamos dessa pagina
            //Remove => Comando que iremos realizar 
            bd.Alunos.Remove(alunos);
        }

        public void Editar(int id, Aluno editarAluno)
        {
            Aluno alunoBancoDeDados = BuscarPorId(id);

            alunoBancoDeDados.Nome = editarAluno.Nome;
            alunoBancoDeDados.Idade= editarAluno.Idade;
            alunoBancoDeDados.Peso = editarAluno.Peso;

        }

        public List<Aluno> Listar()
        {
            //Nesse metodo ele tem retorno de uma lista pois ele tem que devolver algo
            //ao inverso das outras que retornam void .
            return bd.Alunos.ToList();
        }

        public Aluno BuscarPorId(int id)
        {
            //Nesse metodo 
            foreach (Aluno a in bd.Alunos)
            {
                if (id == a.Id)
                {
                    return a;
                }
            }
            return null;
        }
    }
}
