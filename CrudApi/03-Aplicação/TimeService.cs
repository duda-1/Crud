﻿using Crud.Entidades;
using Crud.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Aplicação
{
    public class TimeService
    {
        //Camada de serviço para salvar no banco
        public TimeRepository repository { get; set; }

        public TimeService(IConfiguration configuration)
        {
            repository = new TimeRepository(configuration);
        }

        public void Adicionar(Time time)
        {
            repository.Adicionar(time);
        }

        public void Remover(int id)
        {
            repository.Remover(id);
        }

        public List<Time> Listar()
        {
            //Pode fazer alterações 
          return repository.Listar();
             
        }

        public Time BuscarPorId(int id)
        {
          return repository.BuscarPorId(id);
        }

        public void Editar(Time t)
        {
            repository.Editar(t);   
        }
    }
}
