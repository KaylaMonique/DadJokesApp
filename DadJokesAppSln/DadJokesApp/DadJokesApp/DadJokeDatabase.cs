using DadJokesApp.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace DadJokesApp
{
    public class DadJokeDatabase
    {
        private SQLiteConnection _database; // declared a variable, accessing SQLite

        public static DadJokeDatabase Instance = new DadJokeDatabase();

        public DadJokeDatabase()
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData); // ask the device the folder path for location on device

            path = path + "joke.db";

            // lets create a sqlite connect and say where its told with settings: readwrite, create, multiple instances
            _database = new SQLiteConnection(path, SQLiteOpenFlags.ReadWrite | SQLiteOpenFlags.Create | SQLiteOpenFlags.SharedCache); // these are settings for SQLite create = auto create db file

            _database.CreateTable<DadJoke>();
        }

        public List<DadJoke> GetJokes()
        {
            return _database.Table<DadJoke>().OrderByDescending(x => x.JokeDate).ToList();
        }

        public void SaveDadJoke(DadJoke joke) // will save dad joke
        {
            _database.Insert(joke);
        }
    }
}
