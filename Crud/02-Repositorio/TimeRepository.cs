using Crud.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repositorio
{
    public class TimeRepository
    {
        public SimuladorBD bd { get; set; }//Chamar o banco de dados

        //Construtor
        public TimeRepository(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
        }

        public void Adicionar(Time time)
        { 
            bd.Times.Add(time);
        }

        public void Remover(Time time)
        {
            bd.Times.Remove(time);
        }

        public void Editar(int id, Time editarTime)
        {
            Time timeBancoDeDados = BuscarPorId(id);

            timeBancoDeDados.Nome = editarTime.Nome;
            timeBancoDeDados.AnoCriacao = editarTime.AnoCriacao;
        }

        public List<Time> Listar()
        {
            return bd.Times.ToList();
        }

        public Time BuscarPorId(int id)
        {
           foreach(Time t in bd.Times)
           {
              if(id == t.Id)
              {
                    return t;
              }
           }
            return null;
        }
    }
  
}
