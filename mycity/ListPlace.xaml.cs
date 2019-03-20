using mycity.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace mycity
{
    /// <summary>
    /// Interaction logic for ListPlace.xaml
    /// </summary>
    public partial class ListPlace : Window
    {
        public ListPlace()
        {
            InitializeComponent();

            LoadGrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Places placeRow = dataGridPlace.SelectedItem as Places;

            using (mycityDbContext context = new mycityDbContext())
            {

                var place = (from p in context.Places where p.PlacesId == placeRow.PlacesId select p).Single();
                context.Places.Remove(place);
                context.SaveChanges();
                MessageBox.Show("Satır silinmiştir.");
                LoadGrid();

            }

        }

        private void LoadGrid()
        {
            using (mycityDbContext context = new mycityDbContext())
            {
                var places = (from p in context.Places select p).ToList();

                dataGridPlace.ItemsSource = places;
            }
        }
    }
}
