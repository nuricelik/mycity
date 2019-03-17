
using GeoAPI.Geometries;
using Microsoft.Maps.MapControl.WPF;
using mycity.DAL.Models;
using NetTopologySuite;
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
using Microsoft.EntityFrameworkCore;
namespace mycity
{
    /// <summary>
    /// Interaction logic for modifyData.xaml
    /// </summary>
    public partial class modifyData : Window
    {
        public modifyData()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void LstBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
           
        }

        private void MyMap_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            //myMap.ViewportPointToLocation(e.GetPosition(my))
            ////Location location = e.GetPosition().;

            //txtBoxPlaceLatitude.Text = e.GetPosition(myMap).X.ToString();
            //txtBoxPlaceLongitude.Text= e.GetPosition(myMap).Y.ToString();
            //Map myMap=sender as Map;


            Microsoft.Maps.MapControl.WPF.Location l = myMap.ViewportPointToLocation(e.GetPosition(myMap));
            txtBoxPlaceLatitude.Text = l.Latitude.ToString();
            txtBoxPlaceLongitude.Text= l.Longitude.ToString();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
           



            string sql_1=@"INSERT INTO[dbo].[places] ([type],[name],[pic_1_url],[pic_2_url],[tel],[url],[address],[location]) VALUES (";
            sql_1 += "'" + txtBoxPlaceType.Text + "',";   //   type
            sql_1 += "'" + txtBoxPlaceName.Text + "',";    // name
            sql_1 += "'" + "pic1" + "',";           // pic1
            sql_1 += "'" + "pic2" + "',";           // pic2
            sql_1 += "'" + "tel" + "',";           // tel
            sql_1 += "'" + "url" + "',";           // url
            sql_1 += "'" + "adres" + "',";           // address

            sql_1 += "geography::STGeomFromText('POINT(";
            sql_1 += txtBoxPlaceLongitude.Text.Replace(",",".") + " ";
            sql_1 += txtBoxPlaceLatitude.Text.Replace(",", ".");
            sql_1 += ")', 4326))";

            using (mycityDbContext myDbC = new mycityDbContext())
            {
                myDbC.Database.ExecuteSqlCommand(sql_1);
                myDbC.SaveChanges();
            }



            // Places newP = new Places();
            // newP.Name = txtBoxPlaceName.Text;
            // newP.Type = txtBoxPlaceType.Text;
            // {
            //    myDbC.Places.Add(newP);




            //var geometryFactory = NtsGeometryServices.Instance.CreateGeometryFactory(srid: 4326);
            //double lat, lng;
            //lat = Convert.ToDouble(txtBoxPlaceLongitude.Text);
            //lng = Convert.ToDouble(txtBoxPlaceLongitude.Text);

            //Coordinate crd = new Coordinate(lat,lng);
            //var currentLocation = geometryFactory.CreatePoint(crd);

            //newP.Location = currentLocation;

            //using (mycityDbContext myDbC = new mycityDbContext())
            //{
            //    myDbC.Places.Add(newP);
            //    myDbC.SaveChanges();

            //}
        }
    }
    }
