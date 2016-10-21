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
	[Register ("TaskViewController")]
	partial class TaskViewController
	{
		[Outlet]
		UIKit.UITextField DatePicker { get; set; }

		[Outlet]
		UIKit.UITextView DescriptionText { get; set; }

		[Outlet]
		UIKit.UITextField TagsText { get; set; }

		[Outlet]
		UIKit.UITextField TitleText { get; set; }
		
		void ReleaseDesignerOutlets ()
		{
			if (TitleText != null) {
				TitleText.Dispose ();
				TitleText = null;
			}

			if (DescriptionText != null) {
				DescriptionText.Dispose ();
				DescriptionText = null;
			}

			if (DatePicker != null) {
				DatePicker.Dispose ();
				DatePicker = null;
			}

			if (TagsText != null) {
				TagsText.Dispose ();
				TagsText = null;
			}
		}
	}
}
