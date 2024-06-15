using System.Windows;

namespace POEPART3
{
    public partial class ConfirmDeleteWindow : Window
    {
        private RecipeManager recipeManager;
        private Recipe recipeToDelete;
        private ViewRecipe parentView;

        public ConfirmDeleteWindow(RecipeManager manager, Recipe recipe, ViewRecipe parent)
        {
            InitializeComponent();
            recipeManager = manager;
            recipeToDelete = recipe;
            parentView = parent;
        }

        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            recipeManager.GetRecipes().Remove(recipeToDelete);
            parentView.RefreshRecipes();
            this.Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
