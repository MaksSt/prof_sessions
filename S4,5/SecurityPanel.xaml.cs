using Guard.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

namespace Guard
{
    /// <summary>
    /// Логика взаимодействия для SecurityPanel.xaml
    /// </summary>  
    public partial class SecurityPanel : Window
    {
        GuarddbContext db = new GuarddbContext();
        public ObservableCollection<User> usersx { get; }
        public ObservableCollection<string> typeuser { get; } = new ObservableCollection<string>() { "Администратор доступа", "Служба ИБ", "Руководитель ПОП", "Контролёр МО" };
        public ObservableCollection<string> access { get; } = new ObservableCollection<string>() { "Да", "Нет" };
        public ObservableCollection<string> permissions { get; } = new ObservableCollection<string>() { "Есть", "Нету" };
        public SecurityPanel(string Name)
        {
            InitializeComponent();
            UserNameDock.Content = Name;
            db.Users.Load();
            usersx = db.Users.Local.ToObservableCollection();
            UserGrid.ItemsSource = usersx;
            PermGrid.ItemsSource = usersx;
            ComboBoxTypeUser.ItemsSource = typeuser;
            ComboBoxAccess.ItemsSource = access;
            ComboBoxPermUser1.ItemsSource = permissions;
            ComboBoxPermUser2.ItemsSource = permissions;
            ComboBoxPermUser3.ItemsSource = permissions;
        }

        private void SendBtn(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void VerDataBtn(object sender, RoutedEventArgs e)
        {
            this.PermPart.Visibility = Visibility.Collapsed;
            this.UserPart.Visibility = Visibility.Visible;
            this.Send.Content = "Одобрить";
            this.VerData.IsEnabled = false;
            this.PermData.IsEnabled = true;
        }

        private void PermDataBtn(object sender, RoutedEventArgs e)
        {
            this.UserPart.Visibility = Visibility.Collapsed;
            this.PermPart.Visibility = Visibility.Visible;
            this.Send.Content = "Применить";
            this.VerData.IsEnabled = true;
            this.PermData.IsEnabled = false;
        }
    }
}
