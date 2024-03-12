using Competition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Services
{
    public class AthleteService : IAthleteService
    {
        public void Edit(Athlete athlete)
        {
            new AthleteDetail(athlete).ShowDialog();
        }
    }
}
