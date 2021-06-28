using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Reactive.Market
{
    public class MarketV1 : INotifyPropertyChanged
    {
        private float volatility = 0;
        public float Volatility
        {
            get => volatility;
            set
            {
                if (value.Equals(volatility)) return;
                volatility = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}