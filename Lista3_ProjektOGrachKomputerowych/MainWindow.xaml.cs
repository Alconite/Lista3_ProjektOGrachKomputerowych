using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Xml;
using System.Xml.Serialization;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Data;
using Microsoft.Reporting;
using Microsoft.ReportingServices;
using Microsoft.Reporting.WinForms;
using Lista3_ProjektOGrachKomputerowych.model;


namespace Lista3_ProjektOGrachKomputerowych
{

    public partial class MainWindow : Window
    {
        public ObservableCollection<Game> gamelist { get; }
        public Game gra { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DatabaseService DatabaseService = new DatabaseService();
            DatabaseService.createConnection();
            gamelist = DatabaseService.executeProcedureSelect<Game>("DaneGier"); 

            dataGridGames.ItemsSource = gamelist;

            //string connectionString = "Server= localhost\\SQLEXPRESS; Database= Gry; Integrated Security = SSPI";
            //SqlConnection connection = new SqlConnection(connectionString);

            //SqlCommand command = new SqlCommand("DaneGier", connection);
            //command.CommandType = CommandType.StoredProcedure;

            //SqlDataAdapter sda = new SqlDataAdapter(command);
            //DataTable dataTable = new DataTable();
            //sda.Fill(dataTable);

            //foreach (DataRow row in dataTable.Rows)
            //{
                //Gry gry = new Gry();
                //gry.releaseDate = (int)row["Release_Date"];
                //gry.projectName = (string)row["Project_Name"];
                //gry.companyName = (string)row["Company_Name"];
                //listaGier.Add(gry);
            //}

            /*listaGier.Add(new Gry(2015, "The Witcher 3: Wild Hunt", "CD Project Red"));
            listaGier.Add(new Gry(2013, "GTA 5", "Rockstar games"));
            listaGier.Add(new Gry(2014, "Hearthstone", "Blizzard Entertainment"));
            listaGier.Add(new Gry(2015, "The Witcher 3: Wild Hunt", "CD Project Red"));
            listaGier.Add(new Gry(2013, "GTA 5", "Rockstar games"));
            listaGier.Add(new Gry(2014, "Hearthstone", "Blizzard Entertainment"));*/
            //dataGridGames.ItemsSource = listaGier;
            /*DataGridColumn first = dataGridGames.Columns[0];
            first.Width = 10; */

            /*
               XmlSerializer xs = new XmlSerializer(typeof(List<Gry>));
            using (Stream s = File.OpenRead("C:/Games + Programs/Studia/GameList.xml"))
            {
                listaGier = (List<Gry>)xs.Deserialize(s);
            }
            MessageBox.Show("List was loaded.");
            dataGridGames.ItemsSource = listaGier;
            */
        }

        private void Button(object sender, RoutedEventArgs e)
        {
            //AddGame addGame = new AddGame();
            //Gry gra = new Gry();
            //addGame.DataContext = gra;
            //addGame.ShowDialog();
            //if (addGame.confirm)
            //{
            //listaGier.Add(gra);
            //dataGridGames.Items.Refresh();
            //}
            Button button = sender as Button;

            if (!button.Name.StartsWith("add"))
            {
                this.gra = (Game)dataGridGames.SelectedItem;
                if (gra == null)
                    return;
            }
            else
            {
                this.gra = new Game();
            }

            AddGame addGameWinn = new AddGame(this, button.Name);
            addGameWinn.Show();
        }

        public void addItemToGameList()
        {
            gamelist.Add(this.gra);
        }

        public void removeItemFromGameList()
        {
            gamelist.Remove(this.gra);
        }


        /*private void DeleteGame_Button(object sender, RoutedEventArgs e)
        {
            if (dataGridGames.SelectedItem != null)
            {
                int index = listaGier.IndexOf((Gry)dataGridGames.SelectedItem);
                listaGier.RemoveAt(index);
                dataGridGames.Items.Refresh();
            }
        }*/

        private void SaveList_Button(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Gry>));

            using (Stream s = File.Create("C:/GameList.xml")) 
            {
                xs.Serialize(s, gamelist);
            }
            MessageBox.Show("List was saved.");
        }

        private void LoadList_Button(object sender, RoutedEventArgs e)
        {
            XmlSerializer xs = new XmlSerializer(typeof(List<Gry>));
            //using (Stream s = File.OpenRead("C:/Games + Programs/Studia/GameList.xml"))
            using (Stream s = File.OpenRead("C:/GameList.xml"))
            {
                //gamelist = (List<Gry>)xs.Deserialize(s); ????????????????
            }
            MessageBox.Show("List was loaded.");
            dataGridGames.ItemsSource = gamelist;
        }

        /*private void Change_Button(object sender, RoutedEventArgs e)
        {
            if (dataGridGames.SelectedItem != null)
            {
                AddGame addGame = new AddGame();
                Gry gry = new Gry((Gry)dataGridGames.SelectedItem);
                addGame.DataContext = gry;
                addGame.ShowDialog();
                if (addGame.confirm)
                {
                    int index = listaGier.IndexOf((Gry)dataGridGames.SelectedItem);
                    listaGier[index] = gry;
                    dataGridGames.Items.Refresh();
                }
            }
        }
        */
        private void Report_button(object sender, RoutedEventArgs e)
        {
            
            ReportShow rps = new ReportShow();
            rps.Show();
        }
    }
}
