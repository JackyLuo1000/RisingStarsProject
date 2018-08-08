using RisingStarProject;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RisingStarProject
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private List<Ingredient> ingredients;
        private StringBuilder sb = new StringBuilder();
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void Create_Ingredients(object sender, RoutedEventArgs e)
        {
            //Use string builder to parse info of recipe fields

            //Store the information into proper fields

            //Using the variable pass information to create ingredients a new ingredient

            //Add the ingredient to the ingredients List
        }

        private void Create_Recipe(object sender, RoutedEventArgs e)
        {
            //Use string builder to parse info of recipe fields

            //Store the information into proper fields

            //Using the variable pass information to create ingredients a new recipe

            //Add the recipe to the recipes List
        }
    }
}
