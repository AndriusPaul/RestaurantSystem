using Newtonsoft.Json;
using RestaurantSystem.Classes;
using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestaurantSystem.Repositories
{
    public class DrinkRepository
    {
        private List<Drink> drinks;

        public DrinkRepository()
        {
            drinks = new List<Drink>();
            }
            public void CreateJSON()
            {
                var jsonList = JsonConvert.SerializeObject(drinks, Formatting.Indented);
                var filePath = @"./Drinks.json";
                File.WriteAllText(filePath, jsonList);
            }
            public string ReadJSON()
            {
                string json;
                using (StreamReader jsonfile = new StreamReader(@"./Drinks.json"))
                {
                    json = jsonfile.ReadToEnd();
                    drinks = JsonSerializer.Deserialize<List<Drink>>(json);
                }

                if (drinks == null && drinks.Count < 0)
                {
                Console.WriteLine("drink.json file is empty");
            }
            else
            {
                foreach (var drink in drinks)
                {
                    Console.WriteLine($"{drink.Id}. {drink.Name} - {drink.Price}");
                }
            }
                return json;
            }
            public List<Drink> GetDrinks()
            {
                return drinks;
            }
        }
    }
