using Newtonsoft.Json;
using RestaurantSystem.Classes;

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

            if(tables != null && tables.Count > 0)
            {
                foreach (var item in tables)
                {
                    Console.WriteLine($"{item.Id}. Table: {item.Name}, Seats: {item.Seats}, is free: {item.IsFree}");
                }
            }
            return json;
        }
        public List<Table> GetTable()
        {
            return tables;
        }
        public Table Retrieve(int tableId)
        {
            return tables.SingleOrDefault(x => x.Id == tableId);
        }
    }
}
