using System;
using GalaSoft.MvvmLight.Command;
using Microsoft.Phone.Tasks;
using MoveIt.Helpers;
using MoveIt.Model;

namespace MoveIt.ViewModel
{
    public class ExerciseViewModel : ViewModelBase
    {
        private const string IMAGE_DIR = "../Pictures/";
        private readonly Exercise exercise;
        public RelayCommand LoadExerciseCommand { get; private set; }

        public ExerciseViewModel(Exercise exercise)
        {
            this.exercise = exercise;
            LoadExerciseCommand = new RelayCommand(LoadExerciseDetail); 
        }

        private void LoadExerciseDetail()
        {
            ApplicationController.Default.NavigateToUrl(Url);
        }

        public int Id
        {
            get { return exercise.Id; }
            set
            {
                if (value == exercise.Id) return;

                exercise.Id = value;
                OnNotifyPropertyChanged("Id");
            }
        }

        public string Name
        {
            get { return exercise.Name; }
            set
            {
                if (value == exercise.Name) return;

                exercise.Name = value;
                OnNotifyPropertyChanged("Name");
            }
        }

        public string Url
        {
            get { return exercise.Url; }
            set
            {
                if (value == exercise.Url) return;

                exercise.Url = value;
                OnNotifyPropertyChanged("Url");
            }
        }

        public string Picture
        {
            get { return exercise.Picture; }
            set
            {
                if (value == exercise.Picture) return;

                exercise.Picture = value;
                OnNotifyPropertyChanged("Picture");
            }
        }


        public string Category
        {
            get { return exercise.Category; }
            set
            {
                if (value == exercise.Category) return;

                exercise.Category = value;
                OnNotifyPropertyChanged("Category");
            }
        }

        public string PictureSource { get { return IMAGE_DIR + exercise.Picture; } }

    }
}
