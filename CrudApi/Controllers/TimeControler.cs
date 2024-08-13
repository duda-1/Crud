using Crud;
using Crud.Aplicação;
using Crud.Entidades;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TimeControler : ControllerBase
    {
        private TimeService _service;
        private SimuladorBD bd;

        public TimeControler(SimuladorBD bdSistema) 
        {
            bd = bdSistema;
            _service = new TimeService(bd);
        }

        [HttpPost ("Adicionar_Time")]
        public void AdicionmarTime(Time t)
        {
            _service.Adicionar(t);
        }

        [HttpGet ("Adicionar_Time")]
        public void GetAdicionarTime()
        {

        }

        [HttpGet("Listar_Time")]
        public List<Time> GetListarTime()
        {
            return null;
        }
    }
}
