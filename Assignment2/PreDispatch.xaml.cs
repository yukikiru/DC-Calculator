using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class PreDispatch : ContentPage
    {
        Manager m;
        public PreDispatch(ref Manager man)
        {
            m = man;
            InitializeComponent();
        }

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        void calculateStacksFromTrays(System.Object sender, System.EventArgs e)
        {
            try
            {
                if (String.IsNullOrWhiteSpace(PDTrayEntry.Text))
                {
                    throw new Exception("Please enter a number of trays");
                }
                else
                {
                    int trays = Int32.Parse(PDTrayEntry.Text);
                    if(trays < 0)
                    {
                        throw new Exception("Trays cannot be less than 0");
                    }
                    else
                    {
                        PDStacks.Text = DCMath.traysToStacks(trays).ToString();
                        PDTrays.Text = DCMath.traysToOdds(trays).ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
        }
    }
}
