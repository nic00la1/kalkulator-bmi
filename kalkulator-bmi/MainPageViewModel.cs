using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace kalkulator_bmi
{
    internal class MainPageViewModel : INotifyPropertyChanged
    {
        private double weight = 70;
        private double height = 150;
        private const double Step = 1.0;

        public double Height
        {
            get => height;
            set
            {
                height = NextStep(value);
                UpdateBMI();
            }
        }

        public double Weight
        {
            get => weight;
            set
            {
                weight = NextStep(value);
                UpdateBMI();
            }
        }

        public double Bmi
            => Math.Round(Weight / Math.Pow(Height / 100, 2), 2);

        public string Classification
        {
            get
            {
                if (Bmi < 18.5)
                    return "Masz niedowagę!";
                else if (Bmi < 25)
                    return "Prawidłowa waga :)";
                else if (Bmi < 30)
                    return "Masz nadwagę";
                else
                    return "Masz obsesję! Przestań jeść!!!";
            }

        }

        private void UpdateBMI()
        {
            RaisePropertyChanged(nameof(Bmi));
            RaisePropertyChanged(nameof(Classification));
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string v)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(v));
        }

        private double NextStep(double value)
            => Math.Round(value / Step) * Step;

    }
}