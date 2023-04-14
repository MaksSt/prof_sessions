using Staff_Terminal.Entities;
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
using Microsoft.EntityFrameworkCore;
using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore.Metadata;
using System.ComponentModel;
using System.Data;
using System.IO;
using Microsoft.Win32;
using System.Formats.Asn1;

namespace Staff_Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> statusorder { get; } = new ObservableCollection<string>() { "Принята", "Рассматривается", "Отклонена" };
        public string SearchBoxValue { get; set; } = "";
        MaindbContext db = new MaindbContext();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            db.Dests.Load();


            CollectionViewSourceDestGrid = new CollectionViewSource() { Source = db.Dests.Local.ToObservableCollection() };
            CollectionViewSourceDestGrid.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            ItemList = CollectionViewSourceDestGrid.View;
            DestGrid.ItemsSource = ItemList;
            ComboBoxStatus.ItemsSource = statusorder;
        }
        CollectionViewSource CollectionViewSourceDestGrid;
        ICollectionView ItemList;
        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Dest? t = e.Item as Dest;
            if (t != null)
            {
                if (SearchBoxValue == "")
                {
                    e.Accepted = true;
                    return;
                }
                if (t.Ид == Convert.ToInt32(SearchBoxValue))
                    e.Accepted = true;
                else
                    e.Accepted = false;
            }
        }
        private void SearchBtn(object sender, RoutedEventArgs e)
        {
            ItemList.Refresh();
        }
        private void SaveChangesBtn(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }
        private void ReportBtn(object sender, RoutedEventArgs e)
        {

        }
    }
}