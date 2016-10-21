using System;

using UIKit;

namespace todo_list.iOS
{
	public partial class MainViewController : UINavigationController  // was: UIViewController
	{
		public MainViewController() // was:   : base("MainViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.PushViewController(new LoginViewController(), false);  // false == no animation			
		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

