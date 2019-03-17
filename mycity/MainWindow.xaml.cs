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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace mycity
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnShow_Click(object sender, RoutedEventArgs e)
        {
            mycity.showData showData = new showData();
            showData.Show();

        }

        private void BtnModify_Click(object sender, RoutedEventArgs e)
        {
            mycity.modifyData modifyData = new modifyData();
            modifyData.Show();
        }
    }
}
