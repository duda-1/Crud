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

        public void Remover(int id)
        {
            Cidade c = BuscarPorId(id);
          repository.Remover(c);
        }

        public void Editar(int id, Cidade cidade)
        {
            repository.Editar(id, cidade);
        }

        public List<Cidade> Listar()
        {
           return repository.Listar();
        }

        public Cidade BuscarPorId(int id)
        {
            return repository.BuscarPorId(id);
        }
    }
}
