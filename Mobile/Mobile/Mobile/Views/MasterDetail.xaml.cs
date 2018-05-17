using HomeMenu;
using Xamarin.Forms;

namespace Mobile.Views
{
    public partial class MasterDetail : MasterDetailPage
    {

        public MasterDetail()
        {
            InitializeComponent();
            listView.ItemSelected += ListView_ItemSelected;
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var item = e.SelectedItem as MasterPageItem;
            if (item != null)
            {
                if (item.Title == "關於系統")
                {
                    Detail = new NavigationPage(new About());
                    var fooPage = this.Master;
                    IsPresented = false;
                    listView.SelectedItem = null;
                }
                else if (item.Title == "第二頁資訊")
                {
                    Detail = new NavigationPage(new MainPage());
                    var fooPage = this.Master;
                    IsPresented = false;
                    listView.SelectedItem = null;
                }
                else if (item.Title == "系統設定")
                {
                    Detail = new NavigationPage(new MainPage());
                    IsPresented = false;
                    listView.SelectedItem = null;
                }
                else if (item.Title == "登出")
                {
                    App.Current.MainPage = new MainPage();
                }
            }
        }
    }
}