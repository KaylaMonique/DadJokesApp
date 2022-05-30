using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace DadJokesApp.Models
{
    // what its going to look like in database
    public class DadJoke
    { 
        [PrimaryKey, AutoIncrement] // an attribute
        public int Id { get; set; }

        public string Joke { get; set; }

        public DateTime JokeDate { get; set; } // date time holds date and time where joke was produced
    }
}
