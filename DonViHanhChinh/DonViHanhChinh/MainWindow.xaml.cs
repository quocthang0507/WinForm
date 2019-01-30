using System.Linq;
using System.Windows;

namespace DonViHanhChinh
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{

		public MainWindow()
		{
			InitializeComponent();
			Load_Country();
		}

		public void Load_Country()
		{
			using (var database = new DonViHanhChinhEntities())
			{
				var table = from data in database.Countries.Cast<Country>() select data;
				cbx_country.ItemsSource = table.ToList();
				cbx_country.DisplayMemberPath = "CommonName";
			}
		}

		private void Load_Province(int id)
		{
			using (var database = new DonViHanhChinhEntities())
			{
				var table = from data in database.Provinces.Cast<Province>() where data.CountryId.Equals(id) select data;
				cbx_province.ItemsSource = table.ToList();
				cbx_province.DisplayMemberPath = "Name";
			}
		}

		private void Load_District(string province)
		{

		}

		private void Load_Ward(string province, string district)
		{

		}

		private void Cbx_country_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			Country selected = (Country)cbx_country.SelectedItem;
			Load_Province(selected.Id);
		}
	}
}
