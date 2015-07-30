using System;
using UIKit;
using Foundation;
using System.Linq;

namespace LoadOnScroll
{
	public class TableViewController
		: UITableViewController
	{
		InfiniteViewSource _viewSource;
		public TableViewController ()
		{
		}

		public override void ViewDidLoad ()
		{
			TableView.Source = _viewSource = new InfiniteViewSource ();
			TableView.BackgroundColor = UIColor.FromRGB (88, 181, 222);
		}

		public override void ViewWillAppear (bool animated)
		{
			base.ViewWillAppear (animated);

			_viewSource.GenerateEntries (25);
			TableView.ReloadData ();
			//var index = 1;
			//TableView.InsertRows (Enumerable.Repeat (NSIndexPath.FromRowSection (index++, 0), 25).ToArray (), UITableViewRowAnimation.Bottom);
		}
	}
}

