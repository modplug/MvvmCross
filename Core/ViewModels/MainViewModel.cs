using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Windows.Input;
using Cirrious.MvvmCross.ViewModels;
using Newtonsoft.Json;

namespace Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {
        public MainViewModel()
        {
            Urls = new ObservableCollection<MovieImageItem>();   
        }

        public ObservableCollection<MovieImageItem> Urls
        {
            get { return _urls; }
            set
            {
                _urls = value;
                RaisePropertyChanged(() => Urls);
            }
        }

        public async Task Init()
        {
            await RefreshThumbnails();
        }
        
        private bool _isLoading;
        private ObservableCollection<MovieImageItem> _urls;

        public ICommand RefreshListCommand { get {  return new MvxCommand(async () => await RefreshThumbnails());} }

        private async Task RefreshThumbnails()
        {            
            IsLoading = true;
            Urls.Clear();
            var baseAddress = new Uri("http://private-anon-980cce65a-fanarttv.apiary-proxy.com/");

            using (var httpClient = new HttpClient { BaseAddress = baseAddress })
            {
                using (
                    var response = await httpClient.GetAsync("v3/movies/10195?api_key=ed4b784f97227358b31ca4dd966a04f1")
                    )
                {
                    if (response.StatusCode == HttpStatusCode.OK)
                    {
                        var value = await response.Content.ReadAsStringAsync();
                        var loginResponse = JsonConvert.DeserializeObject<FanartTV>(value);
                        foreach (var background in loginResponse.moviethumb)
                        {                            
                            Urls.Add(new MovieImageItem(background.url, loginResponse.name));
                        }
                        foreach (var poster in loginResponse.moviethumb)
                        {
                            Urls.Add(new MovieImageItem(poster.url, loginResponse.name));
                        }

                        foreach (var banner in loginResponse.moviethumb)
                        {
                            Urls.Add(new MovieImageItem(banner.url, loginResponse.name));
                        }
                    }
                }
            }
            IsLoading = false;
        }

        public bool IsLoading
        {
            get { return _isLoading; }
            set
            {
                _isLoading = value;
                RaisePropertyChanged(() => IsLoading);
            }
        }
    }

    // Classes auto generated from JSON api

    public class MovieImageItem
    {
        public MovieImageItem(string url, string title)
        {
            Url = url;
            Title = title;
        }

        public string Url { get; set; }
        public string Title { get; set; }
    }

    public class Hdmovielogo
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Moviedisc
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
        public string disc { get; set; }
        public string disc_type { get; set; }
    }

    public class Movielogo
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Movieposter
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Hdmovieclearart
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Movieart
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Moviebackground
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Moviebanner
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class Moviethumb
    {
        public string id { get; set; }
        public string url { get; set; }
        public string lang { get; set; }
        public string likes { get; set; }
    }

    public class FanartTV
    {
        public string name { get; set; }
        public string tmdb_id { get; set; }
        public string imdb_id { get; set; }
        public List<Hdmovielogo> hdmovielogo { get; set; }
        public List<Moviedisc> moviedisc { get; set; }
        public List<Movielogo> movielogo { get; set; }
        public List<Movieposter> movieposter { get; set; }
        public List<Hdmovieclearart> hdmovieclearart { get; set; }
        public List<Movieart> movieart { get; set; }
        public List<Moviebackground> moviebackground { get; set; }
        public List<Moviebanner> moviebanner { get; set; }
        public List<Moviethumb> moviethumb { get; set; }
    }
}
