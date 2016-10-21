using System;

using UIKit;

namespace todo_list.iOS
{
	public partial class LoginViewController : UIViewController
	{
		// primo parametro string associa al controller lo xib giusto
		// lo xib funge per noi da view
		public LoginViewController() : base("LoginViewController", null) 
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.
		}

		public override void ViewWillAppear(bool animated)
		{
			base.ViewWillAppear(animated);

			this.NavigationController.NavigationBarHidden = true;

			this.LoginButton.TouchUpInside += LoginButton_TouchUpInside;

		}

		public override void ViewWillDisappear(bool animated)
		{
			base.ViewWillDisappear(animated);

			// deteach from events: important!
			this.LoginButton.TouchUpInside -= LoginButton_TouchUpInside;
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

		void LoginButton_TouchUpInside(object sender, EventArgs e)
		{
			this.NavigationController.PushViewController(new TaskListViewController(), true); // true == with animation
		}
	}
}

