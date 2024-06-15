using System.Collections.Generic; // Import necessary namespaces
using System.Text; // Import StringBuilder for efficient string manipulation

namespace POEPART3 // Define the namespace for the project
{
    public class Recipe // Define the Recipe class
    {
        // Properties of the Recipe class
        public string DishName { get; set; } // Name of the dish
        public List<string> Ingredients { get; set; } // List of ingredients
        public List<double> Quantities { get; set; } // Corresponding quantities of ingredients
        public List<string> Units { get; set; } // Units for each quantity
        public List<double> Calories { get; set; } // Caloric content of each ingredient
        public List<string> FoodGroups { get; set; } // Food groups for each ingredient
        public List<string> Steps { get; set; } // Steps to prepare the dish

        // Override the ToString method to provide a formatted string representation of the Recipe object
        public override string ToString()
        {
            // Use StringBuilder for efficient string concatenation
            StringBuilder sb = new StringBuilder();

            // Append the dish name
            sb.AppendLine($"Dish Name: {DishName}");

            // Append the ingredients and their details
            sb.AppendLine("Ingredients:");
            for (int i = 0; i < Ingredients.Count; i++)
            {
                sb.AppendLine($"{Ingredients[i]} - {Quantities[i]} {Units[i]}");
            }

            // Append the preparation steps
            sb.AppendLine("Steps:");
            foreach (var step in Steps)
            {
                sb.AppendLine(step);
            }

            // Return the constructed string
            return sb.ToString();
        }
    }
}
