using Crud.Aplicação;
using Crud;
using Microsoft.AspNetCore.Mvc;
using Crud.Entidades;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class EduardaController : ControllerBase
    {

        public EduardaController()
        {
        }
            [HttpPost("Editar_Registro")]
            public void AdicionmarTime([FromQuery] Time t)
            {
               
            }

            [HttpPut("Atualizar_Time")]
            public void AtualizarTime(Time time, int id)
            {
                
            }
        }


    }
}
