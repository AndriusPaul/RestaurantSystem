using Newtonsoft.Json;
using RestaurantSystem.Entity;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestaurantSystem.Repositories
{
    public class TableRepository
    {
        private List<Table> tables;
          public TableRepository()
        {
            tables = new List<Table>();
          
        }

        public void CreateJSON()
        {
            var jsonList = JsonConvert.SerializeObject(tables, Formatting.Indented);
            var filePath = @"./Tables.json";
            File.WriteAllText(filePath, jsonList);
        }
        public string ReadJSON()
        {
            string json;
            using (StreamReader jsonfile = new StreamReader(@"./Tables.json"))
            {
               json = jsonfile.ReadToEnd();
                tables = JsonSerializer.Deserialize<List<Table>>(json);
            }

            if(tables == null && tables.Count < 0)
            {
                Console.WriteLine("tables.json file is empty");
            }else
            {
                foreach (var table in tables)
                {
                    if(table.IsFree == true)
                    {
                        Console.WriteLine($"{table.Id}. {table.Name}, Seats: {table.Seats} - Free");
                    }
                    else
                    {
                        Console.WriteLine($"{table.Id}. {table.Name}, Seats: {table.Seats} - Not Free");
                    }
                    
                }
            }
            return json;
        }
        public string Read()
        {
            string json;
            using (StreamReader jsonfile = new StreamReader(@"./Tables.json"))
            {
                json = jsonfile.ReadToEnd();
                tables = JsonSerializer.Deserialize<List<Table>>(json);
            }

            if (tables == null && tables.Count < 0)
            {
                Console.WriteLine("tables.json file is empty");
            }
            return json;
        }
        public string GetFreeTables()
        {
            string json;
            using (StreamReader jsonfile = new StreamReader(@"./Tables.json"))
            {
                json = jsonfile.ReadToEnd();
                tables = JsonSerializer.Deserialize<List<Table>>(json);
            }
            if (tables == null && tables.Count < 0)
            {
                Console.WriteLine("tables.json file is empty");
            }
            else
            {
                foreach (var table in tables)
                {
                    if (table.IsFree == true)
                    {
                        Console.WriteLine($"{table.Id}. {table.Name}, Seats: {table.Seats} - Free");
                    }
                   

                }
            }
                return json;
        }
        
        public List<Table> GetTables()
        {
            return tables;
        }
        public Table Retrieve(int tableId)
        {
            return tables.SingleOrDefault(x => x.Id == tableId);
        }
        public bool GetTableStatus()
        {
            foreach (var table in tables)
            {
                if(table.IsFree == true)
                {
                    return table.IsFree;
                }

            }
            return false;
        }
    }
}
