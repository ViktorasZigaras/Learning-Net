using FetchJsonConsole.Objects;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace FetchJsonConsole
{
    class Run
    {
        static async Task Main(string[] args)
        {
            string userUrl = "https://jsonplaceholder.typicode.com/users";
            string albumUrl = "https://jsonplaceholder.typicode.com/albums";
            string photosUrl = "https://jsonplaceholder.typicode.com/photos";
            string userName = "Mrs. Dennis Schulist";

            HttpClient client = new HttpClient();

            HttpResponseMessage userRequest = await client.GetAsync(userUrl);
            string userBody = await userRequest.Content.ReadAsStringAsync();
            List<User> userObject = JsonConvert.DeserializeObject<List<User>>(userBody);
            User userFiltered = (User) userObject.Where(user => user.Name == userName).First();

            HttpResponseMessage albumRequest = await client.GetAsync($"{albumUrl}?userId={userFiltered.Id}");
            string albumBody = await albumRequest.Content.ReadAsStringAsync();
            List<Album> albumObject = JsonConvert.DeserializeObject<List<Album>>(albumBody);
            string albumParams = "?";
            foreach (Album album in albumObject)
            {
                albumParams += $"albumId={album.Id}&";
            }

            HttpResponseMessage photosRequest = await client.GetAsync(photosUrl + albumParams);
            photosRequest.EnsureSuccessStatusCode();
            string photosBody = await photosRequest.Content.ReadAsStringAsync();
            List<Photo> photosObject = JsonConvert.DeserializeObject<List<Photo>>(photosBody);

            // alternative version:

            /*var filteredPhotos = userObject
                .Where(userName => userName.Name == "Mrs. Dennis Schulist")
                .SelectMany(userName => albumObject
                    .Where(albumId => albumId.UserId == userName.Id)
                    .SelectMany(albumId => photosObject
                        .Where(photoId => photoId.AlbumId == albumId.Id)
                    )
                );*/
            // Console.WriteLine(userObject.Count);
            foreach (Photo photo in photosObject) // filteredPhotos
            {
                Console.WriteLine($"Album Id: {photo.AlbumId}, Photo Id: {photo.Id}, Photo Url: {photo.Url}");
            }
        }
    }
}