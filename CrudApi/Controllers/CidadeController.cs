using Crud.Aplicação;
using Crud.Entidades;
using Crud;
using Microsoft.AspNetCore.Mvc;
using CrudApi._01_Entidades.DTO;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private CidadeService _service;

        public CidadeController(IConfiguration configuration)
        {
            _service = new CidadeService(configuration);
        }

        [HttpPost("Adicionar_Cidade")]
        public void AdicionmarCidade([FromQuery]CreateCidadeDTO c)
        {
            Cidade cidade = new Cidade();
            cidade.NomeCidade= c.NomeCidade;
            cidade.NumHabitantes = c.NumHabitantes;
            _service.Adicionar(cidade);
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
