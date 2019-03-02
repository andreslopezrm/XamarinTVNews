using Foundation;
using System;
using UIKit;

namespace XamarinTVNews
{
    public partial class SingleViewController : UIViewController
    {

        public Post Single { get; set; }

        public SingleViewController(IntPtr handle) : base(handle)
        {
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            Load();

        }

        private void Load() 
        {
           if (Single != null) 
           {

                NSNumber[] touches = new NSNumber[1];
                touches[0] = 1;

                BodyTextView.PanGestureRecognizer.AllowedTouchTypes = touches;
                BodyTextView.Selectable = true;

                TitleLabel.Text = Single.Title;
                BodyTextView.Text = Single.Body;

                NSUrl url = new NSUrl(Single.Thumbnail);
                ThumbnailImage.Load(url);
            }
        }
    }
}