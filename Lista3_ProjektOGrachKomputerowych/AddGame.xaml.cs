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
using Lista3_ProjektOGrachKomputerowych.model;


namespace Lista3_ProjektOGrachKomputerowych
{

    public partial class AddGame : Window
    {
        private MainWindow MainWindow;
        private DatabaseService DatabaseService;
        private string Mode;

        //public bool confirm { get; set; }
        int i = 0;

        public AddGame()
        {
            InitializeComponent();
            year.Text = "Release date";
            project.Text = "Name of the game";
            company.Text = "Company Name";
        }

        public AddGame(MainWindow window, string mode)
        {

            this.MainWindow = window;
            this.DataContext = this.MainWindow.gra;
            this.Mode = mode;
            InitializeComponent();

            this.DatabaseService = new DatabaseService();

            if (this.Mode.StartsWith("Delete"))
            {
                Confirm_Button.Visibility = Visibility.Hidden;
                year.IsReadOnly = true;
                project.IsReadOnly = true;
                company.IsReadOnly = true;
            }
            else
            {
                Delete_Button.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            /*int num = 0;
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
            }*/

            this.DatabaseService.createConnection();
            if (this.Mode.StartsWith("add"))
            {
                this.MainWindow.addItemToGameList();
                this.MainWindow.gra.Release_Date = this.DatabaseService.executeProcedureModify<Game>("ModifyGame", "Insert", this.MainWindow.gra);
            }
            else if (this.Mode.StartsWith("change"))
            {
                this.DatabaseService.executeProcedureModify<Game>("ModifyGame", "Update", this.MainWindow.gra);
            }
            else if (this.Mode.StartsWith("delete"))
            {
                this.MainWindow.removeItemFromGameList();
                this.DatabaseService.executeProcedureModify<Game>("ModifyGame", "Delete", this.MainWindow.gra);
            }

            this.Close();
        }

       /* private void Cancel_Button_Click(object sender, RoutedEventArgs e)
        {
            confirm = false;
            this.Close();
        }*/

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
