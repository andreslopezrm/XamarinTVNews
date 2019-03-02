using Foundation;
using System;
using UIKit;
using CoreFoundation;

namespace XamarinTVNews
{
    public partial class RemoteImageView : UIImageView
    {
        private NSUrl Url;

        public RemoteImageView (IntPtr handle) : base (handle)
        {
        }

        private NSUrl GetCachesDirectory() {
            var paths = NSFileManager.DefaultManager.GetUrls(NSSearchPathDirectory.CachesDirectory, NSSearchPathDomain.User);
            return paths[0];
        }

        public void Load(NSUrl url) {
            Url = url;

            var absolutePath = new NSString(url.AbsoluteString);

            var savedFileName = absolutePath.CreateStringByAddingPercentEncoding(NSCharacterSet.Alphanumerics);


            var fullPath = GetCachesDirectory().Append(savedFileName, false);

            if (NSFileManager.DefaultManager.FileExists(fullPath.Path)) 
            {
                Image = new UIImage(fullPath.Path);
                return;
            }


            DispatchQueue.GetGlobalQueue(DispatchQueuePriority.Default).DispatchAsync(() =>
            {
                var imageData = NSData.FromUrl(url);

                imageData.Save(url, true);


                if (Url == url)
                {
                    DispatchQueue.MainQueue.DispatchAsync(() => {

                        Image = new UIImage(imageData);

                    });
                }

            });


        }
    }
}