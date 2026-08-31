using System.Collections.Generic;
using System.IO;
<<<<<<< HEAD
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
=======
using System.Text.Json;
>>>>>>> 28a4b1c691818095b447259faa92c5e95ea26823
using The_Movie_Gruppe_12.Models;

namespace The_Movie_Gruppe_12.Services
{
    public class FileService
    {
<<<<<<< HEAD
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
=======
        private string movieFilePath = "movies.json";
        private string screeningFilePath = "screenings.json";


        // FILM

        public void SaveMovies(List<Movie> movies)
        {
            string json = JsonSerializer.Serialize(movies);

            File.WriteAllText(movieFilePath, json);
        }

        public List<Movie> LoadMovies()
        {
            if (!File.Exists(movieFilePath))
            {
                return new List<Movie>();
            }

            string json = File.ReadAllText(movieFilePath);

            return JsonSerializer.Deserialize<List<Movie>>(json);
        }


        // FORESTILLINGER

        public void SaveScreenings(List<Screening> screenings)
        {
            List<ScreeningData> screeningDataList =
                new List<ScreeningData>();

            foreach (Screening screening in screenings)
            {
                ScreeningData data = new ScreeningData
                {
                    MovieTitle = screening.Movie.Title,
                    TheaterHallName = screening.TheaterHall.Name,
                    StartTime = screening.StartTime
                };

                screeningDataList.Add(data);
            }

            string json =
                JsonSerializer.Serialize(screeningDataList);

            File.WriteAllText(screeningFilePath, json);
        }

        public List<ScreeningData> LoadScreenings()
        {
            if (!File.Exists(screeningFilePath))
            {
                return new List<ScreeningData>();
            }

            string json =
                File.ReadAllText(screeningFilePath);

            return JsonSerializer.Deserialize<List<ScreeningData>>(json);
>>>>>>> 28a4b1c691818095b447259faa92c5e95ea26823
        }
    }
}