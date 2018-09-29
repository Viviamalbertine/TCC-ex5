using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OProjeto.FrontEndClasses
{
    public class Platform { }
    public class StatusBar { }
    public class SplashScreen { }
    public class HttpClient { }
    public class Observable<T> { }
    public class any { }
    public class NavParams { }
    public class NavController { }
    public class LoadingController { }
    public class ToastController { }
    public class FormBuilder { }
    public class FormGroup { }
    public class ElementRef { }

    /////////////////////////////////////

    public class AppModule {}

    public class MyApp
    {
        public Type LoginPage;
        private Platform platform;
        private StatusBar statusBar;
        private SplashScreen splashScreen;

        public MyApp(Platform platform, StatusBar statusBar, SplashScreen splashScreen)
        {

        }
    }

    public class LoginPage
    {
        private NavController navCtrl;
        private NavParams navParams;
        private ToastController toastCtrl;
        private LoadingController loadingCtrl;
        private FormBuilder formBuilder;
        private AuthenticationService authService;
        private ElementRef loadingSpinner;
        private FormGroup loginForm;

        public LoginPage(NavController navCtrl,
              NavParams navParams,
              ToastController toastCtrl,
              LoadingController loadingCtrl,
              FormBuilder formBuilder,
              AuthenticationService authService)
        {
        }

        public void initForm() { }

        public void onSubmit() { }

        private void displayToast(string message, string position = "top", int duration = 5000)
        {

        }
    }

    public class LoginSuccessfulPage
    {
        private NavController navCtrl;
        private NavParams navParams;

        public LoginSuccessfulPage(NavController navCtrl, NavParams navParams)
        {
        }
    }

    public interface OperationResult
    {
        bool? success { get; set; }
        string code { get;set; }
        string message { get; set; }
    }

    public interface Login
    {
        string email { get; set; }
        string password { get; set; }
    }

    public class AuthenticationService
    {
        private HttpClient http;

        public AuthenticationService(HttpClient http)
        {

        }

        public Observable<any> Authenticate(Login login)
        {
            return null;
        }
    }
}
