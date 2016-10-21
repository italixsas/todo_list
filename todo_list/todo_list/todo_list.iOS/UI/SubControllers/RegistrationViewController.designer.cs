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
	[Register ("RegistrationViewController")]
	partial class RegistrationViewController
	{
		[Outlet]
		UIKit.UITextField EmailText { get; set; }

		[Outlet]
		UIKit.UITextField PasswordText { get; set; }

		[Outlet]
		UIKit.UIButton RegisterButton { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (EmailText != null) {
				EmailText.Dispose ();
				EmailText = null;
			}

			if (PasswordText != null) {
				PasswordText.Dispose ();
				PasswordText = null;
			}

			if (RegisterButton != null) {
				RegisterButton.Dispose ();
				RegisterButton = null;
			}
		}
	}
}
