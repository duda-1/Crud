using Crud;
using Crud.Aplicação;
using Crud.Entidades;
using System.Runtime.CompilerServices;

SimuladorBD contex = new SimuladorBD();
TimeService service = new TimeService(contex);

Time time1 = new Time()
{
    Nome = "Milam",
    AnoCriacao = 1931
};
Time time2 = new Time()
{
    Nome = "Flamengo",
    AnoCriacao = 2000
};
Time time3 = new Time()
{
    Nome = "Cruzeiro",
    AnoCriacao = 1980
};

service.Adicionar(time1);
service.Adicionar(time2);
List<Time> times = service.Listar();

foreach (Time t in times)
{
    Console.WriteLine($"{t.Nome}");
}

service.Excluir(time1);