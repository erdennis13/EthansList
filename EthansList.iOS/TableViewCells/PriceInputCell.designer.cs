// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace ethanslist.ios
{
	[Register ("PriceInputCell")]
	partial class PriceInputCell
	{
		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MaxPriceField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UITextField MinPriceField { get; set; }

		[Outlet]
		[GeneratedCode ("iOS Designer", "1.0")]
		UILabel PriceLabel { get; set; }

		void ReleaseDesignerOutlets ()
		{
			if (MaxPriceField != null) {
				MaxPriceField.Dispose ();
				MaxPriceField = null;
			}
			if (MinPriceField != null) {
				MinPriceField.Dispose ();
				MinPriceField = null;
			}
			if (PriceLabel != null) {
				PriceLabel.Dispose ();
				PriceLabel = null;
			}
		}
	}
}
