using App3.DTO;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Essentials;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace App3
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class OrderPage : ContentPage
	{
		public OrderPage ()
		{
			InitializeComponent();
            orderList.ItemsSource = GetDest();
        }
        private async void QR_Clicked(object sender, EventArgs e)
        {
            //Navigation.PushAsync(new Qr());
            await MediaPicker.CapturePhotoAsync();
        }
        private async void Filter_Click(object sender, EventArgs e)
        {
            
        }
        private async void Edit_Clicked(object sender, EventArgs e)
        {
            if (orderList.SelectedItem == null)
            {
                return;
            }
            // Получаем выбранную позицию в списке
            var selectedItem = orderList.SelectedItem as Dest;
            // Переходим на страницу SecondPage, передавая выбранную позицию в качестве параметра
            await Navigation.PushAsync(new Edit(Convert.ToString(selectedItem.Ид), selectedItem.РазрешениеНаТерриторию, selectedItem.ВремяУбытия));
        }
        private List<Dest> GetDest()
        {
            WebRequest request = WebRequest.Create(Config.ServerAddress + "Order");
            request.Method = "GET";
            request.Timeout = 1000;
            request.ContentType = "application/json";
            WebResponse result = request.GetResponse();
            Stream responseStream = result.GetResponseStream();
            List<Dest> data;
            using (StreamReader reader = new StreamReader(responseStream))
            {
                string objectStr = reader.ReadToEnd();
                data = JsonConvert.DeserializeObject<List<Dest>>(objectStr);
            }
            return data;
        }
    }
}
