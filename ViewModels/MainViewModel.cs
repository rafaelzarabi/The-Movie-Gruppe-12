using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using The_Movie_Gruppe_12.Models;
using System.Windows;

namespace The_Movie_Gruppe_12.ViewModels
{
    public class MainViewModel : ViewModelBase
    {

        private Movie _movie = new Movie();

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


        // Biografer
        public ObservableCollection<Cinema> Cinemas { get; set; }
            = new ObservableCollection<Cinema>();

        private Cinema _selectedCinema;

        public Cinema SelectedCinema
        {
            get => _selectedCinema;
            set
            {
                _selectedCinema = value;
                OnPropertyChanged();
            }
        }

        private TheaterHall _selectedTheaterHall;

        public TheaterHall SelectedTheaterHall
        {
            get => _selectedTheaterHall;
            set
            {
                _selectedTheaterHall = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Screening> Screenings { get; set; }
            = new ObservableCollection<Screening>();

        private Movie _selectedMovie;

        public Movie SelectedMovie
        {
            get => _selectedMovie;
            set
            {
                _selectedMovie = value;
                OnPropertyChanged();
            }
        }

        private DateTime _selectedStartTime = DateTime.Now;

        public DateTime SelectedStartTime
        {
            get => _selectedStartTime;
            set
            {
                _selectedStartTime = value;
                OnPropertyChanged();
            }
        }


        public ObservableCollection<Reservation> Reservations { get; set; }
            = new ObservableCollection<Reservation>();


        // Side visning

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


        private bool _isCreateScreeningVisible = false;

        public bool IsCreateScreeningVisible
        {
            get => _isCreateScreeningVisible;
            set
            {
                _isCreateScreeningVisible = value;
                OnPropertyChanged();
            }
        }


        private bool _isProgramVisible = false;

        public bool IsProgramVisible
        {
            get => _isProgramVisible;
            set
            {
                _isProgramVisible = value;
                OnPropertyChanged();
            }
        }



        public ICommand ShowRegisterMovieCommand { get; }

        public ICommand ShowMovieOverviewCommand { get; }

        public ICommand RegisterMovieCommand { get; }

        public ICommand ShowCreateScreeningCommand { get; }

        public ICommand CreateScreeningCommand { get; }

        public ICommand ShowProgramCommand { get; }

        public ICommand BackToMenuCommand { get; }


        public MainViewModel()
        {
            ShowRegisterMovieCommand =
                new RelayCommand(ShowRegisterMovie);

            ShowMovieOverviewCommand =
                new RelayCommand(ShowMovieOverview);

            RegisterMovieCommand =
                new RelayCommand(RegisterMovie);

            ShowCreateScreeningCommand =
                new RelayCommand(ShowCreateScreening);

            CreateScreeningCommand =
                new RelayCommand(CreateScreening);

            ShowProgramCommand =
                new RelayCommand(ShowProgram);

            BackToMenuCommand =
                new RelayCommand(BackToMenu);

            //Biograf 1 København
            Cinema cinema = new Cinema
            {
                Name = "The Movies",
                City = "Købennhavn"
            };


            cinema.TheaterHalls.Add(
                new TheaterHall
                {
                    Name = "Sal 1",
                    Capacity = 210
                });

            cinema.TheaterHalls.Add(
                new TheaterHall
                {
                    Name = "Sal 2",
                    Capacity = 170
                });
            // Biograf 2 Århus
            Cinema cinema2 = new Cinema
            {
                Name = "The Movies",
                City = "Århus"
            };
            cinema2.TheaterHalls.Add(new TheaterHall
            {
                Name = "Sal 1",
                Capacity = 150
            });
            cinema2.TheaterHalls.Add(new TheaterHall
            {
                Name = "Sal 2",
                Capacity = 120
            });
            // Biograf 3 Næstved

            Cinema cinema3 = new Cinema
            {
                Name = " The Movies",
                City ="Næstved"
            };
            cinema3.TheaterHalls.Add(new TheaterHall
            {
                Name = "Sal 1",
                Capacity = 130
            });
            cinema3.TheaterHalls.Add(new TheaterHall
            {
                Name = "Sal 2",
                Capacity = 70
            });


            Cinemas.Add(cinema);
            Cinemas.Add(cinema2);
            Cinemas.Add(cinema3);
            
            SelectedCinema = Cinemas[0];
        }


        

        private void ShowRegisterMovie(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = true;
            IsMovieOverviewVisible = false;
            IsCreateScreeningVisible = false;
            IsProgramVisible = false;
        }


        private void ShowMovieOverview(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = true;
            IsCreateScreeningVisible = false;
            IsProgramVisible = false;
        }


        private void ShowCreateScreening(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = false;
            IsCreateScreeningVisible = true;
            IsProgramVisible = false;
        }


        private void ShowProgram(object parameter)
        {
            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = false;
            IsCreateScreeningVisible = false;
            IsProgramVisible = true;
        }


        private void BackToMenu(object parameter)
        {
            IsMainMenuVisible = true;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = false;
            IsCreateScreeningVisible = false;
            IsProgramVisible = false;
        }


        // Filmregistrering

        private void RegisterMovie(object parameter)
        {
            Movies.Add(Movie);

            Movie = new Movie();

            IsMainMenuVisible = false;
            IsRegisterMovieVisible = false;
            IsMovieOverviewVisible = true;
            IsCreateScreeningVisible = false;
            IsProgramVisible = false;
        }


        // Forestillings oprettelse

        private void CreateScreening(object parameter)
        {
            if (SelectedMovie == null ||
                SelectedTheaterHall == null)
            {
                return;
            }

            foreach (Screening screening in Screenings)
            {
                if (screening.TheaterHall == SelectedTheaterHall &&
                    screening.StartTime == SelectedStartTime)
                {
                    MessageBox.Show(
                        "Der findes allerede en forestilling i denne sal på dette tidspunkt.");

                    return;
                }
            }

            Screening newScreening = new Screening
            {
                Movie = SelectedMovie,
                TheaterHall = SelectedTheaterHall,
                StartTime = SelectedStartTime
            };

            Screenings.Add(newScreening);

            SelectedTheaterHall.Screenings.Add(newScreening);

            ShowProgram(null);
        }
    }
}