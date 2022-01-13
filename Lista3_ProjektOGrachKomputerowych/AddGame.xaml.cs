using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using Microsoft.Win32;

namespace Lista3_ProjektOGrachKomputerowych
{
    /// <summary>
    /// Logika interakcji dla klasy AddGame.xaml
    /// </summary>
    public partial class AddGame : Window
    {
        public bool confirm { get; set; }
        int i = 0;
        public AddGame()
        {
            InitializeComponent();
            year.Text = "Release date";
            project.Text = "Name of the game";
            company.Text = "Company Name";
        }

        private void Confirm_Button_Click(object sender, RoutedEventArgs e)
        {
            int num = 0;
            if (int.TryParse(year.Text, out num) && project.Text != "" && company.Text != "")
            {
                confirm = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("Wrong data, try again.");
                year.Text = "";
                project.Text = "";
                company.Text = "";
            }
        }

        private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = false;
            this.Close();
        }

        private void year_GotFocus(object sender, RoutedEventArgs e)
        {
            if (i == 0)
                year.Text = ""; i++;
        }

        private void Picture_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            if (openFileDialog.ShowDialog() == true)
            {
                Uri fileUri = new Uri(openFileDialog.FileName);
                Picture.Source = new BitmapImage(fileUri);
            }
        }
    }
}
