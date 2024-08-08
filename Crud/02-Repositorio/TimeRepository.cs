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

        public void Editar()
        {

        }

        public List<Time> Listar()
        {
            return bd.Times.ToList();
        }

        internal Time BuscarPorId(int id)
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
