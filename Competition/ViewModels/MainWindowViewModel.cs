using Competition.Logic;
using Competition.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;

namespace Competition.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        private ObservableCollection<Athlete> athletes;
        public ObservableCollection<Athlete> Athletes
        {
            get { return athletes; }
            set
            {
                athletes = value;
                (LoadDataCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }
        public ObservableCollection<Athlete> competition;

        public ICommand AddToCompetitionCommand;
        public ICommand LoadDataCommand;
        public ICommand RemoveFromCompetitionCommand;
        public ICommand OpenAthleteCommand;
        public ICommand SaveCommand;

        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }

        private Athlete selectedAthlete;

        public Athlete SelectedAthlete
        {
            get { return selectedAthlete; }
            set
            {
                SetProperty(ref selectedAthlete, value);
                (AddToCompetitionCommand as RelayCommand).NotifyCanExecuteChanged();
                (OpenAthleteCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

        private Athlete selectedCompetition;

        public Athlete SelectedCompetition
        {
            get { return selectedCompetition; }
            set
            {
                SetProperty(ref selectedCompetition, value);
                (RemoveFromCompetitionCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }


        IAthleteLogic athleteLogic;

        public MainWindowViewModel(IAthleteLogic athleteLogic)
        {

            this.athleteLogic = athleteLogic;
            LoadDataCommand = new RelayCommand(
                () => athleteLogic.LoadData(athletes),
                () => Athletes.Count == 0
                );
            AddToCompetitionCommand = new RelayCommand(
                () => athleteLogic.AddToCompetition(SelectedAthlete),
                () => selectedAthlete != null
                );
            RemoveFromCompetitionCommand = new RelayCommand(
                () => athleteLogic.RemoveFromCompetition(SelectedCompetition),
                () => selectedCompetition != null
                );
            OpenAthleteCommand = new RelayCommand(
                () => athleteLogic.OpenAthlete(selectedCompetition),
                () => selectedCompetition != null
                );
            SaveCommand = new RelayCommand(
                () => athleteLogic.Save(FileName),
                () => competition.Count != 0
                );
        }

        public MainWindowViewModel()
        {
            
        }

        private string fileName;

        public string FileName
        {
            get { return fileName; }
            set
            {
                SetProperty(ref fileName, value);
                (SaveCommand as RelayCommand).NotifyCanExecuteChanged();
            }
        }

    }
}
