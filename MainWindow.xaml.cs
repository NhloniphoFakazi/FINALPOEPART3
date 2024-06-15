using System.Windows;  // Import the necessary namespaces

namespace POEPART3  // Define the namespace for the project
{
    public partial class MainWindow : Window  // Define the MainWindow class, which inherits from Window
    {
        private RecipeManager recipeManager;  // Declare a private field for the RecipeManager

        public MainWindow()  // Constructor for MainWindow
        {
            InitializeComponent();  // Initialize the components (UI elements)
            recipeManager = new RecipeManager();  // Instantiate the RecipeManager
        }

        // Event handler for the 'View Recipes' button click event
        private void btnViewRecipes_Click(object sender, RoutedEventArgs e)
        {
            ViewRecipe viewRecipe = new ViewRecipe(recipeManager);  // Create a new instance of the ViewRecipe window, passing the RecipeManager
            viewRecipe.Show();  // Show the ViewRecipe window
            this.Close();  // Close the current MainWindow
        }

        // Event handler for the 'Add Recipe' button click event
        private void btnAddRecipe_Click(object sender, RoutedEventArgs e)
        {
            AddRecipe addRecipe = new AddRecipe(recipeManager);  // Create a new instance of the AddRecipe window, passing the RecipeManager
            addRecipe.Show();  // Show the AddRecipe window
            this.Close();  // Close the current MainWindow
        }

        // Event handler for the 'Scale Recipe' button click event
        private void btnScaleRecipe_Click(object sender, RoutedEventArgs e)
        {
            ScaleRecipe scaleRecipe = new ScaleRecipe(recipeManager);  // Create a new instance of the ScaleRecipe window, passing the RecipeManager
            scaleRecipe.Show();  // Show the ScaleRecipe window
            this.Close();  // Close the current MainWindow
        }

        // Event handler for the 'Exit App' button click event
        private void btnExitApp_Click(object sender, RoutedEventArgs e)
        {
            Close();  // Close the current MainWindow, effectively exiting the application
        }
    }
}
