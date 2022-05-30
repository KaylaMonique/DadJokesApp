using DadJokesApp.Models.Service;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DadJokesApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class JokePage : ContentPage
    {
        public JokePage()
        {
            InitializeComponent();
        }

        private async void JokeButton_Clicked(object sender, EventArgs e)
        {
            DadJoke joke = await GetRemoteJoke();

            BindingContext = joke; // Binding context holds the info that xaml sees

            DadJokeDatabase db = DadJokeDatabase.Instance;

            DadJokesApp.Models.DadJoke dbJoke = new Models.DadJoke();
            dbJoke.JokeDate = DateTime.Now;
            dbJoke.Joke = joke.joke;
            db.SaveDadJoke(dbJoke);
        }

        protected override async void OnAppearing()
        {
            base.OnAppearing();

            DadJoke joke = await GetRemoteJoke();

            BindingContext = joke;

            DadJokeDatabase db = DadJokeDatabase.Instance;

            DadJokesApp.Models.DadJoke dbJoke = new Models.DadJoke();
            dbJoke.JokeDate = DateTime.Now;
            dbJoke.Joke = joke.joke;
            db.SaveDadJoke(dbJoke);
        }

        private async Task<DadJoke> GetRemoteJoke() // going to get the joke
        {
            HttpClient client = new HttpClient(); // going to add 

            client.DefaultRequestHeaders.Add("Accept", "application/json"); // set header up in order to use it

            string response = await client.GetStringAsync("https://icanhazdadjoke.com/"); // because the method is returning a string, add string response

            DadJoke joke = JsonConvert.DeserializeObject<DadJoke>(response); // used to get json file <converts to DadJoke class> = going to return a object

            return joke;
        }
    }
}