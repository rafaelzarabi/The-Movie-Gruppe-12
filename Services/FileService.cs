using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using The_Movie_Gruppe_12.Models;

namespace The_Movie_Gruppe_12.Services
{
    public class FileService
    {
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
        }
    }
}