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

namespace lab5
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Model1Container db = new Model1Container();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Waindow_Loaded(object sender, RoutedEventArgs e)
        {
            var query = from b in db.Bands
                        select b;

            lbxBands.ItemsSource = query.ToList();
        }

        private void lbxBands_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // band chosen 
            Band selectedBand = lbxBands.SelectedItem as Band;
            //checking null data 
            if (selectedBand != null)
            {
                //display band data
                string bandText = $"Year Formed: {selectedBand.YearFormed}\nMembers: {selectedBand.Members}";
                tbBandInfo.Text = bandText;
                //display band image
                imgBand.Source = new BitmapImage(new Uri($"/image/{selectedBand.BandImage}", UriKind.Relative));
                //display album 
                lbxAlbum.ItemsSource = selectedBand.Albums; 


            }





            //display band image
        }
    }
}
 