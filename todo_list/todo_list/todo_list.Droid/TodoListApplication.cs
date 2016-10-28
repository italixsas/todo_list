using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace todo_list.Droid
{
#if DEBUG
    [Application(Name = "todo_list.Droid.TodoListApplication")]
#else
    [Application(Name = "todo_list.Droid.TodoListApplication", Debuggable = false)]
#endif
    public class TodoListApplication : Application
    {
        public override void OnCreate()
        {
            base.OnCreate();

            string dbPath = System.IO.Path.Combine(Android.App.Application.Context.GetExternalFilesDir(null).Path, "todo_list.db3");
            AppController.InitSQLite(dbPath);

        }

        protected TodoListApplication(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }
    }
}