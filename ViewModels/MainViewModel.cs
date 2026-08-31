using System.Collections.ObjectModel;
using System.Windows.Input;
using The_Movie_Gruppe_12.Models;
using System;
using The_Movie_Gruppe_12.Services;

namespace The_Movie_Gruppe_12.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        private Movie _movie = new Movie();
        private readonly FileService _fileService = new FileService();

        public Movie Movie
        {
            get => _movie;
            set
            {
                _movie = value;
                OnPropertyChanged();
            }
        }

        public ObservableCollection<Movie> Movies { get; set; }
            = new ObservableCollection<Movie>();

        public ObservableCollection<Screening> Screenings { get; set; }
            = new ObservableCollection<Screening>();

        public ObservableCollection<Reservation> Reservations { get; set; }
            = new ObservableCollection<Reservation>();

        public ObservableCollection<Cinema> Cinemas { get; set; }
            = new ObservableCollection<Cinema>();


        private bool _isMainMenuVisible = true;

        public bool IsMainMenuVisible
        {
            get => _isMainMenuVisible;
            set
            {
                _isMainMenuVisible = value;
                OnPropertyChanged();
            }
        }


        private bool _isRegisterMovieVisible = false;

        public bool IsRegisterMovieVisible
        {
            get => _isRegisterMovieVisible;
            set
            {
                _isRegisterMovieVisible = value;
                OnPropertyChanged();
            }
        }

        private bool _isMovieOverviewVisible = false;

        public bool IsMovieOverviewVisible
        {
            get => _isMovieOverviewVisible;
            set
            {
                _isMovieOverviewVisible = value;
                OnPropertyChanged();
            }
        }


        public ICommand ShowRegisterMovieCommand { get; }

        public ICommand ShowMovieOverviewCommand { get; }

        public ICommand RegisterMovieCommand { get; }
        public ICommand BackToMenuCommand { get; }


        public MainViewModel()
        {
            ShowRegisterMovieCommand =
                new RelayCommand(ShowRegisterMovie);

            ShowMovieOverviewCommand =
                new RelayCommand(ShowMovieOverview);

            RegisterMovieCommand =
                new RelayCommand(RegisterMovie);
            BackToMenuCommand =
                new RelayCommand(BackToMenu);

            LoadData();
        }


        private void ShowRegisterMovie(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = true;
            IsMovieOverviewVisible = false;
        }

        private void ShowMovieOverview(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = true;
        }

        private void RegisterMovie(object parameter)
        {
            Movies.Add(Movie);

            Movie = new Movie();

            SaveData();

            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = true;
        }

            private void BackToMenu(object parameter)
        {
            IsMainMenuVisible = true;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = false;
        }

        public Screening? CreateScreening(
         Movie movie,
         TheaterHall theaterHall,
         DateTime startTime)
        {
            Screening newScreening = new Screening
            {
                Movie = movie,
                TheaterHall = theaterHall,
                StartTime = startTime
            };

            foreach (Screening existingScreening in theaterHall.Screenings)
            {
                bool overlaps =
                    newScreening.StartTime < existingScreening.CalculateEndTime()
                    &&
                    newScreening.CalculateEndTime() > existingScreening.StartTime;

                if (overlaps)
                {
                    return null;
                }
            }

            Screenings.Add(newScreening);

            theaterHall.Screenings.Add(newScreening);

            SaveData();

            return newScreening;
        }

        public Reservation? CreateReservation(
           Screening screening,
           string email,
           string phone,
           int numberOfTickets)
        {
            if (!screening.CanReserve(numberOfTickets))
            {
                return null;
            }

            Reservation reservation = new Reservation
            {
                Screening = screening,
                Email = email,
                Phone = phone,
                NumberOfTickets = numberOfTickets
            };

            screening.Reservations.Add(reservation);

            Reservations.Add(reservation);

            SaveData();

            return reservation;
        }

        public void SaveData()
        {
            _fileService.SaveData(
                Movies,
                Cinemas,
                Screenings,
                Reservations);
        }

        private void LoadData()
        {
            AppData data = _fileService.LoadData();

            Movies = new ObservableCollection<Movie>(data.Movies);
            Cinemas = new ObservableCollection<Cinema>(data.Cinemas);
            Screenings = new ObservableCollection<Screening>(data.Screenings);
            Reservations = new ObservableCollection<Reservation>(data.Reservations);
        }

    }
    
}