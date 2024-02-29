using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using Andrusenko_WPF_1.Tools;

namespace Andrusenko_WPF_1.ViewModels
{
    class DateViewModel : INotifyPropertyChanged
    {
        public RelayCommand<object> _calculateAgeCommand;

        private DateTime _dateOfBirth = DateTime.Today;
        private string _calculatedAge = "";
        private string _westernZodiacSign = "";
        private string _chineseZodiacSign = "";

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DateTime DateOfBirth
        {
            get { return _dateOfBirth; }
            set {
                _dateOfBirth = value;
                OnPropertyChanged();
            }
        }

        public string CalculatedAge
        { 
            get { return _calculatedAge; }
            set { 
                _calculatedAge = value;
                OnPropertyChanged();
            }
        }

        public string WesternZodiacSign
        {
            get { return _westernZodiacSign; }
            set { _westernZodiacSign = value; OnPropertyChanged(); }
        }

        public string ChineseZodiacSign
        {
            get { return _chineseZodiacSign; }
            set { _chineseZodiacSign = value; OnPropertyChanged(); }
        }


        public RelayCommand<object> CalculateAgeCommand
        {
            get
            {
                return _calculateAgeCommand ??= new RelayCommand<object>(_ => CalculateAge(), CanExecute);
            }
        }

        private void CalculateAge()
        {
            Console.WriteLine("Hello from calculate age method");
            DateTime today = DateTime.Today;
            var age = today.Year - DateOfBirth.Year;
            if (DateOfBirth.Date > today.AddYears(-age))
                age--;


            if (age < 0 || age > 135)
            {
                CalculatedAge = "Invalid age";
                MessageBox.Show("Invalid age");
                return;
            }

            CalculatedAge = $"Your age is {age}. ";

            if (DateOfBirth.Month == today.Month && DateOfBirth.Day == today.Day)
                CalculatedAge += "Happy birthday!";

            WesternZodiacSign = $"Western zodiac sign: {GetWesternZodiacSign(DateOfBirth)}";
            ChineseZodiacSign = $"Chinese zodiac sign: {GetChineseZodiacSign(DateOfBirth.Year)}"; 

        }

        private string GetWesternZodiacSign(DateTime dateOfBirth)
        {
            if (DateTime.Compare(new DateTime(dateOfBirth.Year, 1, 21), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 2, 19), dateOfBirth) >= 0)
            {
                return "Aquarius";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 2, 20), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 3, 20), dateOfBirth) >= 0)
            {
                return "Pisces";
            }
            else if(DateTime.Compare(new DateTime(dateOfBirth.Year, 3, 21), dateOfBirth)<=0&&DateTime.Compare(new DateTime(dateOfBirth.Year, 4, 20), dateOfBirth) >= 0){
                return "Aries";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 4, 21), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 5, 21), dateOfBirth) >= 0)
            {
                return "Taurus";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 5, 22), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 6, 21), dateOfBirth) >= 0)
            {
                return "Gemini";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 6, 22), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 7, 23), dateOfBirth) >= 0)
            {
                return "Cancer";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 7, 24), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 8, 23), dateOfBirth) >= 0)
            {
                return "Leo";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 8, 24), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 9, 23), dateOfBirth) >= 0)
            {
                return "Virgo";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 9, 24), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 10, 23), dateOfBirth) >= 0)
            {
                return "Libra";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 10, 24), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 11, 22), dateOfBirth) >= 0)
            {
                return "Scorpio";
            }
            else if (DateTime.Compare(new DateTime(dateOfBirth.Year, 11, 23), dateOfBirth) <= 0 && DateTime.Compare(new DateTime(dateOfBirth.Year, 12, 21), dateOfBirth) >= 0)
            {
                return "Sagittarius";
            }
            else
            {
                return "Capricorn";
            }
        }

        private string GetChineseZodiacSign(int year)
        {
            switch (year % 12)
            {
                case 0: 
                    return "Monkey";
                case 1: 
                    return "Rooster";
                case 2: 
                    return "Dog";
                case 3:
                    return "Pig";
                case 4:
                    return "Rat";
                case 5:
                    return "Ox";
                case 6:
                    return "Tiger";
                case 7:
                    return "Rabbit";
                case 8:
                    return "Dragon";
                case 9:
                    return "Snake";
                case 10:
                    return "Horse";
                default:
                    return "Goat";
            }
        }

        private bool CanExecute(object obj)
        {
            return true;
        }
    }
}
