using System;  // Import necessary namespaces
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POEPART3  // Define the namespace for the project
{
    public partial class ScaleRecipe : Window  // Define the ScaleRecipe class, which inherits from Window
    {
        private RecipeManager recipeManager;  // Declare a private field for the RecipeManager

        public ScaleRecipe(RecipeManager manager)  // Constructor for ScaleRecipe
        {
            InitializeComponent();  // Initialize the components (UI elements)
            recipeManager = manager;  // Assign the RecipeManager passed as parameter
            LoadRecipes();  // Load the recipes into the combo box
        }

        // Event handler for the 'Home' button click event
        private void Home_Click3(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  // Create a new instance of MainWindow
            mainWindow.Show();  // Show the MainWindow
            this.Close();  // Close the current ScaleRecipe window
        }

        // Event handler for the 'Add Recipe' button click event
        private void AddRecipe_Click4(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe(recipeManager);  // Create a new instance of AddRecipe window, passing the RecipeManager
            addRecipe.Show();  // Show the AddRecipe window
            this.Close();  // Close the current ScaleRecipe window
        }

        // Event handler for the 'View Recipes' button click event
        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe viewRecipe = new ViewRecipe(recipeManager);  // Create a new instance of ViewRecipe window, passing the RecipeManager
            viewRecipe.Show();  // Show the ViewRecipe window
            this.Close();  // Close the current ScaleRecipe window
        }

        // Event handler for the 'Scale' button click event
        private void btnScale_Click(object sender, RoutedEventArgs e)
        {
            if (cmbRecipes.SelectedItem == null || string.IsNullOrWhiteSpace(txtScalingFactor.Text))  // Check if a recipe is selected and scaling factor is entered
            {
                MessageBox.Show("Please select a recipe and enter a scaling factor.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);  // Show error message if not
                return;
            }

            try
            {
                string selectedRecipeName = cmbRecipes.SelectedItem.ToString();  // Get the selected recipe name
                Recipe selectedRecipe = recipeManager.GetRecipes().FirstOrDefault(r => r.DishName == selectedRecipeName);  // Get the selected recipe
                double scalingFactor = double.Parse(txtScalingFactor.Text);  // Parse the scaling factor

                var scaledIngredients = selectedRecipe.Ingredients  // Scale the ingredients based on the scaling factor
                    .Select((ingredient, index) => new ScaledIngredient
                    {
                        Ingredient = ingredient,
                        Quantity = selectedRecipe.Quantities[index] * scalingFactor,
                        Unit = selectedRecipe.Units[index]
                    })
                    .ToList();

                lvScaledRecipe.ItemsSource = scaledIngredients;  // Display the scaled ingredients in the list view
            }
            catch (FormatException)  // Catch format exceptions and show an error message
            {
                MessageBox.Show("Scaling factor must be a valid number.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        // Method to load recipes into the combo box
        private void LoadRecipes()
        {
            cmbRecipes.Items.Clear();  // Clear existing items in the combo box
            foreach (var recipe in recipeManager.GetRecipes())  // Add each recipe to the combo box
            {
                cmbRecipes.Items.Add(recipe.DishName);
            }
        }

        // Event handler for the selection change in the recipes combo box
        private void cmbRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            lvScaledRecipe.ItemsSource = null;  // Clear the list view when a new recipe is selected
        }

        // Event handler for the 'Cancel' button click event
        private void btnCancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  // Create a new instance of MainWindow
            mainWindow.Show();  // Show the MainWindow
            this.Close();  // Close the current ScaleRecipe window
        }

        // Define a class to represent scaled ingredients
        private class ScaledIngredient
        {
            public string Ingredient { get; set; }  // Ingredient name
            public double Quantity { get; set; }  // Scaled quantity
            public string Unit { get; set; }  // Unit of measurement
        }
    }
}
