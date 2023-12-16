// See https://aka.ms/new-console-template for more information
using IntroCSharpBackend;
using System.ComponentModel;
using System.Text.Json;

Sale sale = new Sale();
sale.Total = 0;
var sale2 = new Sale();
SaleWithTax sale3 = new(15, 1.21m);
var message = sale3.GetInfo();

Console.WriteLine(message);

var beer = new Beer();

Some(beer);
Some(sale);

var numbers = new MyList<int>(5);
var names = new MyList<string>(5);
var beers = new MyList<Beer>(3);

numbers.Add(1);
numbers.Add(2);
numbers.Add(3);
numbers.Add(4);
numbers.Add(5);
numbers.Add(6);

names.Add("Hector");
names.Add("Ana");
names.Add("Luis");
names.Add("Juan");
names.Add("Roberto");
names.Add("Karla");

beers.Add(new Beer() { Name = "Erdinger", Price = 5m });
beers.Add(new Beer() { Name = "Corona", Price = 1m });
beers.Add(new Beer() { Name = "Delirium", Price = 10m });
beers.Add(new Beer() { Name = "Paulaner", Price = 5m });

Console.WriteLine(numbers.GetContent());
Console.WriteLine(names.GetContent());
Console.WriteLine(beers.GetContent());

var eduardo = new People()
{
    Name = "Eduardo",
    Age = 50,
};
string json = JsonSerializer.Serialize(eduardo);
Console.WriteLine(json);

string myJson = @"{
    ""Name"":""Matteo"",
    ""Age"":4
}";
People? matteo = JsonSerializer.Deserialize<People>(myJson);
Console.WriteLine(matteo?.Name);
Console.WriteLine(matteo?.Age);

// 1st class function
var show = Show;
show("Hola");
void Show(string message)
{
    Console.WriteLine(message);
}

var returnSomething = ReturnSomething;
SomeFunction(returnSomething, "Hola, como estas");
string ReturnSomething(string message)
{
    return message.ToUpper();
}

// Superior order function
// Action type
// Receives elements but don't returns anything
void SomeFunction(Func<string, string> fn, string message)
{
    Console.WriteLine("Make something at start");
    Console.WriteLine(fn(message));
    Console.WriteLine("Make something at end");
}

void Some(ISave save)
{
    save.Save();
}

Func<int, int, int> add = (int a, int b) => a - b;
Func<int, int, int> sub = (a, b) => a - b;
Func<int, int> some = a => a * 2;
Func<int, int> some2 = a =>
{
    a = a + 1;
    return a;
};

// Expresiones Lambda
Some3((a, b) => a + b, 5);
void Some3(Func<int, int, int> fn, int number)
{
    var result = fn(number, number);
}

// LINQ
var names2 = new List<string>()
{
    "Hector", "Francisco", "Ana", "Hugo", "Pedro",
};
var namesResult = from n in names2
                  where n.Length > 3 && n.Length < 5
                  orderby n descending
                  select n;

var namesResult2 = names2.Where(n => n.Length > 3 && n.Length < 5)
                         .OrderByDescending(n => n)
                         .Select(d => d);
foreach(var name in namesResult)
{
    Console.WriteLine(name);
}
foreach (var name in namesResult2)
{
    Console.WriteLine(name);
}
interface ISale
{
    decimal Total { get; set; }
}

interface ISave
{
    public void Save();
}

class Sale : ISale, ISave
{
    public decimal Total { get; set; }
    private decimal _some;
    public Sale() { }
    public Sale(decimal total)
    {
        this.Total = total;
    }
    public virtual string GetInfo()
    {
        return "El Total es " + Total;
    }

    public void Save() 
    { 
        // This method must save into BD
    }

}

class SaleWithTax : Sale
{
    public decimal Tax { get; set; }
    public SaleWithTax(decimal total, decimal tax) : base(total) 
    {
        Tax = tax;
    }

    public override string GetInfo()
    {
        return "El total es " + Total + " Impuesto es: " + Tax;
    }
}

public class Beer : ISave
{
    public string Name { get; set; }
    public decimal Price { get; set; }

    public override string ToString()
    {
        return $"Name: {Name}, Price: {Price}";
    }
    public void Save()
    {
        // This method must save into an Service
    }

}


