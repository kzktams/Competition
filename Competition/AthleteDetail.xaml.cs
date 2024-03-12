using Competition.Models;
using Competition.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Competition
{
    /// <summary>
    /// Interaction logic for AthleteDetail.xaml
    /// </summary>
    public partial class AthleteDetail : Window
    {
        public AthleteDetail()
        {
            InitializeComponent();
            this.DataContext = new AthleteDetailWindowViewModel();
         
        }

    }
}
