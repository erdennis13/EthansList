using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;
using EthansList.Shared;
using CoreGraphics;
using SDWebImage;

namespace ethanslist.ios
{
	partial class postingImageViewController : UIViewController
	{
		public postingImageViewController (IntPtr handle) : base (handle)
		{
		}

        Posting post;
        public Posting Post
        {
            get { 
                return post;
            }
            set { 
                post = value;
            }
        }

        public string ImageLink { get; set; }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            this.View.BackgroundColor = UIColor.DarkGray;
            myScrollView.Frame = new CGRect(0, 0, View.Frame.Width, View.Frame.Height);

            if (post.ImageLink != "-1")
            {
                myImageView.SetImage(
                    url: new NSUrl(ImageLink),
                    placeholder: UIImage.FromBundle("placeholder.png")
                );
            }


            myScrollView.MaximumZoomScale = 3f;
            myScrollView.MinimumZoomScale = .1f;
            myScrollView.ViewForZoomingInScrollView += (UIScrollView sv) => { return myImageView; };

            UITapGestureRecognizer doubletap = new UITapGestureRecognizer(OnDoubleTap) 
            {
                NumberOfTapsRequired = 2 // double tap
            };
            myScrollView.AddGestureRecognizer(doubletap); // detect when the scrollView is double-tapped

            UISwipeGestureRecognizer dismissSwipe = new UISwipeGestureRecognizer(OnDismissSwipe)
            {
                    Direction = UISwipeGestureRecognizerDirection.Down
            };
            View.AddGestureRecognizer(dismissSwipe); // detect when the scrollView is swiped down
        }

        private void OnDoubleTap (UIGestureRecognizer gesture) {
            myScrollView.SetZoomScale(1, true);
        }

        private void OnDismissSwipe (UIGestureRecognizer gesture) {
            this.DismissViewController(true, null);
        }
	}
}
