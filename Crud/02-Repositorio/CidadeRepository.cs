using Crud.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crud.Repositorio
{
    public class CidadeRepository
    {
        public SimuladorBD bd { get; set; }

        public CidadeRepository(SimuladorBD bdprenxido)
        {
            bd = bdprenxido;
        }

        public void Adicionar(Cidade cidades)
        {
            bd.Cidades.Add(cidades);
        }

        public void Remover(Cidade cidades)
        {
            bd.Cidades.Remove(cidades);
        }

        public void Editar()
        {

        }

        public List<Cidade> Listar()
        {
            return bd.Cidades.ToList();
        }

    }
}
