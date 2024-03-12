using Competition.Models;
using Microsoft.Toolkit.Mvvm.Messaging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Logic
{
    public class AthleteLogic : IAthleteLogic
    {
        IList<Athlete> athletes;
        IList<Athlete> competition;
        IMessenger messenger;

        public double AthleteSumMarketValue { get { return (competition == null || competition.Count == 0) ? 0 : competition.Sum(x => x.MarketValue); } }

        public void SetupCollections(IList<Athlete> athletees, IList<Athlete> competition)
        {
            this.athletes = athletees;
            this.competition = competition;
        }

        public void AddToCompetition(Athlete athlete)
        {
            if (!competition.Contains(athlete) && athlete.CompLegal)
            {
                competition.Add(athlete);
                messenger.Send("Athlete Added", "AthleteInfo");
            }

        }
        public void RemoveFromCompetition(Athlete athlete)
        {
            competition.Remove(athlete);
            messenger.Send("Athlete Removed", "AthleteInfo");

        }
        public void OpenAthlete(Athlete athlete)
        {

        }

        public void LoadData(IList<Athlete> athletes)
        {
            this.athletes = athletes;

            athletes.Add(new Athlete()
            {
                Name = "Hosszú Katinka",
                PersonalBest = 12.5,
                YearBest = 13.8,
                CompLegal = true,
                Team = "Ferencvaros"
            });
            athletes.Add(new Athlete()
            {
                Name = "Nagy Dávid",
                PersonalBest = 14.1,
                YearBest = 15.1,
                CompLegal = true,
                Team = "Újpest"
            });
            athletes.Add(new Athlete()
            {
                Name = "Lakatos Lakat",
                PersonalBest = 9.0,
                YearBest = 20.1,
                CompLegal = false,
                Team = "Kisvárda"
            });
            athletes.Add(new Athlete()
            {
                Name = "Lakatos Brendon",
                PersonalBest = 11.1,
                YearBest = 12.7,
                CompLegal = false,
                Team = "NyolckerSK"
            });
            athletes.Add(new Athlete()
            {
                Name = "IV. Ulászló",
                PersonalBest = 30.4,
                YearBest = 40,
                CompLegal = true,
                Team = "TarjánSK"
            });
            athletes.Add(new Athlete()
            {
                Name = "Prepevics Popovics",
                PersonalBest = 12.1,
                YearBest = 15.9,
                CompLegal = true,
                Team = "Honvéd"
            });
            messenger.Send("Athlete Loaded", "AthleteInfo");
        }

        public void Save(string fileName)
        {
            var json = JsonConvert.SerializeObject(competition);
            File.WriteAllText($"{fileName}.json", json);
        }
    }
}
