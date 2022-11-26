using RestaurantSystem.Repositories;

var tables = new TableRepository();
tables.ReadJSON();



Console.WriteLine("Pakeisti staliuko statusa:");
Console.WriteLine("Select table:");
var select = int.Parse(Console.ReadLine());
    switch (select)
    {
        case 1:
            Console.WriteLine($"You selected: {tables.Retrieve(select).Id}. {tables.Retrieve(select).Name}, status: {tables.Retrieve(select).IsFree}");
            Console.WriteLine("Do you want to change status ? Press 1 to change status");
            int select2 = int.Parse(Console.ReadLine());
            if (select2 == 1)
            {
                if( tables.Retrieve(select).IsFree == true)
            {
                tables.Retrieve(select).IsFree = false;
            }else
            {
                tables.Retrieve(select).IsFree = true;
            }
                
                tables.CreateJSON();
            Console.WriteLine($"Table status changed to {tables.Retrieve(select).IsFree}");

        }
            break;
        case 2:
            Console.WriteLine($"You selected: {tables.Retrieve(select).Id}. {tables.Retrieve(select).Name}, isFree: {tables.Retrieve(select).IsFree}");
            break;
        case 3:
            Console.WriteLine($"You selected: {tables.Retrieve(select).Id}. {tables.Retrieve(select).Name}, isFree: {tables.Retrieve(select).IsFree}");
            break;
        case 4:
            Console.WriteLine($"You selected: {tables.Retrieve(select).Id}. {tables.Retrieve(select).Name}, isFree: {tables.Retrieve(select).IsFree}");
            break;
        default:
            Console.WriteLine($"There are only {tables.GetTable().Count()} tables");
            break;
    }

