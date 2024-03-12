using Competition.Models;
using System.Collections.Generic;

namespace Competition.Logic
{
    public interface IAthleteLogic
    {
        double AthleteSumMarketValue { get; }

        void AddToCompetition(Athlete athlete);
        void LoadData(IList<Athlete> athletes);
        void OpenAthlete(Athlete athlete);
        void RemoveFromCompetition(Athlete athlete);
        void Save(string fileName);
        void SetupCollections(IList<Athlete> athletees, IList<Athlete> competition);
    }
}