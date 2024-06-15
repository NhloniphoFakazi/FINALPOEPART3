using System.Collections.Generic;  // Import necessary namespaces
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace POEPART3  // Define the namespace for the project
{
    public partial class ViewRecipe : Window  // Define the ViewRecipe class, which inherits from Window
    {
        private RecipeManager recipeManager;  // Declare a private field for the RecipeManager
        private List<Recipe> displayedRecipes;  // List to store the recipes currently displayed

        public ViewRecipe(RecipeManager manager)  // Constructor for ViewRecipe
        {
            InitializeComponent();  // Initialize the components (UI elements)
            recipeManager = manager;  // Assign the RecipeManager passed as parameter
            LoadRecipes(manager.GetRecipes());  // Load and display recipes
        }

        // Method to load recipes into the list
        public void LoadRecipes(List<Recipe> recipes)
        {
            displayedRecipes = recipes;  // Store the recipes in displayedRecipes list
            lstRecipes.Items.Clear();  // Clear any existing items in the list box
            foreach (var recipe in recipes)  // Add each recipe to the list box
            {
                lstRecipes.Items.Add(recipe.DishName);
            }
        }

        // Event handler for the selection change in the recipes list
        private void lstRecipes_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int selectedIndex = lstRecipes.SelectedIndex;  // Get the selected index
            if (selectedIndex >= 0 && selectedIndex < displayedRecipes.Count)  // Check if the selected index is valid
            {
                Recipe selectedRecipe = displayedRecipes[selectedIndex];  // Get the selected recipe
                txtRecipeDetails.Text = selectedRecipe.ToString();  // Display the recipe details
            }
        }

        // Event handler for the 'Home' button click event
        private void Home_Click1(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();  // Create a new instance of MainWindow
            mainWindow.Show();  // Show the MainWindow
            this.Close();  // Close the current ViewRecipe window
        }

        // Event handler for the 'Add Recipe' button click event
        private void AddRecipe_Click2(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe(recipeManager);  // Create a new instance of AddRecipe window, passing the RecipeManager
            addRecipe.Show();  // Show the AddRecipe window
            this.Close();  // Close the current ViewRecipe window
        }

        // Event handler for the 'Scale Recipes' button click event
        private void ScaleRecipes_Click3(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipe = new ScaleRecipe(recipeManager);  // Create a new instance of ScaleRecipe window, passing the RecipeManager
            scaleRecipe.Show();  // Show the ScaleRecipe window
            this.Close();  // Close the current ViewRecipe window
        }

        // Event handler for text change in the search box
        private void txtSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            string searchText = txtSearch.Text.ToLower();  // Get the search text and convert to lower case
            List<Recipe> filteredRecipes = recipeManager.GetRecipes()  // Filter the recipes based on the search text
                .Where(recipe => recipe.Ingredients
                    .Any(ingredient => ingredient.ToLower().Contains(searchText)))
                .ToList();
            LoadRecipes(filteredRecipes);  // Load the filtered recipes
        }

        // Event handler for the 'Delete Recipe' button click event
        private void DeleteRecipe_Click(object sender, RoutedEventArgs e)
        {
            if (lstRecipes.SelectedIndex < 0 || lstRecipes.SelectedIndex >= displayedRecipes.Count)  // Check if a recipe is selected
            {
                MessageBox.Show("Please select a recipe to delete.");  // Show a message if no recipe is selected
                return;
            }

            Recipe selectedRecipe = displayedRecipes[lstRecipes.SelectedIndex];  // Get the selected recipe
            ConfirmDeleteWindow confirmDeleteWindow = new ConfirmDeleteWindow(recipeManager, selectedRecipe, this);  // Create a new instance of ConfirmDeleteWindow
            confirmDeleteWindow.ShowDialog();  // Show the ConfirmDeleteWindow as a dialog
        }

        // Method to refresh the displayed recipes
        public void RefreshRecipes()
        {
            LoadRecipes(recipeManager.GetRecipes());  // Reload and display recipes from the RecipeManager
        }
    }
}
