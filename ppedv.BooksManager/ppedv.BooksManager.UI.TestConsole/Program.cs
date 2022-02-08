// See https://aka.ms/new-console-template for more information
using ppedv.BooksManager.Data.Ef;
using ppedv.BooksManager.Logic;

Console.WriteLine("*** BooksManager v0.1 PREMIUM EDITION ***");


var bms = new BooksManagerService(new EfRepository());

var verlag = bms.GetPublisherWithMostExpensivesBooks();
Console.WriteLine($"Der Verlag {verlag?.Name} hat in Summe die teuersten Bücher");
