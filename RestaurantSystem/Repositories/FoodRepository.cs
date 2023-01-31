

using Newtonsoft.Json;
using RestaurantSystem.Classes;

using Formatting = Newtonsoft.Json.Formatting;
using JsonSerializer = System.Text.Json.JsonSerializer;

namespace RestaurantSystem.Repositories
{
    public class FoodRepository
    {
        private List<Food> foods;

        public FoodRepository()
        {
            foods = new List<Food>();
        }
            
        public void CreateJSON()
        {
            var jsonList = JsonConvert.SerializeObject(foods, Formatting.Indented);
            var filePath = @"./Foods.json";
            File.WriteAllText(filePath, jsonList);
        }
       public string ReadJSON()
        {
            string json;
            using (StreamReader jsonfile = new StreamReader(@"./Foods.json"))
            {
                json = jsonfile.ReadToEnd();
                foods = JsonSerializer.Deserialize<List<Food>>(json);
            }

            if (foods == null && foods.Count < 0)
            {
                Console.WriteLine("food.json file is empty");
            }else
            {

                foreach (var food in foods)
                {
                    Console.WriteLine($"{food.Id}. {food.Name} - {food.Price}");
                }
            }
            return json;
        }

   
       public List<Food> GetFoods()
        {
            return foods;
        }

        public Food RetrieveById(int foodId)
        {
            return foods.SingleOrDefault(x => x.Id == foodId);
        }
    }
}
