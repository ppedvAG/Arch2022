// See https://aka.ms/new-console-template for more information
using Autofac;
using ppedv.BooksManager.Contracts;
using ppedv.BooksManager.Data.Ef;
using ppedv.BooksManager.Logic;
using ppedv.BooksManager.Model;
using System.Reflection;
using Unity;

Console.WriteLine("*** BooksManager v0.1 PREMIUM EDITION ***");

//DI direkt per Referenz
//var bms = new BooksManagerService(new EfUnitOfWork());

//DI manuell per reflection
//var filePath = @"C:\Users\Fred\source\repos\ppedvAG\Arch2022\ppedv.BooksManager\ppedv.BooksManager.Data.Ef\bin\Debug\net6.0\ppedv.BooksManager.Data.Ef.dll";
//var ass = Assembly.LoadFrom(filePath);
//var firstTypeWithRepo = ass.GetTypes().FirstOrDefault(x => x.GetInterfaces().Contains(typeof(IUnitOfWork)));
//var repo = (IUnitOfWork)Activator.CreateInstance(firstTypeWithRepo);
//var bms = new BooksManagerService(repo);

//DI per AutoFac
var builder = new ContainerBuilder();
//builder.RegisterType<EfRepository>().AsImplementedInterfaces();
//builder.RegisterType<EfUnitOfWork>().As<IUnitOfWork>();
//var cont = builder.Build();
//var bms = new BooksManagerService(cont.Resolve<IUnitOfWork>());

//DI per Unity IOC
IUnityContainer container = new UnityContainer();
container.RegisterType<IUnitOfWork, EfUnitOfWork>();
var bms = new BooksManagerService(container.Resolve<IUnitOfWork>());


foreach (var b in bms.UnitOfWork.BooksRepository.Query().Where(x => x.Published.Year < 5000).OrderBy(x => x.Title.Length))
{
    Console.WriteLine($"{b.Title} {b.Published:d}");
}

var verlag = bms.GetPublisherWithMostExpensivesBooks();
Console.WriteLine($"Der Verlag {verlag?.Name} hat in Summe die teuersten Bücher");
