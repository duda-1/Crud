using Crud.Aplicação;
using Crud.Entidades;
using Crud;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    public class AlunoContreller : ControllerBase
    {
        private AlunoService _service;
        private SimuladorBD bd;

        public AlunoContreller(SimuladorBD bdSistema)
        {
            bd = bdSistema;
            _service = new AlunoService(bd);
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

        [HttpPut("Atualizar_Aluno")]
        public void AtualizarAluno(Aluno aluno, int id)
        {
            _service.Editar(id, aluno);
        }
    }
}
