using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Android.Widget;
using App3.DTO;
using Newtonsoft.Json;
using Xamarin.Forms;
using Xamarin.Forms.PlatformConfiguration.iOSSpecific;
using Xamarin.Forms.Xaml;
using static Android.Resource;

namespace App3
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Edit : ContentPage
    {
        public ObservableCollection<string> statusorder { get; } = new ObservableCollection<string>() { "Есть", "Нету" };
        public Edit(string id, string selectedValuePerm, string selectedValueTime)
        {
            InitializeComponent();
            PickStatus.ItemsSource = statusorder;
            PickStatus.SelectedItem = Convert.ToString(selectedValuePerm);
            TimePickerBye.Time = TimeSpan.Parse(selectedValueTime);
            TimePickerBye.Format = "HH:mm";
            User.Text = id;
        }
        private void Save_Clicked(object sender, EventArgs e)
        {
            var perm = Convert.ToString(PickStatus.SelectedItem);
            var time = Convert.ToString(TimePickerBye.Time);
            var UserId = Convert.ToInt32(User.Text);
            SaveSender(UserId, perm, time);
            Navigation.PopAsync();
        }

        private void SaveSender(int idUser, string perm, string time)
        {
            // Создание веб-запроса с указанием адреса
            WebRequest request = WebRequest.Create(Config.ServerAddress + "Order/edit");
            // Указание метода, время timout и тп контента
            request.Method = "POST";
            request.Timeout = 1000;
            request.ContentType = "application/json";
            Dest dest = new Dest();
            //Получение кода из поля
            try
            {
                dest.Ид = Convert.ToInt32(idUser);
                dest.ВремяУбытия = Convert.ToString(time);
                dest.РазрешениеНаТерриторию = Convert.ToString(perm);
            }
            catch (Exception ex)
            {
                return;
            }
            //Фиксирование данных кода
            var json = JsonConvert.SerializeObject(dest);
            byte[] sentData = Encoding.UTF8.GetBytes(json);
            //Длина отправляеммых данных
            request.ContentLength = sentData.Length;
            //Создание переменной для запросов
            Stream sendStream = request.GetRequestStream();
            //Отправка данных
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
        }
    }
}