// WARNING
//
// This file has been generated automatically by Xamarin Studio to store outlets and
// actions made in the UI designer. If it is removed, they will be lost.
// Manual changes to this file may not be handled correctly.
//
using Foundation;
using System.CodeDom.Compiler;

namespace todo_list.iOS
{
	[Register ("TaskListViewController")]
	partial class TaskListViewController
	{
		[Outlet]
		UIKit.UITableView TaskList { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TaskList != null) {
				TaskList.Dispose ();
				TaskList = null;
			}
		}
	}
}
