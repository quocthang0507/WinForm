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
				cbx_country.ItemsSource = table.ToList().OrderBy(i => i.CommonName);
				cbx_country.DisplayMemberPath = "CommonName";
			}
		}

		private void Load_Province(int id)
		{
			using (var database = new DonViHanhChinhEntities())
			{
				var table = from data in database.Provinces.Cast<Province>() where data.CountryId.Equals(id) select data;
				cbx_province.ItemsSource = table.ToList().OrderBy(i => i.Name);
				cbx_province.DisplayMemberPath = "Name";
			}
		}

		private void Load_District(int id)
		{
			using (var database = new DonViHanhChinhEntities())
			{
				var table = from data in database.Districts.Cast<District>() where data.ProvinceId.Equals(id) select data;
				cbx_district.ItemsSource = table.ToList().OrderBy(i => i.Name);
				cbx_district.DisplayMemberPath = "Name";
			}
		}

		private void Load_Ward(int id)
		{
			using (var database = new DonViHanhChinhEntities())
			{
				var table = from data in database.Wards.Cast<Ward>() where data.DistrictID.Equals(id) select data;
				cbx_ward.ItemsSource = table.ToList().OrderBy(i => i.Name);
				cbx_ward.DisplayMemberPath = "Name";
			}
		}

		private void Cbx_country_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			Country selected = (Country)cbx_country.SelectedItem;
			if (selected != null)
				Load_Province(selected.Id);
		}

		private void Cbx_province_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			Province selected = (Province)cbx_province.SelectedItem;
			if (selected != null)
				Load_District(selected.Id);
		}

		private void Cbx_district_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
		{
			District selected = (District)cbx_district.SelectedItem;
			if (selected != null)
				Load_Ward(selected.Id);
		}
	}
}
