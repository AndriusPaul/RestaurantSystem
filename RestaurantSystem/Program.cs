using RestaurantSystem.Classes;
using RestaurantSystem.Repositories;



FoodRepository foodRepository = new FoodRepository();
foodRepository.ReadJSON();

DrinkRepository drinkRepository = new DrinkRepository();
drinkRepository.ReadJSON();

TableRepository table = new TableRepository();
table.ReadJSON();