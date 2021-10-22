using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ContactApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        //Create DB and store it
        public static string dbName = "Contacts.db";
        public static string folderPath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
        public static string dbPath = System.IO.Path.Combine(folderPath, dbName);
    }
}
