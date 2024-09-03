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

        public AlunoService()
        {
            repository = new AlunoRepository();
        }

        public void Adicionar(Aluno alunos)
        {
            repository.Adicionar(alunos);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public void Editar(int id, string nome, int idade, double peso)
        {
            repository.Editar(id, nome,idade, peso);
        }

        public void BuscarPorId(int id)
        {
            repository.BuscarPorId(id);
        }

        public List<Aluno> Listar()
        {
            return repository.Listar();
        }
    }
}
