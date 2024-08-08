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

        public void Excluir(Time time)
        {
            repository.Remover(time);
        }

        public List<Time> Listar()
        { 
            //Pode fazer alterações 
            List<Time> t = repository.Listar().OrderBy(x => x.Nome).ToList();
            return t;
        }
    }
}
