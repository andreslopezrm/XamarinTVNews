using System;
using Foundation;
using UIKit;
using System.Diagnostics;

namespace XamarinTVNews
{
    public partial class ViewController : UICollectionViewController
    {

        private Post[] Posts = { };

        public ViewController(IntPtr handle) : base(handle)
        {
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();

            LoadNews();

        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
        }

        [Export("collectionView:cellForItemAtIndexPath:")]
        public override UICollectionViewCell GetCell(UICollectionView collectionView, NSIndexPath indexPath)
        {
            var cell = collectionView.DequeueReusableCell("Cell", indexPath) as NewsCell;

            var post = Posts[indexPath.Row];
            NSUrl url = new NSUrl(post.Thumbnail);


            cell.SetTitle(post.Title);
            cell.GetImage().Load(url);

            return cell;
        }

        [Export("collectionView:numberOfItemsInSection:")]
        public override nint GetItemsCount(UICollectionView collectionView, nint section)
        {
            return Posts.Length;
        }

        [Export("collectionView:didSelectItemAtIndexPath:")]
        public override void ItemSelected(UICollectionView collectionView, NSIndexPath indexPath)
        {

            if (Storyboard.InstantiateViewController("Single") is SingleViewController viewController)
            {
                viewController.Single = Posts[indexPath.Row];
                PresentViewController(viewController, true, null);
            }
        }

        private async void LoadNews() 
        {
            var httpClient = new SimpleHttpClient();
            var response = await httpClient.Get(Constants.BASE_URL);

            var remotePosts = Post.FromJSONArray(response);
   
            Posts = remotePosts;

            CollectionView.ReloadData();

        }
    }

}