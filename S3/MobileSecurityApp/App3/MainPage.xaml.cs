using Android.Widget;
using App3.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace App3
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            //if (Auth(CodeStaff.Text))
            await Navigation.PushAsync(new OrderPage());

        }

        private bool Auth(string code)
        {
            // Создание веб-запроса с указанием адреса
            WebRequest request = WebRequest.Create(Config.ServerAddress+"Staff");
            // Указание метода, время timout и тп контента
            request.Method = "POST";
            request.Timeout = 5000;
            request.ContentType = "application/json";
            Staff staff = new Staff();
            //Получение кода из поля
            try
            {
                staff.КодСотрудника = Convert.ToInt32(code);
            }
            catch (Exception ex) {
                return false;
            }
            //Фиксирование данных кода
            byte[] sentData = Encoding.UTF8.GetBytes(JsonConvert.SerializeObject(staff));
            //Длина отправляеммых данных
            request.ContentLength = sentData.Length;
            //Создание переменной для запросов
            Stream sendStream = request.GetRequestStream();
            //Отправка данных
            sendStream.Write(sentData, 0, sentData.Length);
            sendStream.Close();
            // Получение результата и ответа
            WebResponse result = request.GetResponse();
            Stream responseStream = result.GetResponseStream();
            //Создание переменной data 
            Staff data;
            //Обработчик данных
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string objectStr = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<Staff>(objectStr);
            }
            return data != null;
        }  
    }
}
