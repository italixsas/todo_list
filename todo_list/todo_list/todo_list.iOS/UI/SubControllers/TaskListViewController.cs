using System;

using UIKit;

namespace todo_list.iOS
{
	public partial class TaskListViewController : UIViewController
	{
		public TaskListViewController() : base("TaskListViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();

            this.NavigationItem.Title = "Tasks";
            this.NavigationItem.SetRightBarButtonItem(
                new UIBarButtonItem("New", UIBarButtonItemStyle.Plain,
                    (s, e) =>
                    {

                    }), true);

			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);
			
            this.NavigationController.SetNavigationBarHidden(false, true);
        }

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);
		}

		public override void ViewWillUnload()
		{
			base.ViewWillUnload();
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

