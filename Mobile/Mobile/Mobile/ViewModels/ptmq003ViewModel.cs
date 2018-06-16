using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

namespace Mobile.ViewModels
{
    public class ptmq003ViewModel : INotifyPropertyChanged, INavigationAware
    {
        public string LoginUser { get; set; }
        public string Ename { get; set; }
        public event PropertyChangedEventHandler PropertyChanged;

        public readonly IPageDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;

        public ptmq003ViewModel(IPageDialogService dialogService, INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            var fooApp = App.Current as App;

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            _dialogService = dialogService;

        }

        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public void OnNavigatedTo(NavigationParameters parameters)
        //public  void OnNavigatedTo(NavigationParameters parameters)
        {

            string LoginUser2 = parameters["Empid"] as string;
            LoginUser = LoginUser2;
            string Ename2 = parameters["EmpName"] as string;
            Ename = Ename2;
        }

    }



}
