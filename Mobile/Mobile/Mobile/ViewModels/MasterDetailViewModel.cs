using HomeMenu;
using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Mobile.ViewModels
{
	public class MasterDetailViewModel : BindableBase
	{
        INavigationService _navigationService;
        
        public MasterDetailViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;

            var masterPageItems = new List<MasterPageItem>();
            masterPageItems.Add(new MasterPageItem
            {
                Title = "關於系統",
                Icon = "\uf0e7",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "第二頁資訊",
                Icon = "\uf1fe",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "系統設定",
                Icon = "\uf085",
            });
            masterPageItems.Add(new MasterPageItem
            {
                Title = "登出",
                Icon = "\uf08b",
            });

            //listView.ItemsSource = masterPageItems;
            MenuItems = masterPageItems;

        }
        
        public List<MasterPageItem> MenuItems { get; set; }

    }
}
