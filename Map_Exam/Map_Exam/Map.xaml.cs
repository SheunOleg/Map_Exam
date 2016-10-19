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
using GMap.NET;
using GMap.NET.MapProviders;
using GMap.NET.WindowsPresentation;

namespace Map_Exam
{
    /// <summary>
    /// Логика взаимодействия для Map.xaml
    /// </summary>
    public partial class Map : Window
    {
        List<PointLatLng> Lpll = new List<PointLatLng>();
        public Map()
        {
            InitializeComponent();
        }

        private void gmap_Loaded(object sender, RoutedEventArgs e)
        {
            gmap.MapProvider = BingMapProvider.Instance;
            gmap.SetPositionByKeywords("Paris, France");
        }

        private void gmap_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Point p = e.GetPosition(gmap);
            PointLatLng pll = gmap.FromLocalToLatLng((int)p.X, (int)p.Y);
            Lpll.Add(pll);
            GMapMarker gmm = new GMapMarker(pll);
            gmm.Shape = new Ellipse() { Width = 10, Height = 10, Fill = Brushes.Red };
            gmap.Markers.Add(gmm);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            RoutingProvider rp = gmap.MapProvider as RoutingProvider;
            List<PointLatLng> ps = new List<PointLatLng>();
            for (int i = 0; i < Lpll.Count - 1; i++)
            {
                MapRoute r = rp.GetRoute(Lpll[i], Lpll[i + 1], false, true, 13);
                ps.AddRange(r.Points);
            }
            GMapRoute mapRoute = new GMapRoute(ps);
            gmap.Markers.Add(mapRoute);
            gmap.ZoomAndCenterMarkers(13);
        }

        bool b = false;
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (b)
            {
                MenuLeft.Width = new GridLength(150);
                MenuRight.Width = new GridLength(150);
            }
            else
            {
                MenuLeft.Width = new GridLength(0);
                MenuRight.Width = new GridLength(0);
            }
            b = !b;
        }

    }
}
