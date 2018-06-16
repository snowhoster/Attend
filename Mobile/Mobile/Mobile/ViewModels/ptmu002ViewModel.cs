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
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Mobile.ViewModels
{
    public class ptmu002ViewModel : INotifyPropertyChanged, INavigationAware
    {


        public string LoginUser;

        public event PropertyChangedEventHandler PropertyChanged;
        public MissCard MissCardItemSelected { get; set; }
        public bool RefreshingStatus { get; set; }

        public ObservableCollection<MissCardVM> MissCardItemList { get; set; } = new ObservableCollection<MissCardVM>();
        //public List<MissCard> MissCardItemList { get; set; } = new List<MissCard>();

            

        public int RefreshIndex { get; set; } = 0;

        public DelegateCommand MissCardSelectedCommand { get; set; }
        public DelegateCommand MissCardRefreshCommand { get; set; }
        public DelegateCommand AcceptCommand { get; set; }
        public DelegateCommand ExitCommand { get; set; }
        public DelegateCommand<MissCardVM> YesCommand { get; set; }
        public DelegateCommand<MissCardVM> NoCommand { get; set; }

        public readonly IPageDialogService _dialogService;

        private readonly INavigationService _navigationService;

        private readonly IEventAggregator _eventAggregator;

        public ptmu002ViewModel(IPageDialogService dialogService, INavigationService navigationService,
            IEventAggregator eventAggregator)
        {
            var fooApp = App.Current as App;

            _eventAggregator = eventAggregator;
            _navigationService = navigationService;
            _dialogService = dialogService;

            MissCardRefreshCommand = new DelegateCommand(async () =>
            {
                ////RefreshIndex++;
                //MissCardItemList.Clear();

                //Service.BLLService BLL = new Service.BLLService();
                //var Datas = BLL.Get_MissCards("111");
                //foreach (var data in Datas)
                //{


                //    var foo = new MissCardVM
                //    {
                //        emp = data.emp,
                //        emp_name = data.emp_name,
                //        attd_date = data.attd_date,
                //        attd_time = data.attd_time,
                //        apro_yn = data.apro_yn

                //    };


                //    MissCardItemList.Add(foo);
                //}


                //MissCardItemList.Clear();

                //Service.BLLService BLL = new Service.BLLService();
                ////  var Datas =  BLL.Get_MissCards("111");

                //var apro = new AproRequest
                //{
                //    apro_emp = "085869"

                //};
                //var Datas = await BLL.Get_MissCardsTest(apro);
                //foreach (var data in Datas)
                //{

                //    var foo = new MissCardVM
                //    {
                //        emp = data.emp,
                //        emp_name = data.emp_name,
                //        attd_date = data.attd_date,
                //        attd_time = data.attd_time,
                //        apro_yn = data.apro_yn

                //    };




                //    MissCardItemList.Add(foo);
                //}

                await ReLoadData();
                RefreshingStatus = false;
            });


            YesCommand = new DelegateCommand<MissCardVM>((item) => {
                item.apro_yn = "Y";
                // item.emp_name = "被改過了";


                item.testColor = Color.AliceBlue;

            });

            NoCommand = new DelegateCommand<MissCardVM>((item) => {
                item.apro_yn = "N";
                item.testColor = Color.Red;
            });







            AcceptCommand = new DelegateCommand(async () =>
            {
                var apro = new AproRequest
                {
                    // apro_emp = "085869"

                    apro_emp = LoginUser

                };

                List<AproData> ls_MissCardList = new List<AproData>();

                foreach (var data in MissCardItemList)
                {

                    if (data.apro_yn == "Y" || data.apro_yn == "N")
                    {
                        //  data.emp_name = "改了";




                        var foo = new AproData
                        {
                            emp = data.emp,
                            attd_date = data.attd_date,
                            attd_time = data.attd_time,
                            apro_yn = data.apro_yn

                        };

                        ls_MissCardList.Add(foo);

                    }



                }


                apro.misscards = ls_MissCardList;


                Service.BLLService BLL = new Service.BLLService();
                bool result = await BLL.Set_MissCards(apro);

                await ReLoadData();

            }
                    );




            ExitCommand = new DelegateCommand(() =>
            {
                // _navigationService.NavigateAsync("/NavigationPage/MainPage/AproMissCardPage");
                _navigationService.NavigateAsync("/NavigationPage/MainPage");
            });


        }


        private async Task ReLoadData()
        {

            MissCardItemList.Clear();

            Service.BLLService BLL = new Service.BLLService();
            //  var Datas =  BLL.Get_MissCards("111");

            var apro = new AproRequest
            {
               //  apro_emp = "085869"
               apro_emp = LoginUser

            };
            var Datas = await BLL.Get_MissCards(apro);
            foreach (var data in Datas)
            {

                var foo = new MissCardVM
                {
                    emp = data.emp,
                    emp_name = data.emp_name,
                    attd_date = data.attd_date,
                    attd_time = data.attd_time,
                    apro_yn = data.apro_yn

                };




                MissCardItemList.Add(foo);
            }


        }


        public void OnNavigatedFrom(NavigationParameters parameters)
        {

        }

        public void OnNavigatingTo(NavigationParameters parameters)
        {

        }

        public async void OnNavigatedTo(NavigationParameters parameters)
        //public  void OnNavigatedTo(NavigationParameters parameters)
        {

            LoginUser = parameters["Empid"] as string;



            await ReLoadData();
        }

    }



}

