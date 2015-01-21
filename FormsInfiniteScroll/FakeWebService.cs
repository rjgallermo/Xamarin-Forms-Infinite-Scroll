using System;
using System.Collections.Generic;

namespace FormsInfiniteScroll
{
	public static class FakeWebService
	{
		public static List<TextCellData> GetData(int pageNumber, int pageLength) {
			List<TextCellData> data = new List<TextCellData> ();

			for (int i = (pageNumber * pageLength); i < (pageNumber + 1) * pageLength; i++) {
				data.Add (new TextCellData("Item " + i.ToString (), "Infinite Scroll Example"));
			}

			return data;
		}
	}
}