﻿// See https://aka.ms/new-console-template for more information
using System.Data.Common;

Console.WriteLine("Hello, World!");

string conString = "";
DbProviderFactory factory = null;

if ("Sql" == "Sql")
{
    factory = Microsoft.Data.SqlClient.SqlClientFactory.Instance;
    conString = "Server=(localdb)\\mssqllocaldb;Database=Northwnd;Trusted_Connection=true";
}
else //postgres
{
    factory = Npgsql.NpgsqlFactory.Instance;
    conString = "INSERT HERE ConString 4 Postgres";
}

DbConnection con = factory.CreateConnection();
con.ConnectionString = conString;
con.Open();

DbCommand cmd = factory.CreateCommand();
cmd.Connection = con;
cmd.CommandText = "SELECT * FROM Employees";
DbDataReader reader = cmd.ExecuteReader();

while (reader.Read())
{
    Console.WriteLine($"{reader.GetString(reader.GetOrdinal("FirstName"))}");
}

