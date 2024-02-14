using WebAPI.Models;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Net.Http.Json;
using System.Diagnostics;

namespace WebAPI.ViewModels
{
    public class MainViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public MainViewModel() 
        {
            Colors = new ObservableCollection<JSONColor>();
            FetchData();
        }

        private ObservableCollection<JSONColor> _colors;
        public ObservableCollection<JSONColor> Colors
        {
            get { return _colors; }
            set
            {
                _colors = value;
                OnPropertyChanged(nameof(Colors));
            }
        }

        //Fetch JSON data
        private async void FetchData()
        {
            try
            {
                var httpClient = new HttpClient();
                var response = await httpClient.GetFromJsonAsync<ObservableCollection<JSONColor>>("http://localhost/colors.json");

                if (response != null)
                {
                    foreach (var item in response)
                    {
                        Colors.Add(item);
                    }
                }
                else
                {
                    Debug.WriteLine("Failed to retrieve data.");
                }
            }
            catch (HttpRequestException ex)
            {
                Debug.WriteLine($"HTTP request failed: {ex.Message}");
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"An error occurred: {ex.Message}");
            }
        }

        //property changed event
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
