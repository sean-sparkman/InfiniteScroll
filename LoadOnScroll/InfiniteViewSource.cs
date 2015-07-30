using System;
using UIKit;
using Foundation;
using System.Collections.Generic;
using System.Linq;

namespace LoadOnScroll
{
	public class InfiniteViewSource
		: UITableViewSource
	{
		Random random = new Random();
		string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
		NSString cellId = new NSString ("SearchResultCell");
		public InfiniteViewSource ()
		{
			Entries = new List<string> ();
		}

		public List<string> Entries { get; set; }

		public override nint RowsInSection (UITableView tableview, nint section)
		{
			return Entries.Count;
		}

		public override UITableViewCell GetCell (UITableView tableView, Foundation.NSIndexPath indexPath)
		{
			var tableCell = tableView.DequeueReusableCell (cellId);

			if (tableCell == null) {
				tableCell = new UITableViewCell (
					UITableViewCellStyle.Subtitle,
					cellId
				);
				tableCell.SelectionStyle = UITableViewCellSelectionStyle.Blue;
				if (tableCell.TextLabel != null) {
					tableCell.TextLabel.TextColor = UIColor.White;
				}
				tableCell.BackgroundColor = UIColor.FromRGB (9, 34, 65);

				var backgroundView = new UIView ();
				backgroundView.BackgroundColor = UIColor.FromRGB (88, 181, 222);
				tableCell.SelectedBackgroundView = backgroundView;

				tableCell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
				tableCell.TintColor = UIColor.White;
			}

		var entry = Entries [indexPath.Row];
			tableCell.TextLabel.Text = entry;

			return tableCell;
		}

		public void GenerateEntries (int count)
		{
			for (int index = 0; index < count; index++) {
				Entries.Add (new string(
					Enumerable.Repeat(chars, 256)
						.Select(s => s[random.Next(s.Length)])
						.ToArray()));
			}
		}

		public override void WillDisplay (UITableView tableView, UITableViewCell cell, NSIndexPath indexPath)
		{
			if (indexPath.Row == Entries.Count - 1) {
				GenerateEntries (25);
				tableView.ReloadData ();
			}
		}
	}
}

