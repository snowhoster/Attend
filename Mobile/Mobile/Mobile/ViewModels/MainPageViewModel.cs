using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

namespace Mobile.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged, INavigationAware
    {
        #region 宣告

        public event PropertyChangedEventHandler PropertyChanged;

        private readonly INavigationService _navigationService;

        public string EmpId { get; set; }

        public string EmpName { get; set; }

        public DelegateCommand MissPunchInCommand { get; set; }

        public DelegateCommand ConfirmPunchInCommand { get; set; }

        public DelegateCommand QryPunchInOutCommand { get; set; }

        public DelegateCommand QryDayOffCommand { get; set; }

        #endregion

        public MainPageViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;
            MissPunchInCommand = new DelegateCommand(() =>
            {
                var a = 1;
            });
            ConfirmPunchInCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("/NavigationPage/MainPage/AproMissCardPage");
            });
            QryPunchInOutCommand = new DelegateCommand(() =>
            {
                var a = 1;
            });
            QryDayOffCommand = new DelegateCommand(() =>
            {
                var a = 1;
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

        }

    }
}
