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
        List<Contact> contacts;
        public MainWindow()
        {
            InitializeComponent();
            //Instantiate
            contacts = new List<Contact>();
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
                contacts = conn.Table<Contact>().ToList();
            }

            if (contacts != null)
            {
                contactListView.ItemsSource = contacts;
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox searchTextBox = sender as TextBox;
            //Search for the contact with user textbox text
            var filteredList = contacts.Where(c => c.Name.ToLower().Contains(searchTextBox.Text.ToLower())).ToList();
            //Display it
            contactListView.ItemsSource = filteredList;
        }
    }
}
