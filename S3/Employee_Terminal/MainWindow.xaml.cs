using Employee_Terminal.Entities;
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

namespace Employee_Terminal
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MaindbContext db = new MaindbContext();
        public ObservableCollection<Dest> destsx { get; }
        public MainWindow()
        {
            InitializeComponent();
            db.Dests.Load();
            destsx = db.Dests.Local.ToObservableCollection();
            DestGrid.ItemsSource = destsx;
        }

        private void SaveChangesBtn(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void DestGrid_SelectedCellsChanged(object sender, SelectedCellsChangedEventArgs e)
        {
            if (PermInfo.Text == "Нету")
            {
                DateSelect1.IsReadOnly = true;
                DateSelect2.IsReadOnly = true;
            }
            else
            {
                DateSelect1.IsReadOnly = false;
                DateSelect2.IsReadOnly = false;
            }
        }
    }
}
