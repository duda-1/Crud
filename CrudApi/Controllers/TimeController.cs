using Crud;
using Crud.Aplicação;
using Crud.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private TimeService _service;
        private SimuladorBD bd;

        public TimeController(SimuladorBD bdSistema) 
        {
            bd = bdSistema;
            _service = new TimeService(bd);
        }

        [HttpPost ("Adicionar_Time")]
        public void AdicionmarTime([FromQuery] Time t)
        {
            _service.Adicionar(t);
        }


        [HttpGet("Listar_Time")]
        public List<Time> GetListarTime()
        {
            return _service.Listar();
        }

        [HttpGet("Buscar_Por_Id")]
        public void BuscarTimePorId(int id)
        {
            _service.BuscarPorId(id);
        }

        [HttpDelete("Remover_Time")]
        public void RemoverTime(int id)
        {
            _service.Remover(id);
        }

        [HttpPut("Atualizar_Time")]
        public void AtualizarTime(Time time, int id)
        {
            _service.Editar(id, time);
        }


    }
}
