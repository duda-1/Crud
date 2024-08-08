using Crud.Entidades;
using Crud.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Aplicação
{
    public class CidadeService
    {
        public SimuladorBD bd { get; set; }
        public CidadeRepository repository { get; set; }

        public CidadeService(SimuladorBD bdprenxido)
        {
            bd = bdprenxido;
            repository = new CidadeRepository(bd);
        }

        public void Adicionar(Cidade cidades)
        {
            repository.Adicionar(cidades);
        }

        public void Remover(Cidade cidades)
        {
          repository.Remover(cidades);
        }

        public void Editar()
        {

        }

        public List<Cidade> Listar()
        {
           return repository.Listar();
        }
    }
}
