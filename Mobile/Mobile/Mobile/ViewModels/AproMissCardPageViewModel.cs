using Model;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class AproMissCardPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public MissCard MissCardItemSelected { get; set; }
        public bool RefreshingStatus { get; set; }

        public ObservableCollection<MissCard> MissCardItemList { get; set; } = new ObservableCollection<MissCard>();
        //public List<MissCard> MissCardItemList { get; set; } = new List<MissCard>();

        public int RefreshIndex { get; set; } = 0;

        public DelegateCommand MissCardSelectedCommand { get; set; }
        public DelegateCommand MissCardRefreshCommand { get; set; }
        public DelegateCommand AproCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }
        public DelegateCommand<MissCard> YesCommand { get; set; }
        public DelegateCommand<MissCard> NoCommand { get; set; }

        public readonly IPageDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;

        public AproMissCardPageViewModel(IPageDialogService dialogService, INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            var fooApp = App.Current as App;

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            _dialogService = dialogService;

            MissCardRefreshCommand = new DelegateCommand(() =>
            {
                //RefreshIndex++;
                MissCardItemList.Clear();

                Service.BLLService BLL = new Service.BLLService();
                var Datas = BLL.Get_MissCards("111");
                foreach(var data in Datas)
                {
                    MissCardItemList.Add(data);
                }
                RefreshingStatus = false;
            });


            YesCommand = new DelegateCommand<MissCard>((item) => {
                item.apro_yn = "Y";
                item.emp_name = "被改過了";
            });

            NoCommand = new DelegateCommand<MissCard>((item) => {
                item.apro_yn = "N";
            });
        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        {
            MissCardItemList.Clear();

            Service.BLLService BLL = new Service.BLLService();
            var Datas = BLL.Get_MissCards("111");
            foreach (var data in Datas)
            {
                MissCardItemList.Add(data);
            }
        }

    }
}
