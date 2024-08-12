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
    Console.WriteLine($"id: {t.Id}"+
                     $"\nNome do Time: {t.Nome}");
}

service.Excluir(time1);

int id = 2;
//Time timeEscolhido = service.BuscarPorId(id);
//Console.WriteLine(timeEscolhido);

Time editartime = new Time();
editartime.Nome = "Psg";
editartime.AnoCriacao =  1999;
service.Editar(id, editartime);

service.Listar();
foreach (Time t in times)
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine($"id: {t.Id}" +
                     $"\nNome do Time: {t.Nome}");
}

//Aluno
AlunoService service1 = new AlunoService(contex);

Aluno aluno1 = new Aluno()
{
    Id = 1,
    Nome = "Julia Rocha",
    Idade = 16 ,
    Peso =  53,
};
Aluno aluno2 = new Aluno()
{
    Id = 1,
    Nome = "Mirela Aparecida",
    Idade = 16,
    Peso = 52,
};
Aluno aluno3 = new Aluno()
{
    Id = 1,
    Nome = "Lavinia Couto ",
    Idade = 17,
    Peso = 50,
};
List<Aluno> alunos = service1.Listar();

service1.Adicionar(aluno1);
service1.Adicionar(aluno2);
service1.Adicionar(aluno3);

int Id = 2;
Aluno editarAluno = new Aluno();
editarAluno.Nome = "Psg";
editarAluno.Idade = 17;
editarAluno.Peso = 55;
service1.Editar(Id, editarAluno);

service.Listar();
foreach (Aluno a in alunos)
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine($"id: {a.Id}" +
                     $"\nNome do Aluno: {a.Nome}" +
                     $"\nIdade : {a.Idade}" +
                     $"\nPeso :{a.Peso}");
}


//Cidade 
CidadeService service2 = new CidadeService(contex);

Cidade cidade1 = new Cidade()
{
    Id = 1,
   NomeCidade = "Sabará",
    NumHabitantes =  1000,

};
Cidade cidade2 = new Cidade()
{
    Id = 2,
    NomeCidade = "Caete",
    NumHabitantes = 1000,
};
Cidade cidade3 = new Cidade()
{
    Id = 3,
    NomeCidade = "Nova Lima",
    NumHabitantes = 1000,
};

service2.Adicionar(cidade1);
service2.Adicionar(cidade2);
service2.Adicionar(cidade3);
List<Cidade> cidades = service2.Listar();

int ID = 3;
Cidade editarCidade = new Cidade();
editarCidade.NomeCidade = "Belo Horizonte";
editarCidade.NumHabitantes = 17000;
service2.Editar(ID, editarCidade);

service.Listar();
foreach (Cidade c in cidades)
{
    Console.WriteLine("---------------------------------");
    Console.WriteLine($"id: {c.Id}" +
                     $"\nNome da Cidade: {c.NomeCidade}" +
                     $"\nNumero de Habotantes: {c.NumHabitantes}");
}
