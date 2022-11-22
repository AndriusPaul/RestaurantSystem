using Newtonsoft.Json;
using RestaurantSystem.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using Formatting = Newtonsoft.Json.Formatting;

namespace RestaurantSystem.Repositories
{
    public class TableRepository
    {
        private List<Table> tables;
        private string FileName;

        public TableRepository()
        {
            tables = new List<Table>();
            tables.Add(new Table(1, "TBL1", true));
            tables.Add(new Table(2, "TBL2", true));
            tables.Add(new Table(3, "TBL3", false ));
            tables.Add(new Table(4, "TBL4", true ));

        }

        public void CreateJSON()
        {
            var jsonList = JsonConvert.SerializeObject(tables, Formatting.Indented);
            var filePath = @"./Tables.json";
            File.WriteAllText(filePath, jsonList);
        }
        public string ReadJSON()
        {
            string text = File.ReadAllText(@"./Tables.json");
            return JsonSerializer.Deserialize(text);
        }
        public List<Table> GetTable()
        {
            return tables;
        }
    }
}
