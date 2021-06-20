using System;
using System.Collections.Generic;
using Assignment2.Model;

using Xamarin.Forms;

namespace Assignment2
{
    public partial class Loading : ContentPage
    {
        Manager m;
        public Loading(ref Manager man)
        {
            m = man;
            InitializeComponent();
        }

        //Calculates the last position of stacks on a trailer
        void calculateTrailerPos(System.Object sender, System.EventArgs e)
        {
            try
            {

                if(String.IsNullOrWhiteSpace(trailerPosEntry.Text))
                {
                    throw new Exception("Stacks on trailer cannot be empty");
                }
                else
                {
                    int stacks = Int32.Parse(trailerPosEntry.Text);
                    if (stacks <= 0 || stacks > 104)
                    {
                        throw new Exception("Stack position on trailer must be greater than 0 " +
                            "and less than 105");
                    }
                    else
                    {
                        double pos = DCMath.loadingPoition(stacks);
                        int p1 = (int)pos;
                        int p2;
                        if (pos - p1 == 0.25)
                        {
                            p2 = 1;
                        }
                        else if (pos - p1 == 0.5)
                        {
                            p2 = 2;
                        }
                        else if (pos - p1 == 0.75)
                        {
                            p2 = 3;
                        }
                        else
                        {
                            p2 = 0;
                        }
                        trailerPos.Text = "Trailer at: " + p1 + "." + p2;
                    }
                } 
            }catch(Exception ex)
            {
                DisplayAlert("Error", ex.Message, "Okay");
            }
            //DisplayAlert("Test", DCMath.loadingPoition(23).ToString(), "OK!");
        }
        

        async void navHome(System.Object sender, System.EventArgs e)
        {
            await Navigation.PopToRootAsync();
        }

        //Calculates conversion of bancroft stacks to normal stack height for loading trailers
        void calculateBancroft(System.Object sender, System.EventArgs e)
        {
            try
            {
                
                if (String.IsNullOrWhiteSpace(banStacks.Text))
                {
                    throw new Exception("Stacks must have a value");
                }
                else
                {
                    int stacks = Int32.Parse(banStacks.Text);
                    int trays; //If empty will default to 0
                    if (String.IsNullOrWhiteSpace(banOdds.Text))
                    {
                        trays = 0;
                    }
                    else
                    {
                        trays = Int32.Parse(banOdds.Text);
                    }
                    
                    if(stacks >104 || trays > 14)
                    {
                        throw new Exception("Stacks should be less than 104 and trays less than 14");
                    }
                    else
                    {
                        int trayCount = DCMath.convert13ToTrays(stacks, trays);
                        int newStacks = DCMath.traysToStacks(trayCount);
                        int newTrays = trayCount - (newStacks * 14);
                        bancroftStacks.Text = newStacks.ToString();
                        bancroftTrays.Text = newTrays.ToString();
                    }
                }
            }catch(Exception ex)
            {
                DisplayAlert("Error",ex.Message,"Okay");
            }
        }
    }
}
