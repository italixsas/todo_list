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

    public class LoginFragment : Android.Support.V4.App.Fragment
    {
        #region Inner Classes
        #endregion

        #region Constants and Fields
        #endregion

        #region Widgets

        private Button LoginButton;
        private Button RegisterButton;

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

            this.LoginButton = view.FindViewById<Button>(Resource.Id.LoginButton);

            this.LoginButton.Click += LoginButton_Click;

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
            // autenticazione con servizio rest e se ho risposta positiva navigare sulla task list

            // qui vedi FragmentManager con nome corto ma preso dalla libreria support!
            this.FragmentManager.BeginTransaction()
                .AddToBackStack("before_TaskListFragment") // identificatore nel back stack
                .Replace(Resource.Id.ContentLayout, new TaskListFragment(), "TaskListFragment")
                .Commit();
            
        }



        #endregion
    }
}