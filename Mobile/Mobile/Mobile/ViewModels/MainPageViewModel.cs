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
#if DEBUG
            //EmpId = "040407";
            //EmpName = "謝正順";

            EmpId = "085869";
            EmpName = "許原賓";

#endif

            _navigationService = navigationService;
            NavigationParameters para = new NavigationParameters
            {
                { "Empid", EmpId },
                { "EmpName", EmpName},
            };

            MissPunchInCommand = new DelegateCommand(() =>
            {
                
            });

            //主管確認補登刷卡
            ConfirmPunchInCommand = new DelegateCommand(() =>
            {
                // _navigationService.NavigateAsync("/NavigationPage/MainPage/AproMissCardPage");
                _navigationService.NavigateAsync("/NavigationPage/MainPage/ptmu002", para);
            });
            QryPunchInOutCommand = new DelegateCommand(() =>
            {
                
            });
            QryDayOffCommand = new DelegateCommand(() =>
            {
                _navigationService.NavigateAsync("/NavigationPage/MainPage/ptmq003", para);
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
            //應該要在這邊接員工號跟員工姓名?
        }

    }
}
