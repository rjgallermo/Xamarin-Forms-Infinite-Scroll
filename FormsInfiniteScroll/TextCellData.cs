using System;

namespace FormsInfiniteScroll
{
	public class TextCellData {
		public string Text {get;set;}
		public string Detail {get;set;}

		public TextCellData(string t, string d) {
			Text = t;
			Detail = d;
		}
	}
}