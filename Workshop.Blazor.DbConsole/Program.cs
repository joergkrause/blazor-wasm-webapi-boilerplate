// See https://aka.ms/new-console-template for more information
using Microsoft.EntityFrameworkCore;
using Workshop.Blazor.DataAccessLayer;
using Workshop.Blazor.DomainModels;

Console.WriteLine("Database Setup");

var optionsBuilder = new DbContextOptionsBuilder<EventDatabaseContext>();
optionsBuilder.UseSqlServer(@"Data Source=(localdb)\BlazorWorkshop;Initial Catalog=EventDatabase;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

using var context = new EventDatabaseContext(optionsBuilder.Options);

Console.WriteLine("Delete Database");
context.Database.EnsureDeleted();
Console.WriteLine("Create Database");
context.Database.EnsureCreated();

var evt = new Event {
    Name = "Blazor Workshop",
    Description = "Alles über Blazor",
    Begin = new DateTime(2021, 11, 23),
    End = new DateTime(2021, 11, 25),
    StartTime = new DateTime(2021, 11, 23, 9, 0, 0)
};

context.Seats.Add(new Seat { Event = evt, Price = 100m, Row = 1, Number = 1 });
context.Seats.Add(new Seat { Event = evt, Price = 100m, Row = 1, Number = 2 });
context.Seats.Add(new Seat { Event = evt, Price = 80m, Row = 2, Number = 3 });
context.Seats.Add(new Seat { Event = evt, Price = 80m, Row = 2, Number = 3 });

context.SaveChanges();

Console.WriteLine("Done");
