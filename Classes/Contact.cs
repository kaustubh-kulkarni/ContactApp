using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Classes
{
    public class Contact
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        //Override the list to show strings of below params
        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
