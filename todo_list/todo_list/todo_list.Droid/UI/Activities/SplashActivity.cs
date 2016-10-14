namespace todo_list.Droid.UI.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;

    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.Content.Res;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;

    [Activity(
        Label = "Todo List App",
        MainLauncher = true,
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges =
            ConfigChanges.Orientation | ConfigChanges.ScreenSize |
            ConfigChanges.KeyboardHidden | ConfigChanges.Keyboard
    )]
    public class SplashActivity : Activity
    {
        #region Inner Classes
        #endregion

        #region Constants and Fields
        #endregion

        #region Widgets
        #endregion

        #region Constructors

        public SplashActivity()
        {
        }

        #endregion

        #region Properties

        #endregion

        #region Activity Methods

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            #region Desinger Stuff

            SetContentView(Resource.Layout.ActivitySplash);

            #endregion

            // c#: delegati
            // pattern: async await

            // thread asincrono: quindi non posso fare operazioni visuali
            Task.Factory.StartNew(() =>
                {
                    System.Threading.Thread.Sleep(2000);

                }).ContinueWith((t) =>
                {
                    // specifico un job da fare sincronizzato con thread principale
                    RunOnUiThread(() =>
                    {
                        StartActivity(typeof(MainActivity));
                        Finish(); // termina l'activity corrente in cui sei
                    });
                });


        }

        protected override void OnDestroy()
        {
            base.OnDestroy();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Methods
        #endregion

        #region Event Handlers
        #endregion
    }
}