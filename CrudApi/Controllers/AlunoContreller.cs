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
    public class AlunoContreller : ControllerBase
    {
        private AlunoService _service;
        private readonly IMapper _mapper;
        public AlunoContreller(IMapper mapper,IConfiguration configuration)
        {
            _service = new AlunoService(configuration);
            _mapper = mapper;
        }

        [HttpPost("Adicionar_Aluno")]
        public void AdicionmarAluno([FromQuery] CreateAlunoDTO a)
        {
            Aluno aluno = _mapper.Map<Aluno>(a);
            _service.Adicionar(aluno);
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
        public void EditarAluno(Aluno a)
        {
            _service.Editar(a);
        }
    }
}
