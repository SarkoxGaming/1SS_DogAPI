using Microsoft.VisualBasic.CompilerServices;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiHelper
{
    public class DogApiProcessor
    {

        //get all bread: https://dog.ceo/api/breeds/list/all
        //get random img: https://dog.ceo/api/breeds/image/random

        public static async Task<BreedModel> LoadBreedList()
        {
            ///TODO : À compléter LoadBreedList
            /// Attention le type de retour n'est pas nécessairement bon
            /// J'ai mis quelque chose pour avoir une base
            /// TODO : Compléter le modèle manquant

            string url = $"https://dog.ceo/api/breeds/list/all";

            using (HttpResponseMessage response = await
                ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode) {

                    BreedModel breed = await response.Content.ReadAsAsync<BreedModel>();
                    return breed;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }

        public static async Task<DogModel> GetImageUrl(string breed,int max)
        {
            /// TODO : GetImageUrl()
            /// TODO : Compléter le modèle manquant
            /// https://dog.ceo/api/breed/hound/images

            string url = $"https://dog.ceo/api/breed/{breed}/images";

            using (HttpResponseMessage response = await
                ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {

                    DogModel dog = await response.Content.ReadAsAsync<DogModel>();
                    dog.MaxDog = max;
                    dog.ConstMax = max;
                    dog.MinDog = 0;
                    dog.display();
                    return dog;
                }
                else
                    throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
