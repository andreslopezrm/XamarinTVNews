using Foundation;
using System;
using UIKit;

namespace XamarinTVNews
{
    public partial class NewsCell : UICollectionViewCell
    {
        public NewsCell (IntPtr handle) : base (handle)
        {
        }

        public void SetTitle(String title) 
        {
            TitleLabel.Text = title;
        }

        public RemoteImageView GetImage() 
        {
            return ImageView;
        }
    }
}