using System;
using System.Threading.Tasks;
using System.Linq;
using UIKit;

namespace todo_list.iOS
{
	public partial class SplashViewController : UIViewController
	{
		public SplashViewController() : base("SplashViewController", null)
		{
		}

		public override void ViewDidLoad()
		{
			base.ViewDidLoad();
			// Perform any additional setup after loading the view, typically from a nib.

			this.VersionLabel.Text = "Version 1.0.1";

			// thread asincrono: quindi non posso fare operazioni visuali
			Task.Factory.StartNew(() =>  // .NET services, common on android and ios
				{
					System.Threading.Thread.Sleep(2000);

				}).ContinueWith((t) =>
				{
					// specifico un job da fare sincronizzato con thread principale
					InvokeOnMainThread(() => // was: android: RunOnUiThread
					{
						// was: android: StartActivity(typeof(MainActivity));
						// was: android: Finish(); // termina l'activity corrente in cui sei

						UIApplication.SharedApplication.Windows[0].RootViewController=new MainViewController();
						
					});
				});

		}

		public override void DidReceiveMemoryWarning()
		{
			base.DidReceiveMemoryWarning();
			// Release any cached data, images, etc that aren't in use.
		}
	}
}

