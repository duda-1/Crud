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

        public AlunoRepository repository { get; set; }//Mando para a pagina do repositorio antes de mandar
                                                       //para o Banco de Dados

        public AlunoService(IConfiguration configuration)
        {
            repository = new AlunoRepository(configuration);
        }

        public void Adicionar(Aluno alunos)
        {
            repository.Adicionar(alunos);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public void Editar(Aluno a)
        {
            repository.Editar(a);
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
