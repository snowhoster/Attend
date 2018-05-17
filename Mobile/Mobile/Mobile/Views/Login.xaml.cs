using CSBC.Settings;
using Service;
using Xamarin.Forms;

namespace Mobile.Views
{
    public partial class Login : ContentPage
    {
        public Login()
        {
            InitializeComponent();

            swRember.IsToggled = Settings.isRemember;
            txtAccount.Text = Settings.Account;
#if DEBUG
            txtAccount.Text = "12345";
            txtPwd.Text = "12345";
#endif

            ButLogin.Clicked += ButLogin_Clicked;
        }


        private void ButLogin_Clicked(object sender, System.EventArgs e)
        {
            if (string.IsNullOrEmpty(txtAccount.Text))
            {
                this.DisplayAlert("提示", "帳號未輸入", "確定");
                return;
            }
            if (string.IsNullOrEmpty(txtPwd.Text))
            {
                this.DisplayAlert("提示", "密碼未輸入", "確定");
                return;
            }

            if (this.swRember.IsToggled)
            {
                Settings.Account = this.txtAccount.Text;
                Settings.isRemember = this.swRember.IsToggled;
            }
            BLLService BLL = new BLLService();

            bool result = BLL.Login(txtAccount.Text, txtPwd.Text);

            if (result)
            {
                App.Current.MainPage = new MasterDetail();
            }
            else
            {
                this.DisplayAlert("提示", "帳號密碼錯誤", "確定");
                return;
            }
        }
    }
}
