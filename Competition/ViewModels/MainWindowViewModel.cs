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
using Microsoft.Toolkit.Mvvm.DependencyInjection;

namespace Competition.ViewModels
{
    public class MainWindowViewModel : ObservableRecipient
    {
        IAthleteLogic athleteLogic;
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

        //private Athlete oneInCharge;
        //public Athlete OneInCharge
        //{
        //    get { return oneInCharge; }
        //    set
        //    {
        //        SetProperty(ref oneInCharge, value);
        //        (LoadDataCommand as RelayCommand).NotifyCanExecuteChanged();
        //    }
        //}
        public ObservableCollection<Athlete> Competition { get; set; }

        
        //public ICommand ShowLisbox { get; set; }


        

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

        //private Visibility listBoxVisibility = Visibility.Collapsed;

        //public Visibility ListBoxVisibility
        //{
        //    get { return listBoxVisibility; }
        //    set
        //    {
        //        SetProperty(ref listBoxVisibility, value);
        //    }
        //}

        //private void ShowListBox()
        //{
        //    listBoxVisibility = Visibility.Visible;
        //}
        public ICommand AddToCompetitionCommand { get; set; }
        public ICommand LoadDataCommand { get; set; }
        public ICommand RemoveFromCompetitionCommand { get; set; }
        public ICommand OpenAthleteCommand { get; set; }
        public ICommand SaveCommand { get; set; }
        public MainWindowViewModel() : this(IsInDesignMode ? null : Ioc.Default.GetService<IAthleteLogic>())
        {

        }


        public MainWindowViewModel(IAthleteLogic athleteLogic)
        {
            
            this.athleteLogic = athleteLogic;
            
            LoadDataCommand = new RelayCommand(
                () => athleteLogic.LoadData(Athletes, Competition),
                () => Athletes.Count == 0
                );

            Athletes = new ObservableCollection<Athlete>();
            Competition = new ObservableCollection<Athlete>();
            //athleteLogic.SetupCollections(Athletes, Competition);

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
                () => Competition.Count != 0
                );

            Athletes = new ObservableCollection<Athlete>();

            Messenger.Register<MainWindowViewModel, string, string>(this, "AthleteInfo", (recipient, msg) =>
            {

            });
        }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
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
