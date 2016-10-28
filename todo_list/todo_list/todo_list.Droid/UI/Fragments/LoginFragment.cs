namespace todo_list.Droid.UI.Fragments
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;

    using Android.App;
    using Android.Content;
    using Android.OS;
    using Android.Runtime;
    using Android.Util;
    using Android.Views;
    using Android.Widget;

    #pragma warning disable CS4014
    public class LoginFragment : Android.Support.V4.App.Fragment
    {
        #region Inner Classes
        #endregion

        #region Constants and Fields
        #endregion

        #region Widgets

        private EditText Username;
        private EditText Password;

        private Button LoginButton;
        private Button RegisterButton;

        private TextView Error;

        #endregion

        #region Constructors

        public LoginFragment()
        {
        }

        #endregion

        #region Properties
        #endregion

        #region Fragment Methods

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            #region Desinger Stuff

            // prende xml e crea gerarchia dei controlli:
            View view = inflater.Inflate(Resource.Layout.FragmentLogin, container, false);

            #endregion

            ((Android.Support.V7.App.AppCompatActivity)this.Activity).SupportActionBar.Hide();

            this.Username = view.FindViewById<EditText>(Resource.Id.UserText);
            this.Password = view.FindViewById<EditText>(Resource.Id.PasswordText);

            this.Error = view.FindViewById<TextView>(Resource.Id.ErrorLabel);

            this.LoginButton = view.FindViewById<Button>(Resource.Id.LoginButton);

            this.LoginButton.Click += LoginButton_Click;

            this.RegisterButton = view.FindViewById<Button>(Resource.Id.RegisterButton);

            this.RegisterButton.Click += RegisterButton_Click;


            return view;
        }


        public override void OnDestroyView()
        {
            base.OnDestroyView();
        }

        #endregion

        #region Public Methods
        #endregion

        #region Methods
        #endregion

        #region Event Handlers

        private void LoginButton_Click(object sender, EventArgs e)
        {
            // I do the Login call and then I exit this method, so I don't block the user interface

            // when the Login call will return... then my correct code will be executed (user)=> or (error)=> ...

            // VisualStudio asks if we want to "await"... but we don't want. So we ignore this warning.

            AppController.Login(this.Username.Text, this.Password.Text,
            (user) =>
            {
                this.Error.Visibility = ViewStates.Invisible;

                // FragmentManager with short name, indeed it is provided by support library

                this.FragmentManager.BeginTransaction()
                    .AddToBackStack("before_TaskListFragment") // identificatore nel back stack
                    .Replace(Resource.Id.ContentLayout, new TaskListFragment(), "TaskListFragment")
                    .Commit();

            },
            (error) =>
            {
                this.Error.Text = error;
                this.Error.Visibility = ViewStates.Visible;
            },
            (exception) =>
            {
                this.Error.Text = exception.Message;
                this.Error.Visibility = ViewStates.Visible;
            });

        }

        private void RegisterButton_Click(object sender, EventArgs e)
        {
            this.FragmentManager.BeginTransaction()
                .AddToBackStack("before_RegistrationFragment") // key in the backstack
                .Replace(Resource.Id.ContentLayout, new RegistrationFragment(), "RegistrationFragment")
                .Commit();
        }

        #endregion
    }
}
