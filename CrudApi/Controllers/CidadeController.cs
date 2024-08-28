using Crud.Aplicação;
using Crud.Entidades;
using Crud;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{
    public class CidadeController : ControllerBase
    {
        private CidadeService _service;
        private SimuladorBD bd;

        public CidadeController(SimuladorBD bdSistema)
        {
            bd = bdSistema;
            _service = new CidadeService(bd);
        }

        [HttpPost("Adicionar_Cidade")]
        public void AdicionmarCidade([FromQuery]Cidade c)
        {
            _service.Adicionar(c);
        }


        [HttpGet("Listar_Cidade")]
        public List<Cidade> GetListarCidade()
        {
            return _service.Listar();
        }

        [HttpDelete("Remover_Cidade")]
        public void RemoverCidade(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Editar_Cidade")]
        public void EditarCidade(int id, Cidade cidade)
        {
            _service.Editar(id, cidade);
        }
    }
}
