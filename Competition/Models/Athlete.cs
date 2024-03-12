using Microsoft.Toolkit.Mvvm.ComponentModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.Models
{
    public class Athletee : ObservableObject
    {
        private string name;

        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }

        private double personalBest;

        public double PersonalBest
        {
            get { return personalBest; }
            set { SetProperty(ref personalBest, value); }
        }

        private double yearBest;

        public double YearBest
        {
            get { return yearBest; }
            set { SetProperty(ref yearBest, value); }
        }

        private bool compLegal;

        public bool CompLegal
        {
            get { return compLegal; }
            set { compLegal = value; }
        }



        private string team;

        public string Team
        {
            get { return team; }
            set { SetProperty(ref team, value); }
        }


        public double MarketValue
        {
            get
            {
                return PersonalBest * YearBest;
            }

        }


    }
}
