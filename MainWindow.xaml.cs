using ContactApp.Classes;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //Read DB to display
            ReadDb();
        }

        //Method to change windows
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //Create instance
            NewContactWindow newContactWindow = new NewContactWindow();
            newContactWindow.ShowDialog();
            //Everytime we create new contact read db
            ReadDb();
        }
        //Method to read from DB
        void ReadDb()
        {
            using (SQLite.SQLiteConnection conn = new SQLite.SQLiteConnection(App.dbPath))
            {
                //Create a table to read from
                conn.CreateTable<Contact>();
                var contacts = conn.Table<Contact>().ToList();
            }
        }
    }
}
