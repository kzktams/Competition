using Competition.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Competition.ViewModels
{
    public class AthleteDetailWindowViewModel
    {

        public Athlete Actual {  get; set; }

        public void Setup(Athlete athlete)
        {
            this.Actual = athlete;
        }

        public AthleteDetailWindowViewModel()
        {
            
        }
    }
}
