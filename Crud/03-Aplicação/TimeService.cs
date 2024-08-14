using Crud.Entidades;
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
        public SimuladorBD bd { get; set; }//Propriedade para o bancco
        public TimeRepository repository { get; set; }

        public TimeService(SimuladorBD bdPreenchido)
        {
            bd = bdPreenchido;
            repository = new TimeRepository(bd);
        }

        public void Adicionar(Time time)
        {
            repository.Adicionar(time);
        }

        public void Remover(int id)
        {
            Time t = BuscarPorId(id);
            repository.Remover(t);
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

        public void Editar(int id, Time time)
        {
            repository.Editar(id, time);   
        }
    }
}
