using AutocompleteMenuNS;
using System.Windows.Forms;

namespace RichtextBox_Autocomplete
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();
			autocompleteMenu1.AddItem(new EmailSnippet("nguyenthao_it@hotmail.com.vn"));
			autocompleteMenu1.AddItem(new EmailSnippet("hoangtunho2015@gmail.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("vimotnguoiradi@yahoo.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("quaconme@gmail.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("tinhnhatphai@gmail.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("duongqua@gmail.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("tieulongnu@gmail.com"));
			autocompleteMenu1.AddItem(new EmailSnippet("hongthatcong@gmail.com"));
		}

		internal class EmailSnippet : AutocompleteItem
		{
			public EmailSnippet(string email) : base(email)
			{
				ImageIndex = 0;
				ToolTipTitle = "Insert email:";
				ToolTipText = email;
			}

			public override CompareResult Compare(string fragmentText)
			{
				if (fragmentText == Text)
					return CompareResult.VisibleAndSelected;
				if (fragmentText.Contains("@"))
					return CompareResult.Visible;
				return CompareResult.Hidden;
			}
		}
	}
}
