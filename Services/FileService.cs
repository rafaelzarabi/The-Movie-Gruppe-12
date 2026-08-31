using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using The_Movie_Gruppe_12.Models;

namespace The_Movie_Gruppe_12.Services
{
    public class FileService
    {
        private readonly string _filePath = "data.json";

        private readonly JsonSerializerOptions _options =
            new JsonSerializerOptions
            {
                WriteIndented = true,
                ReferenceHandler = ReferenceHandler.Preserve
            };


        public void SaveData(
            IEnumerable<Movie> movies,
            IEnumerable<Cinema> cinemas,
            IEnumerable<Screening> screenings,
            IEnumerable<Reservation> reservations)
        {
            AppData data = new AppData
            {
                Movies = movies.ToList(),
                Cinemas = cinemas.ToList(),
                Screenings = screenings.ToList(),
                Reservations = reservations.ToList()
            };

            string json = JsonSerializer.Serialize(data, _options);

            File.WriteAllText(_filePath, json);
        }


        public AppData LoadData()
        {
            if (!File.Exists(_filePath))
            {
                return new AppData();
            }

            string json = File.ReadAllText(_filePath);

            AppData data =
                JsonSerializer.Deserialize<AppData>(json, _options);

            return data ?? new AppData();
        }
    }
}