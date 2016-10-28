namespace todo_list.Droid.UI.Activities
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Android.App;
    using Android.Content;
    using Android.Content.PM;
    using Android.Content.Res;
    using Android.OS;
    using Android.Runtime;
    using Android.Views;
    using Android.Widget;
    using Fragments;

    // i seguenti attributi verranno forzati nel manifest
    // in realtà potrei svuotarli e fare tutto li, per non avere due posti in cui sono configurate le cose
    [Activity(
        Label = "YourAppNameHere",
        Theme = "@style/Theme.AppCompat.Light",
        ScreenOrientation = ScreenOrientation.Portrait,
        ConfigurationChanges =
            ConfigChanges.Orientation | ConfigChanges.ScreenSize |
            ConfigChanges.KeyboardHidden | ConfigChanges.Keyboard
    )]
    
    public class MainActivity : Android.Support.V7.App.AppCompatActivity
    {
        #region Inner Classes
        #endregion

        #region Constants and Fields
        #endregion

        #region Widgets

        // Solo se usata con tema custom dove viene aggiunta manualmente
        private Android.Support.V7.Widget.Toolbar Toolbar;

        #endregion

        #region Constructors

        public MainActivity()
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

            SetContentView(Resource.Layout.ActivityMain);

            //this.Toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.Toolbar);
            //SetSupportActionBar(this.Toolbar); // in realta' ci sta gia' arrivando dal tema

            #endregion

            // todo: controllare se si trova in situazione pulita da zero
            // oppure se ha ripristinato lui i fragments e quindi trovo gia' qualcosa impostato

            this.SupportFragmentManager.BeginTransaction()
                .Add(Resource.Id.ContentLayout, new LoginFragment(), "LoginFragment")
                .Commit();
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