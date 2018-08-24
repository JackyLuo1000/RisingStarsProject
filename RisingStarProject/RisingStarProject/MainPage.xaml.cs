using ProtoBuf;
using RisingStarProject.IngedientModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Text.RegularExpressions;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using static RisingStarProject.RecipeModel.Program;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private static string SearchInput;
        ObservableCollection<Recipe> recipes = new ObservableCollection<Recipe>();
        ObservableCollection<Recipe> displayRecipes = new ObservableCollection<Recipe>();
        public event PropertyChangedEventHandler PropertyChanged;
        MessageDialog showDialog;
        string mruToken = "";
        public MainPage()
        {
            this.InitializeComponent();

            lbxDisplay.ItemsSource = displayRecipes;

            Ingredient I1 = new Ingredient
            {
                Name = "Diced Tomatoes",
                Type = "Fruit",
                QTY = 1,
                Measurement = "Cup"
            };

            Ingredient I2 = new Ingredient
            {
                Name = "Sliced Jalapenos",
                Type = "Fruit",
                QTY = 0.5f,
                Measurement = "Cup"
            };

            Ingredient I3 = new Ingredient
            {
                Name = "Roasted Diced Tomatillo",
                Type = "Fruit",
                QTY = 0.25f,
                Measurement = "Cup"
            };

            Ingredient I4 = new Ingredient();
            I4.Name = "Garlic";
            I4.Type = "Vegetable";
            I4.QTY = 1;
            I4.Measurement = "Tablespoon";

            Ingredient I5 = new Ingredient();
            I5.Name = "Roasted Serrano";
            I5.Type = "Fruit";
            I5.QTY = 0.25f;
            I5.Measurement = "Cup";

            Ingredient I6 = new Ingredient();
            I6.Name = "Sliced Avocado";
            I6.Type = "Fruit";
            I6.QTY = 0.25f;
            I6.Measurement = "Cup";

            Ingredient I7 = new Ingredient();
            I7.Name = "Sliced Potato Strips";
            I7.Type = "Vegetable";
            I7.QTY = 1f;
            I7.Measurement = "Cup";

            Ingredient I8 = new Ingredient();
            I8.Name = "Salt";
            I8.Type = "Seasoning";
            I8.QTY = 2f;
            I8.Measurement = "Teaspoons";

            ObservableCollection<Ingredient> ingredients = new ObservableCollection<Ingredient>()
            {
                I1, I2, I3
            };

            ObservableCollection<Ingredient> ingredients2 = new ObservableCollection<Ingredient>()
            {
                I1, I2, I3, I4, I5, I6
            };

            ObservableCollection<Ingredient> ingredients3 = new ObservableCollection<Ingredient>()
            {
                I7, I8
            };

            recipes.Add(new Recipe { Name = "Ramen", Type = "Main Dish", Ingredients = ingredients });
            recipes.Add(new Recipe { Name = "Pot Roast", Type = "Main Dish", Ingredients = ingredients });
            recipes.Add(new Recipe { Name = "Pico De Gallo", Type = "Appetizer", Ingredients = ingredients2 });
            recipes.Add(new Recipe { Name = "French Fries", Type = "Side Dish", Ingredients = ingredients3 });
            foreach (Recipe r in recipes)
            {
                displayRecipes.Add(r);
            }
        }

        private void CreateRecipe_Tapped(object sender, TappedRoutedEventArgs e)
        {
            this.Frame.Navigate(typeof(CreateRecipe), recipes);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ObservableCollection<Recipe> && e.Parameter != null)
            {
                ObservableCollection<Recipe> oldRecipes = e.Parameter as ObservableCollection<Recipe>;
                if (oldRecipes.Count != 0)
                {
                    foreach (Recipe r in oldRecipes)
                    {
                        recipes.Add(r);
                        displayRecipes.Add(r);
                    }
                }
            }
            if (e.Parameter is Recipe && e.Parameter != null)
            {
                Recipe newRecipe = e.Parameter as Recipe;
                recipes.Add(newRecipe);
                displayRecipes.Add(newRecipe);
            }
            base.OnNavigatedTo(e);
        }

        //Search Filter.
        private void Name_Search()
        {
            Regex reg = new Regex($"{SearchInput}?.+");
            if (!reg.IsMatch(SearchInput))
            {
                showDialog = new MessageDialog("Please enter a search field.");
            }
            else
            {
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    if (reg.IsMatch(r.Name))
                    {
                        displayRecipes.Add(r);
                    }
                }
            }
        }

        //Search Filter.
        private void Ingredient_Search()
        {
            Regex reg = new Regex($"{SearchInput}?.+");
            if (!reg.IsMatch(SearchInput))
            {
                showDialog = new MessageDialog("Please enter a search field.");
            }
            else
            {
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                    foreach (var i in r.Ingredients)
                    {
                        if (reg.IsMatch(i.Name) || reg.IsMatch(i.Type))
                        {
                            displayRecipes.Add(r);
                            break;
                        }
                    }
            }
        }

        //Search Filter.
        private void Type_Search()
        {
            Regex reg = new Regex($"{SearchInput}?.+");
            if (!reg.IsMatch(SearchInput))
            {
                showDialog = new MessageDialog("Please enter a search field.");
            }
            else
            {
                displayRecipes.Clear();
                foreach (Recipe r in recipes)
                {
                    if (reg.IsMatch(r.Type))
                    {
                        displayRecipes.Add(r);
                    }
                }
            }
        }

        //Search Button Click.
        private void Search_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (cbxList.SelectedValue.ToString() == "Name")
                {
                    Name_Search();
                }
                else if (cbxList.SelectedValue.ToString() == "Type")
                {
                    Type_Search();
                }
                else if (cbxList.SelectedValue.ToString() == "Ingredient")
                {
                    Ingredient_Search();
                }
            }
            catch (Exception X)
            {
                showDialog = new MessageDialog("An error has occured: " + X);
            }
        }

        //TextBox Search-bar.
        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (SearchInput == String.Empty || SearchInput == null)
            {
                SearchInput = "Ramen";
            }
            else
            {
                SearchInput = tbxSearch.Text;
            }
        }

        void OnPropertyChanged(string s)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(s));
        }

        //Saves the all the recipes as a binary serialized .recipes file
        private async void Save_Recipes(object sender, RoutedEventArgs e)
        {
            FileSavePicker fileSavePicker = new FileSavePicker();
            fileSavePicker.FileTypeChoices.Add("Recipes", new List<string>() { ".recipes" });
            fileSavePicker.SuggestedFileName = "New Recipes";
            StorageFile file = await fileSavePicker.PickSaveFileAsync();
            if (file != null)
            {
                using (Stream fs = await file.OpenStreamForWriteAsync())
                {
                    fs.SetLength(0);
                    CachedFileManager.DeferUpdates(file);
                    Serializer.Serialize(fs, recipes);
                }
            }
        }

        //Clears recipes then loads all recipes from a binary serialized .recipes file
        private async void Load_Recipes(object sender, RoutedEventArgs e)
        {
            FileOpenPicker fileOpenPicker = new FileOpenPicker();
            fileOpenPicker.FileTypeFilter.Add(".recipes");
            StorageFile file = await fileOpenPicker.PickSingleFileAsync();
            if (file != null)
            {
                using (Stream fs = await file.OpenStreamForReadAsync())
                {
                    recipes.Clear();
                    displayRecipes.Clear();
                    foreach (Recipe recipe in Serializer.Deserialize<ObservableCollection<Recipe>>(fs))
                    {
                        recipes.Add(recipe);
                        displayRecipes.Add(recipe);
                    }
                }
            }
        }

        private async void Add_Grocery(object sender, RoutedEventArgs e)
        {
            if (lbxDisplay.SelectedIndex >= 0 && lbxDisplay.SelectedIndex < displayRecipes.Count)
            {
                var mru = Windows.Storage.AccessCache.StorageApplicationPermissions.MostRecentlyUsedList;
                if (mruToken != null && mruToken != "")
                {
                    StorageFile file = await mru.GetFileAsync(mruToken);
                    string text = "";
                    if (file != null)
                    {
                        using (Stream fs = await file.OpenStreamForReadAsync())
                        {
                            using (StreamReader sr = new StreamReader(fs))
                            {
                                text = await sr.ReadToEndAsync();
                            }
                        }
                        using (Stream fs = await file.OpenStreamForWriteAsync())
                        {
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                await sw.WriteAsync(text);
                                await sw.WriteLineAsync($"{displayRecipes[lbxDisplay.SelectedIndex].Name}");
                                foreach (Ingredient i in displayRecipes[lbxDisplay.SelectedIndex].Ingredients)
                                {
                                    await sw.WriteLineAsync($"{i.Name}: {i.QTY} {i.Measurement}");
                                }
                                await sw.WriteLineAsync();
                            }
                        }
                    }
                }
                else
                {
                    FileSavePicker fileSavePicker = new FileSavePicker();
                    fileSavePicker.FileTypeChoices.Add("Text", new List<string>() { ".txt" });
                    fileSavePicker.SuggestedFileName = "Grocery List";
                    StorageFile file = await fileSavePicker.PickSaveFileAsync();
                    if (file != null)
                    {
                        using (Stream fs = await file.OpenStreamForWriteAsync())
                        {
                            fs.SetLength(0);
                            using (StreamWriter sw = new StreamWriter(fs))
                            {
                                await sw.WriteLineAsync($"{displayRecipes[lbxDisplay.SelectedIndex].Name}");
                                foreach (Ingredient i in displayRecipes[lbxDisplay.SelectedIndex].Ingredients)
                                {
                                    await sw.WriteLineAsync($"{i.Name}: {i.QTY} {i.Measurement}");
                                }
                                await sw.WriteLineAsync();
                                mruToken = mru.Add(file, "grocery");
                            }
                        }
                    }
                }
            }
            else
            {
                await (new MessageDialog("Please select a recipe to add to grocery list.")).ShowAsync();
            }
        }

        private async void Delete_Recipe(object sender, RoutedEventArgs e)
        {
            if (lbxDisplay.SelectedIndex >= 0 && lbxDisplay.SelectedIndex < displayRecipes.Count)
            {
                Recipe r = displayRecipes[lbxDisplay.SelectedIndex];
                displayRecipes.Remove(r);
                recipes.Remove(r);
            }
            else
            {
                await (new MessageDialog("Please select a recipe to delete.")).ShowAsync();
            }
        }

        private void lbxDisplay_ItemClick(object sender, ItemClickEventArgs e)
        {
            Recipe SelectedRecipe = e.ClickedItem as Recipe;
            this.Frame.Navigate(typeof(RecipePage), SelectedRecipe);
            recipes.Remove(SelectedRecipe);
        }
    }
}
