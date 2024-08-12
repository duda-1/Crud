using Crud.Entidades;
using Crud.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Aplicação
{
    public class AlunoService
    {
        //Classe de serviço para validar os dados antes de mandar para a classe que 
        //adiciona no Banco de Dados .
        public SimuladorBD bd { get; set; }//Chamar o banco de dados
        public AlunoRepository repository { get; set; }//Mando para a pagina do repositorio antes de mandar
                                                       //para o Banco de Dados

        public AlunoService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new AlunoRepository(bd);
        }

        public void Adicionar(Aluno alunos)
        {
            repository.Adicionar(alunos);
        }

        public void Remover(Aluno alunos)
        {
            repository.Remover(alunos);
        }

        public void Editar(int id , Aluno aluno)
        {
            repository.Editar(id, aluno);
        }

        public Aluno BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }

        public List<Aluno> Listar()
        {
            return repository.Listar();
        }
    }
}
