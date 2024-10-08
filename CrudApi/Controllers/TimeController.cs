﻿using AutoMapper;
using Crud;
using Crud.Aplicação;
using Crud.Entidades;
using CrudApi._01_Entidades.DTO;
using Microsoft.AspNetCore.Mvc;

namespace CrudApi.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class TimeController : ControllerBase
    {
        private TimeService _service;
        private readonly IMapper _mapper;  

        public TimeController(IMapper mapper,IConfiguration configuration) //pegar connection string
        {
            _service = new TimeService(configuration);
            _mapper = mapper;
        }

        [HttpPost ("Adicionar_Time")]
        public void AdicionmarTime([FromQuery] CreateTimeDTO t)
        {
            Time time = _mapper.Map<Time>(t);
            _service.Adicionar(time);
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

        [HttpPut("Editar_Time")]
        public void Editar_Time([FromQuery] Time t)
        {
            _service.Editar(t);
        }


    }
}
