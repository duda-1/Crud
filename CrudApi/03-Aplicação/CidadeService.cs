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
        public CidadeRepository repository { get; set; }

        public CidadeService(IConfiguration configuration)
        {
            repository = new CidadeRepository(configuration);
        }

        public void Adicionar(Cidade cidades)
        {
            repository.Adicionar(cidades);
        }

        public void Remover(int id)
        {
          repository.Remover(id);
        }

        public void Editar(int id, Cidade c)
        {
            repository.Editar(id, c.NomeCidade, c.NumHabitantes);

        }

        public List<Cidade> Listar()
        {
           return repository.Listar();
        }

        public void BuscarPorId(int id)
        {
             repository.BuscarPorId(id);
        }
    }
}
