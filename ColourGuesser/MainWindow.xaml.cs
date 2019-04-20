using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ColourGuesser
{
    public partial class MainWindow : Window
    {
        ColourList clrlst = new ColourList();
        Colour[] colours = {
        };

        byte r, g, b;

        Random rnd = new Random();

        public MainWindow()
        {
            InitializeComponent();
            colours = clrlst.colours;
        }

        void ChangeColour()
        {
            rctColour.Fill = new SolidColorBrush(Color.FromRgb(r, g, b));
            FindClosestColour();
        }

        void FindClosestColour()
        {
            for (int i = 0; i < colours.Length; i++)
            {
                colours[i].closeness = colours[i].Compare(r, g, b);
            }

            Colour closestcolour = new Colour("empty", r: 0, g: 0, b: 0, 1000);

            for (int i = 0; i < colours.Length; i++)
            {              
                if (colours[i].closeness < closestcolour.closeness)
                {
                    closestcolour = colours[i];
                }
            }

            txtName.Text = closestcolour.name;
            txtName.Background = new SolidColorBrush(Color.FromRgb(closestcolour.r, closestcolour.g, closestcolour.b));

            SetTextColour();
        }

        void SetTextColour()
        {
            if (r < 100)
            {
                txtName.Foreground = new SolidColorBrush(Color.FromRgb(255, 255, 255));
            }

            else
            {
                txtName.Foreground = new SolidColorBrush(Color.FromRgb(0, 0, 0));
            }
        }

        private void TxtR_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                r = Convert.ToByte(txtR.Text);
            }

            catch
            {
                txtR.Text = "0";
                r = 0;
            }

            ChangeColour();
        }

        private void RctColour_MouseLeftButtonDown(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            r = Convert.ToByte(rnd.Next(0, 255));
            g = Convert.ToByte(rnd.Next(0, 255));
            b = Convert.ToByte(rnd.Next(0, 255));
            txtR.Text = r.ToString();
            txtG.Text = g.ToString();
            txtB.Text = b.ToString();
            ChangeColour();
        }

        private void TxtG_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                g = Convert.ToByte(txtG.Text);
            }

            catch
            {
                txtG.Text = "0";
                g = 0;
            }
            ChangeColour();
        }

        private void TxtB_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                b = Convert.ToByte(txtB.Text);
            }

            catch
            {
                txtB.Text = "0";
                b = 0;
            }
            ChangeColour();
        }
    }
}
