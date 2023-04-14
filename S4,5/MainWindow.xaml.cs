using System;
using System.Collections;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using Guard.Entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Bcpg.OpenPgp;

namespace Guard
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> combotype { get; } = new ObservableCollection<string>() { "Администратор доступа", "Служба ИБ", "Руководитель ПОП", "Контролёр МО" };
        public MainWindow()
        {
            InitializeComponent();
            TypeUser.ItemsSource = combotype;
        }

        private void LoginFunc(object sender, RoutedEventArgs e)
        {
            using (GuarddbContext db = new GuarddbContext())
            {
                string login = Convert.ToString(Login.Text);
                string password = Convert.ToString(Pass.Text);
                string secretword = Convert.ToString(SecretWord.Text);
                string type = Convert.ToString(TypeUser.Text);
                object? userLogin = db.Users.Where(u => (login == u.Логин) && (password == u.Пароль) && (secretword == u.СекретноеСлово) && (type == u.ТипПользователя)).FirstOrDefault();
                if (userLogin is User)
                {
                    User user = (User)userLogin;
                    string Name = Convert.ToString(user.Фио);
                    if (type == "Администратор доступа") 
                    { 
                        //ControlPanel objPanel1 = new ControlPanel(Name);
                        //objPanel1.Show();
                        //this.Close();
                    }
                    if (type == "Служба ИБ")
                    {
                        SecurityPanel objPanel2 = new SecurityPanel(Name);
                        objPanel2.Show();
                        this.Close();
                    }
                }
   
                else
                {
                    MessageBox.Show("Bad Login");
                }
            }
        }
    }
}
