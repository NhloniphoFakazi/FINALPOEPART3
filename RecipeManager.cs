using System.Collections.Generic; // Import necessary namespaces

namespace POEPART3 // Define the namespace for the project
{
    public class RecipeManager // Define the RecipeManager class
    {
        private List<Recipe> recipes; // Declare a private field for storing the list of recipes

        public RecipeManager() // Constructor for RecipeManager
        {
            recipes = new List<Recipe>(); // Initialize the recipes list
            InitializeBasicRecipes(); // Call method to add basic recipes
            SortRecipesAlphabetically(); // Call method to sort recipes alphabetically
        }

        // Method to initialize basic recipes
        private void InitializeBasicRecipes()
        {
            var basicRecipes = new List<Recipe> // Create a list of basic recipes
            {
                new Recipe // Add a Pasta recipe
                {
                    DishName = "Pasta",
                    Ingredients = new List<string> { "Pasta", "Tomato Sauce", "Cheese" },
                    Quantities = new List<double> { 200, 100, 50 },
                    Units = new List<string> { "g", "ml", "g" },
                    Calories = new List<double> { 300, 150, 200 },
                    FoodGroups = new List<string> { "Grains", "Vegetables", "Dairy" },
                    Steps = new List<string> { "Boil pasta", "Heat sauce", "Combine and serve" }
                },
                new Recipe // Add a Chicken Salad recipe
                {
                    DishName = "Chicken Salad",
                    Ingredients = new List<string> { "Chicken Breast", "Lettuce", "Tomatoes", "Cucumbers", "Olive Oil", "Salt", "Pepper" },
                    Quantities = new List<double> { 200, 100, 50, 50, 10, 5, 2 },
                    Units = new List<string> { "g", "g", "g", "g", "ml", "g", "g" },
                    Calories = new List<double> { 220, 15, 10, 8, 90, 0, 0 },
                    FoodGroups = new List<string> { "Protein", "Vegetables", "Vegetables", "Vegetables", "Fats", "Seasoning", "Seasoning" },
                    Steps = new List<string> { "Cook chicken breast", "Chop vegetables", "Mix ingredients", "Season with olive oil, salt, and pepper", "Serve chilled" }
                },
                new Recipe // Add a Fruit Smoothie recipe
                {
                    DishName = "Fruit Smoothie",
                    Ingredients = new List<string> { "Banana", "Strawberries", "Greek Yogurt", "Honey", "Milk" },
                    Quantities = new List<double> { 1, 150, 100, 20, 200 },
                    Units = new List<string> { "pcs", "g", "g", "ml", "ml" },
                    Calories = new List<double> { 105, 50, 59, 64, 42 },
                    FoodGroups = new List<string> { "Fruits", "Fruits", "Dairy", "Sweeteners", "Dairy" },
                    Steps = new List<string> { "Peel and chop banana", "Wash and hull strawberries", "Combine all ingredients in blender", "Blend until smooth", "Serve immediately" }
                },
                new Recipe // Add an Omelette recipe
                {
                    DishName = "Omelette",
                    Ingredients = new List<string> { "Eggs", "Milk", "Salt", "Pepper", "Butter" },
                    Quantities = new List<double> { 3, 50, 2, 1, 10 },
                    Units = new List<string> { "pcs", "ml", "g", "g", "g" },
                    Calories = new List<double> { 210, 42, 0, 0, 72 },
                    FoodGroups = new List<string> { "Protein", "Dairy", "Seasoning", "Seasoning", "Fats" },
                    Steps = new List<string> { "Beat eggs with milk, salt, and pepper", "Heat butter in a pan", "Pour egg mixture into pan", "Cook until set, then fold", "Serve warm" }
                },
                new Recipe // Add a Vegetable Stir Fry recipe
                {
                    DishName = "Vegetable Stir Fry",
                    Ingredients = new List<string> { "Broccoli", "Carrots", "Bell Peppers", "Soy Sauce", "Olive Oil", "Garlic", "Ginger" },
                    Quantities = new List<double> { 200, 100, 100, 30, 10, 5, 5 },
                    Units = new List<string> { "g", "g", "g", "ml", "ml", "g", "g" },
                    Calories = new List<double> { 55, 41, 40, 10, 90, 4, 5 },
                    FoodGroups = new List<string> { "Vegetables", "Vegetables", "Vegetables", "Seasoning", "Fats", "Seasoning", "Seasoning" },
                    Steps = new List<string> { "Chop vegetables", "Heat oil in a pan", "Add garlic and ginger, stir fry for 1 minute", "Add vegetables and stir fry for 5-7 minutes", "Add soy sauce and cook for another 2 minutes", "Serve hot" }
                },
                new Recipe // Add a Chocolate Cake recipe
                {
                    DishName = "Chocolate Cake",
                    Ingredients = new List<string> { "Flour", "Sugar", "Cocoa Powder", "Baking Powder", "Salt", "Eggs", "Milk", "Vegetable Oil", "Vanilla Extract" },
                    Quantities = new List<double> { 200, 150, 75, 5, 2, 2, 200, 100, 5 },
                    Units = new List<string> { "g", "g", "g", "g", "g", "pcs", "ml", "ml", "ml" },
                    Calories = new List<double> { 728, 600, 300, 0, 0, 140, 42, 884, 12 },
                    FoodGroups = new List<string> { "Grains", "Sweeteners", "Sweeteners", "Seasoning", "Seasoning", "Protein", "Dairy", "Fats", "Flavoring" },
                    Steps = new List<string> { "Preheat oven to 180°C", "Mix dry ingredients", "Add wet ingredients and mix well", "Pour into a greased cake pan", "Bake for 30-35 minutes", "Let cool before serving" }
                },
                new Recipe // Add a Beef Tacos recipe
                {
                    DishName = "Beef Tacos",
                    Ingredients = new List<string> { "Ground Beef", "Taco Shells", "Lettuce", "Tomatoes", "Cheese", "Sour Cream", "Taco Seasoning" },
                    Quantities = new List<double> { 300, 10, 100, 50, 50, 50, 20 },
                    Units = new List<string> { "g", "pcs", "g", "g", "g", "g", "g" },
                    Calories = new List<double> { 750, 100, 15, 10, 200, 60, 60 },
                    FoodGroups = new List<string> { "Protein", "Grains", "Vegetables", "Vegetables", "Dairy", "Dairy", "Seasoning" },
                    Steps = new List<string> { "Cook ground beef with taco seasoning", "Prepare taco shells", "Chop lettuce and tomatoes", "Assemble tacos with beef, lettuce, tomatoes, cheese, and sour cream", "Serve immediately" }
                }
            };

            recipes.AddRange(basicRecipes); // Add the basic recipes to the recipes list
        }

        public List<Recipe> GetRecipes() // Method to get the list of recipes
        {
            return recipes; // Return the list of recipes
        }

        public void AddRecipe(Recipe recipe) // Method to add a new recipe
        {
            recipes.Add(recipe); // Add the new recipe to the recipes list
            SortRecipesAlphabetically(); // Sort the recipes alphabetically
        }

        public void DeleteRecipe(Recipe recipe) // Method to delete a recipe
        {
            recipes.Remove(recipe); // Remove the recipe from the recipes list
            SortRecipesAlphabetically(); // Sort the remaining recipes alphabetically
        }

        // Method to sort recipes alphabetically by dish name
        private void SortRecipesAlphabetically()
        {
            recipes = recipes.OrderBy(r => r.DishName).ToList(); // Sort and update the recipes list
        }
    }
}
