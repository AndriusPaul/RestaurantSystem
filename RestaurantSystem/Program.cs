using RestaurantSystem.Repositories;

var tables = new TableRepository();

tables.CreateJSON();
Console.WriteLine("Json Created");
foreach (var table in tables.GetTable())
{
    Console.WriteLine($"{table.Id}. {table.Name} - {table.Status}");
  
}
