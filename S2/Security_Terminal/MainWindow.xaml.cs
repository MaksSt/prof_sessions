using Security_Terminal.Entities;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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

namespace Security_Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> statuster { get; } = new ObservableCollection<string>() { "Есть", "Нету" };
        public string SearchBoxValue { get; set; } = "";
        public ObservableCollection<Dest> destsx { get; }
        MaindbContext db = new MaindbContext();
        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            db.Dests.Load();
            db.Visitors.Load();
            destsx = db.Dests.Local.ToObservableCollection();
            CollectionViewSourceVisGrid = new CollectionViewSource() { Source = db.Visitors.Local.ToObservableCollection() };
            CollectionViewSourceVisGrid.Filter += new FilterEventHandler(CollectionViewSource_Filter);
            ItemList = CollectionViewSourceVisGrid.View;
            VisGrid.ItemsSource = ItemList;
            DestGrid.ItemsSource = destsx;
            ComboBoxStatus.ItemsSource = statuster;
        }
        CollectionViewSource CollectionViewSourceVisGrid;
        ICollectionView ItemList;
        private void CollectionViewSource_Filter(object sender, FilterEventArgs e)
        {
            Visitor? t = e.Item as Visitor;
            if (t != null)
            {
                if (SearchBoxValue == "")
                {
                    e.Accepted = true;
                    return;
                }
                if (t.ДанныеПаспорта == SearchBoxValue | t.Фио == SearchBoxValue) 
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
        private void VisTableBtn(object sender, RoutedEventArgs e)
        {
            this.VisGrid.Visibility = Visibility.Visible;
            this.DestGrid.Visibility = Visibility.Collapsed;
            this.EditPanel.Visibility = Visibility.Collapsed;
        }
        private void DestTableBtn(object sender, RoutedEventArgs e)
        {
            this.VisGrid.Visibility = Visibility.Collapsed;
            this.DestGrid.Visibility = Visibility.Visible;
            this.EditPanel.Visibility = Visibility.Visible;
        }
    }
}
