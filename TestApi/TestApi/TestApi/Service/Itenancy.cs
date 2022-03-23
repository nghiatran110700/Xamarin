using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using TestApi.Model;

namespace TestApi.Service
{
    public class Itenancy
    {

        HttpClient client;
        public Itenancy()
        {
            client = new HttpClient();
        }

        public ObservableCollection<Tenancy> Items
        {
            get; private set;
        }

        public string WebAPIUrl
        {
            get; private set;
        }
        public async Task<ObservableCollection<Tenancy>> RefreshDataAsync()
        {
            
            var uri = new Uri("https://localhost:44373/Tenancy");
            try
            {
                var response = await client.GetAsync(uri);

                if (response.IsSuccessStatusCode)
                {
                    var content = await response.Content.ReadAsStringAsync();
                     Items = JsonConvert.DeserializeObject<ObservableCollection<Tenancy>>(content);
                    return Items;
                }
            }
            catch (Exception ex)
            {
            }
            return null;
        }

    }
}