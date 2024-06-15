using System;  // Import necessary namespaces
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace POEPART3  // Define the namespace for the project
{
    public partial class AddRecipe : Window  // Define the AddRecipe class, which inherits from Window
    {
        private RecipeManager recipeManager;  // Declare a private field for the RecipeManager
        private List<string> ingredients = new List<string>();  // List to store ingredients
        private List<double> quantities = new List<double>();  // List to store quantities of ingredients
        private List<string> units = new List<string>();  // List to store units of measurement for ingredients
        private List<double> calories = new List<double>();  // List to store calories for each ingredient
        private List<string> foodGroups = new List<string>();  // List to store food groups for each ingredient

        public AddRecipe(RecipeManager manager)  // Constructor for AddRecipe
        {
            InitializeComponent();  // Initialize the components (UI elements)
            recipeManager = manager;  // Assign the RecipeManager passed as parameter
        }

        // Event handler for the 'Cancel' button click event
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  // Create a new instance of MainWindow
            mainWindow.Show();  // Show the MainWindow
            this.Close();  // Close the current AddRecipe window
        }

        // Event handler for the 'Add Ingredient' button click event
        private void btnAddIngredient_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string ingredient = txtIngredient.Text;  // Get the ingredient name from the input field
                double quantity = double.Parse(txtQuantity.Text);  // Parse the quantity from the input field
                string unit = txtUnit.Text;  // Get the unit from the input field
                double cal = double.Parse(txtCalories.Text);  // Parse the calories from the input field
                string foodGroup = ((ComboBoxItem)cmbFoodGroup.SelectedItem).Content.ToString();  // Get the selected food group from the ComboBox

                // Add the ingredient details to the respective lists
                ingredients.Add(ingredient);
                quantities.Add(quantity);
                units.Add(unit);
                calories.Add(cal);
                foodGroups.Add(foodGroup);

                // Display the added ingredient in the list box
                lstIngredients.Items.Add($"{ingredient} - {quantity} {unit} - {cal} calories - {foodGroup}");

                // Clear input fields after adding the ingredient
                txtIngredient.Clear();
                txtQuantity.Clear();
                txtUnit.Clear();
                txtCalories.Clear();
                cmbFoodGroup.SelectedIndex = -1;
            }
            catch (FormatException ex)  // Catch format exceptions and show an error message
            {
                MessageBox.Show($"Input error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the 'Save' button click event
        private void btnSave_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string dishName = txtDishName.Text;  // Get the dish name from the input field
                string stepsText = txtSteps.Text;  // Get the steps from the input field

                // Create a new Recipe object and set its properties
                Recipe recipe = new Recipe
                {
                    DishName = dishName,
                    Ingredients = new List<string>(ingredients),
                    Quantities = new List<double>(quantities),
                    Units = new List<string>(units),
                    Calories = new List<double>(calories),
                    FoodGroups = new List<string>(foodGroups),
                    Steps = new List<string> { stepsText }
                };

                recipeManager.AddRecipe(recipe);  // Add the recipe to the RecipeManager

                MessageBox.Show("Recipe added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                // Clear all fields and lists after saving the recipe
                txtDishName.Clear();
                txtSteps.Clear();
                lstIngredients.Items.Clear();
                ingredients.Clear();
                quantities.Clear();
                units.Clear();
                calories.Clear();
                foodGroups.Clear();
            }
            catch (FormatException ex)  // Catch format exceptions and show an error message
            {
                MessageBox.Show($"Input error: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Event handler for the 'View Recipes' button click event
        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe viewRecipeWindow = new ViewRecipe(recipeManager);  // Create a new instance of ViewRecipe window, passing the RecipeManager
            viewRecipeWindow.Show();  // Show the ViewRecipe window
            this.Close();  // Close the current AddRecipe window
        }

        // Event handler for the 'Scale Recipes' button click event
        private void ScaleRecipes_Click_1(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipe = new ScaleRecipe(recipeManager);  // Create a new instance of ScaleRecipe window, passing the RecipeManager
            scaleRecipe.Show();  // Show the ScaleRecipe window
            this.Close();  // Close the current AddRecipe window
        }

        // Event handler for the 'Home' button click event
        private void Home_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  // Create a new instance of MainWindow
            mainWindow.Show();  // Show the MainWindow
            this.Close();  // Close the current AddRecipe window
        }
    }
}
