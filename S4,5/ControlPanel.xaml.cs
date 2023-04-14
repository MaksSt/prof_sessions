using Guard.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32;
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
using System.IO;

namespace Guard
{
    /// <summary>
    /// Логика взаимодействия для ControlPanel.xaml
    /// </summary>
    public partial class ControlPanel : Window
    {
        public ObservableCollection<string> genders { get; } = new ObservableCollection<string>() { "М", "Ж" };
        //public ControlPanel(string Name)
        public ControlPanel()
        {
            InitializeComponent();
            UserNameDock.Content = Name;
            Gender.ItemsSource = genders;
        }
        private string selectedPhotoPath;
        private void SaveBtn(object sender, RoutedEventArgs e)
        {
            string FIO = FirstName.Text + " " +SecondName.Text + " " + ThreeName.Text;
            // Создание объекта контекста базы данных
            using (var db = new GuarddbContext())
            {
                if (!string.IsNullOrEmpty(selectedPhotoPath))
                {
                    string fileName = Path.GetFileName(selectedPhotoPath);
                    string targetDirectory = @"C:\Photos"; // Замените на свою целевую папку.
                    string targetPath = System.IO.Path.Combine(targetDirectory, fileName);

                    File.Copy(selectedPhotoPath, targetPath, true);



                    var newUser = new User
                    {
                        // Заполнение свойств объекта значениями
                        Фио = FIO,
                        Пол = Gender.Text,
                        Должность = Rank.Text,
                        Фото = targetPath
                    };
                    db.Users.Add(newUser);
                }
                else { 
                // Создание нового объекта класса для добавления в базу данных
                    var newUser = new User
                    {
                    // Заполнение свойств объекта значениями
                        Фио = FIO,
                        Пол = Gender.Text,
                        Должность = Rank.Text,
                    };
                    db.Users.Add(newUser);
                }
                // Добавление объекта в коллекцию DbSet<T> в контексте базы данных


                // Сохранение изменений в базе данных
                db.SaveChanges();
            }
            FirstName.Text = "";
            SecondName.Text = "";
            ThreeName.Text = "";
            Gender.Text = "";
            Rank.Text = "";
            MessageBox.Show("Пользователь сохранён");

        }

        private void CancelBtn(object sender, RoutedEventArgs e)
        {
            FirstName.Text = "";
            SecondName.Text = "";
            ThreeName.Text = "";
            Gender.Text = "";
            Rank.Text = "";
            MessageBox.Show("Поля отчищены");
        }


        private void ButtonSelect_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg|All files (*.*)|*.*";
            if (openFileDialog.ShowDialog() == true)
            {
                BitmapImage bitmap = new BitmapImage(new Uri(openFileDialog.FileName));
                imagePreview.Source = bitmap;
                selectedPhotoPath = openFileDialog.FileName;
            }
        }
    }
}
