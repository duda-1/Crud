using Crud.Aplicação;
using Crud.Entidades;
using Crud;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    public class AlunoContreller : ControllerBase
    {
        private AlunoService _service;

        public AlunoContreller()
        {
            _service = new AlunoService();
        }

        [HttpPost("Adicionar_Aluno")]
        public void AdicionmarAluno(Aluno a)
        {
            _service.Adicionar(a);
        }


        [HttpGet("Listar_Aluno")]
        public List<Aluno> GetListarAluno()
        {
            return _service.Listar();
        }

        [HttpDelete("Remover_Aluno")]
        public void RemoverAluno(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar_Aluno")]
        public void EditarAluno(int id, string nome, int idade, double peso)
        {
            _service.Editar(id, nome,idade, peso);
        }
    }
}
