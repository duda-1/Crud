using Crud;
using Crud.Aplicação;
using Crud.Entidades;
using System.Runtime.CompilerServices;

SimuladorBD contex = new SimuladorBD();
TimeService service = new TimeService(contex);

Time time1 = new Time()
{
    Id = 1,
    Nome = "Milam",
    AnoCriacao = 1931
};
Time time2 = new Time()
{
    Id = 2,
    Nome = "Flamengo",
    AnoCriacao = 2000
};
Time time3 = new Time()
{
    Id = 1,
    Nome = "Cruzeiro",
    AnoCriacao = 1980
};

service.Adicionar(time1);
service.Adicionar(time2);
service.Adicionar(time3);
List<Time> times = service.Listar();

foreach (Time t in times)
{
    Console.WriteLine($"{t.Id}");
    Console.WriteLine($"{t.Nome}");
}

service.Excluir(time1);

int id = 1;
Time timeEscolhido = service.BuscarPorId(id);
Console.WriteLine(timeEscolhido);


