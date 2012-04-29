using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using GalaSoft.MvvmLight.Command;
using MoveIt.DataAccess;
using MoveIt.Helpers;
using MoveIt.Model;

namespace MoveIt.ViewModel
{
    public class MoveViewModel : ViewModelBase
    {
        private ObservableCollection<JustMoveInstruction> moveInstructions;
        public ObservableCollection<ExerciseViewModel> Exercises { get; private set; }
        public string MoveInstruction { get { return moveInstructions.GetRandomElement().Text; } }

        public RelayCommand DidItCommand { get; private set; }
        public RelayCommand SnoozeCommand { get; private set; }

        public MoveViewModel()
        {
            DidItCommand = new RelayCommand(ExerciseCompleted); 
            SnoozeCommand = new RelayCommand(Snooze); 
            LoadData();
        }

        private void ExerciseCompleted()
        {
            App.State = TimerState.Type.New;
            ApplicationController.Default.GoBack();
        }

        private void Snooze()
        {
            App.State = TimerState.Type.Snooze;
            ApplicationController.Default.GoBack();
        }

        private void LoadData()
        {
            LoadExercises();
            LoadMoveInstructions();
        }

        private void LoadExercises()
        {
            Exercises = new ObservableCollection<ExerciseViewModel>();
            foreach (var exercise in ExerciseRepository.Default.GetExercises())
            {
                Exercises.Add(new ExerciseViewModel(exercise));
            }
        }

        private void LoadMoveInstructions()
        {
            moveInstructions = new ObservableCollection<JustMoveInstruction>();
            foreach (var instruction in MoveInstructionRepository.Default.GetInstructions())
            {
                moveInstructions.Add(instruction);
            }
        }
    }
}
