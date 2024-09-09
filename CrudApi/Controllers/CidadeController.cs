using Crud.Aplicação;
using Crud.Entidades;
using Crud;
using Microsoft.AspNetCore.Mvc;
using CrudApi._01_Entidades.DTO;
using AutoMapper;

namespace CrudApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CidadeController : ControllerBase
    {
        private CidadeService _service;
        private readonly IMapper _mapper;
        public CidadeController(IMapper mapper, IConfiguration configuration)
        {
            _service = new CidadeService(configuration);
            _mapper = mapper;   
        }

        [HttpPost("Adicionar_Cidade")]
        public void AdicionmarCidade([FromQuery]CreateCidadeDTO c)
        {
            Cidade cidade = _mapper.Map<Cidade>(c);
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
