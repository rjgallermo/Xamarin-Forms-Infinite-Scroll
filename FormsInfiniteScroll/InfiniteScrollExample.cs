using System;
using Xamarin.Forms;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace FormsInfiniteScroll
{
	public class InfiniteScrollExample : ContentPage
	{
		private int itemsPerPage = 20;
		private int pageNumber;
		private bool dataLoading;
		private ObservableCollection<TextCellData> UIData;

		protected override void OnAppearing()
		{
			base.OnAppearing ();
			pageNumber = 0;
			UIData = new ObservableCollection<TextCellData>(FakeWebService.GetData (pageNumber, itemsPerPage));

			var list = new ListView ();
			var cell = new DataTemplate (typeof (TextCell)); 
			cell.SetBinding (TextCell.TextProperty, "Text");
			cell.SetBinding (TextCell.DetailProperty, "Detail");
			list.ItemTemplate = cell;
			list.ItemsSource = UIData;

			list.ItemAppearing += (object sender, ItemVisibilityEventArgs e) => {
				var item = e.Item as TextCellData;
				int index = UIData.IndexOf(item);
				if(UIData.Count - 2 <= index)
					AddNextPageData();
			};
			list.ItemTapped += (sender, args) => {
				System.Diagnostics.Debug.WriteLine ("ItemTapped");
			};

			Content = list;
		}

		private void AddNextPageData() {
			if (dataLoading)
				return;

			dataLoading = true;

			pageNumber++;
			List<TextCellData> nextPage = FakeWebService.GetData (pageNumber, itemsPerPage);
			foreach(var item in nextPage)
				UIData.Add(item);

			dataLoading = false;
		}
	}
}