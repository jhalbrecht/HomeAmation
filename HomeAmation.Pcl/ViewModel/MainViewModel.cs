using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using HomeAmation.Pcl.Model;
using HomeAmation.Pcl.Service;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace HomeAmation.Pcl.ViewModel
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {

        private readonly IDataService _dataService;
        private readonly IHomeAmationDataService _homeAmationDataService;

        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        public MainViewModel(IHomeAmationDataService homeAmationDataService)
        {
            _homeAmationDataService = homeAmationDataService;
            
            // Refresh(); I moved this to MainPage.xaml.cs so I can test App.HasInternetConnectivity
        }

        private RelayCommand _commandRefresh;

        /// <summary>
        /// Gets the CommandRefresh.
        /// </summary>
        public RelayCommand CommandRefresh
        {
            get
            {
                return _commandRefresh
                    ?? (_commandRefresh = new RelayCommand(
                                    async      () =>
                                        {
                                            await Refresh();
                                        }));
            }
        }

        private async Task Refresh()
        {
            Utility.Log(this, "Refresh");
            Std = await _homeAmationDataService.GetStdAsync();
            Htd = await _homeAmationDataService.GetWeekHtdes();
        }

        //public async Task LoadData()
        //{
        //    Std = await _homeAmationDataService.GetStdAsync();
        //    Htd = await _homeAmationDataService.GetWeekHtdes();
        //}

        /// <summary>
        /// The <see cref="Std" /> property's name.
        /// </summary>
        public const string StdPropertyName = "Std";

        private SummaryTemperatureData _std;

        /// <summary>
        /// Sets and gets the Std property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// </summary>
        public SummaryTemperatureData Std
        {
            get
            {
                return _std;
            }

            set
            {
                if (_std == value)
                {
                    return;
                }

                RaisePropertyChanging(() => Std);
                _std = value;
                RaisePropertyChanged(() => Std);
            }
        }

        /// <summary>
        /// The <see cref="Htd" /> property's name.
        /// </summary>
        public const string HtdPropertyName = "Htd";

        private ObservableCollection<HistoricalTemperatureData> _htd = null;

        /// <summary>
        /// Sets and gets the Htd property.
        /// Changes to that property's value raise the PropertyChanged event. 
        /// This property's value is broadcasted by the MessengerInstance when it changes.
        /// </summary>
        public ObservableCollection<HistoricalTemperatureData> Htd
        {
            get
            {
                return _htd;
            }
            set
            {
                Set(() => Htd, ref _htd, value, true);
            }
        }


        ////public override void Cleanup()
        ////{
        ////    // Clean up if needed

        ////    base.Cleanup();
        ////}
    }
}