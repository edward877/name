using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesignLib
{
    public delegate void mapdel(string s);

    public partial class MapF : Form
    {
       
        public MapF()
        {
            InitializeComponent();
        }
        System.Xml.XmlDocument xmldoc;
        public event mapdel closemapev;
        public void addev(mapdel d) {
            closemapev = d;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            //Настройки для компонента GMap.
            gMapControl1.Bearing = 0;
            
            //CanDragMap - Если параметр установлен в True,
            //пользователь может перетаскивать карту 
            ///с помощью правой кнопки мыши. 
            gMapControl1.CanDragMap = true;

            //Указываем, что перетаскивание карты осуществляется 
            //с использованием левой клавишей мыши.
            //По умолчанию - правая.
            gMapControl1.DragButton = MouseButtons.Left;

            gMapControl1.GrayScaleMode = true;

            //MarkersEnabled - Если параметр установлен в True,
            //любые маркеры, заданные вручную будет показаны.
            //Если нет, они не появятся.
            gMapControl1.MarkersEnabled = true;

            //Указываем значение максимального приближения.
            gMapControl1.MaxZoom = 18;

            //Указываем значение минимального приближения.
            gMapControl1.MinZoom = 2;

            //Устанавливаем центр приближения/удаления
            //курсор мыши.
            gMapControl1.MouseWheelZoomType =
                GMap.NET.MouseWheelZoomType.MousePositionAndCenter;

            //Отказываемся от негативного режима.
            gMapControl1.NegativeMode = false;

            //Разрешаем полигоны.
            gMapControl1.PolygonsEnabled = true;

            //Разрешаем маршруты
            gMapControl1.RoutesEnabled = true;

            //Скрываем внешнюю сетку карты
            //с заголовками.
            gMapControl1.ShowTileGridLines = false;

            //Указываем, что при загрузке карты будет использоваться 
            //18ти кратное приближение.
            gMapControl1.Zoom = 5;

            //Указываем что все края элемента управления
            //закрепляются у краев содержащего его элемента
            //управления(главной формы), а их размеры изменяются 
            //соответствующим образом.
            gMapControl1.Dock = DockStyle.Fill;

            //Указываем что будем использовать карты Google.
            gMapControl1.MapProvider =
     GMap.NET.MapProviders.GMapProviders.YandexMap;
            GMap.NET.GMaps.Instance.Mode =
                GMap.NET.AccessMode.ServerOnly;

            //Если вы используете интернет через прокси сервер,
            //указываем свои учетные данные.
            GMap.NET.MapProviders.GMapProvider.WebProxy =
                System.Net.WebRequest.GetSystemWebProxy();
            GMap.NET.MapProviders.GMapProvider.WebProxy.Credentials =
                System.Net.CredentialCache.DefaultCredentials;

            // SetCurrentPositionByKeywords("Россия");
        }
        double lat = 0.0;
        double lng = 0.0;
        GMap.NET.WindowsForms.GMapOverlay markersOverlay;
        Thread mapthr;
        delegate void mapdel1();
        void settip()
        {
            mapdel1 d = printtip;
            Invoke(d);
        }
        GMap.NET.WindowsForms.Markers.GMarkerGoogle markerR;
        void printtip()
        {

            markerR.ToolTip =
                 new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerR);
            markerR.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
            markerR.ToolTipText = dataMarker;
            markersOverlay.Markers.Add(markerR);
            gMapControl1.ReloadMap();

        }
        string dataMarker = "";
        private void gMapControl1_Load(object sender, EventArgs e)
        {
            xmldoc = new System.Xml.XmlDocument();
            markersOverlay =
                 new GMap.NET.WindowsForms.GMapOverlay("marker");
            gMapControl1.Overlays.Add(markersOverlay);
            markerR = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(lat, lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow);    //.red();
            markerR.ToolTip =
             new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerR);
            markerR.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
            markerR.ToolTip.Foreground = Brushes.White;
            markerR.ToolTip.Fill = Brushes.Black;
            markerR.ToolTipText = dataMarker;

            string url = string.Format(
   "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true_or_false&language=ru",
   Uri.EscapeDataString("Россия Москва"));

            //Выполняем запрос к универсальному коду ресурса (URI).
            System.Net.HttpWebRequest request =
                (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

            //Получаем ответ от интернет-ресурса.
            System.Net.WebResponse response =
                request.GetResponse();

            //Экземпляр класса System.IO.Stream 
            //для чтения данных из интернет-ресурса.
            System.IO.Stream dataStream =
                response.GetResponseStream();

            //Инициализируем новый экземпляр класса 
            //System.IO.StreamReader для указанного потока.
            System.IO.StreamReader sreader =
                new System.IO.StreamReader(dataStream);

            //Считывает поток от текущего положения до конца.            
            string responsereader = sreader.ReadToEnd();

            //Закрываем поток ответа.
            response.Close();
            xmldoc.LoadXml(responsereader);

            if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
            {


                System.Xml.XmlNodeList nodes =
                    xmldoc.SelectNodes("//location");

                double latitude = 0.0;
                double longitude = 0.0;


                foreach (System.Xml.XmlNode node in nodes)
                {
                    latitude =
                       System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lat").InnerText.ToString());
                    longitude =
                       System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lng").InnerText.ToString());
                }



                gMapControl1.Position = new GMap.NET.PointLatLng(latitude, longitude);


                gMapControl1.Zoom = 1;
                gMapControl1.Refresh();
            }
            markersOverlay.Markers.Add(markerR);
           
        }

        private void gMapControl1_MouseClick(object sender, MouseEventArgs e)
        {
            lat = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lat;
            lng = gMapControl1.FromLocalToLatLng(e.X, e.Y).Lng;
            mapthr = new Thread(settip) { IsBackground = true };
            if (e.Button == MouseButtons.Right)
            {
                dataMarker = "";
                string url = string.Format(
            "http://maps.google.com/maps/api/geocode/xml?latlng={0},{1}&sensor=true_or_false&language=ru",
            lat.ToString().Replace(",", "."), lng.ToString().Replace(",", "."));

                //Выполняем запрос к универсальному коду ресурса (URI).
                System.Net.HttpWebRequest request =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //Получаем ответ от интернет-ресурса.
                System.Net.WebResponse response =
                    request.GetResponse();

                //Экземпляр класса System.IO.Stream 
                //для чтения данных из интернет-ресурса.
                System.IO.Stream dataStream =
                    response.GetResponseStream();

                //Инициализируем новый экземпляр класса 
                //System.IO.StreamReader для указанного потока.
                System.IO.StreamReader sreader =
                    new System.IO.StreamReader(dataStream);

                //Считывает поток от текущего положения до конца.            
                string responsereader = sreader.ReadToEnd();

                //Закрываем поток ответа.
                response.Close();

                //Инициализируем новый документ Xml.

                xmldoc.LoadXml(responsereader);

                if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                {

                    //Получение информации о найденном объекте.
                    //Берем первый возвращаемый адрес.
                    string formatted_address =
                    xmldoc.SelectNodes("//formatted_address").Item(0).InnerText.ToString();
                    string[] words = formatted_address.Split(',');
                    dataMarker = string.Empty;

                    //Получаем строку с переходами.
                    foreach (string word in words)
                    {
                        dataMarker += word + ";" + " ";
                    }
                    textBox1.Text = dataMarker;
                }
                foreach (var a in markersOverlay.Markers)
                    a.IsVisible = false;

                markerR = new GMap.NET.WindowsForms.Markers.GMarkerGoogle(new GMap.NET.PointLatLng(lat, lng), GMap.NET.WindowsForms.Markers.GMarkerGoogleType.yellow);    //.red();

                mapthr.Start();
                markerR.ToolTip =
                 new GMap.NET.WindowsForms.ToolTips.GMapRoundedToolTip(markerR);
                markerR.ToolTipMode = GMap.NET.WindowsForms.MarkerTooltipMode.Always;
                markerR.ToolTip.Foreground = Brushes.White;
                markerR.ToolTip.Fill = Brushes.Black;
                markerR.ToolTipText = dataMarker;





            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                string url = string.Format(
        "http://maps.googleapis.com/maps/api/geocode/xml?address={0}&sensor=true_or_false&language=ru",
        Uri.EscapeDataString(textBox1.Text));

                //Выполняем запрос к универсальному коду ресурса (URI).
                System.Net.HttpWebRequest request =
                    (System.Net.HttpWebRequest)System.Net.WebRequest.Create(url);

                //Получаем ответ от интернет-ресурса.
                System.Net.WebResponse response =
                    request.GetResponse();

                //Экземпляр класса System.IO.Stream 
                //для чтения данных из интернет-ресурса.
                System.IO.Stream dataStream =
                    response.GetResponseStream();

                //Инициализируем новый экземпляр класса 
                //System.IO.StreamReader для указанного потока.
                System.IO.StreamReader sreader =
                    new System.IO.StreamReader(dataStream);

                //Считывает поток от текущего положения до конца.            
                string responsereader = sreader.ReadToEnd();

                //Закрываем поток ответа.
                response.Close();

                System.Xml.XmlDocument xmldoc =
                    new System.Xml.XmlDocument();

                xmldoc.LoadXml(responsereader);

                if (xmldoc.GetElementsByTagName("status")[0].ChildNodes[0].InnerText == "OK")
                {


                    System.Xml.XmlNodeList nodes =
                        xmldoc.SelectNodes("//location");

                    double latitude = 0.0;
                    double longitude = 0.0;


                    foreach (System.Xml.XmlNode node in nodes)
                    {
                        latitude =
                           System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lat").InnerText.ToString());
                        longitude =
                           System.Xml.XmlConvert.ToDouble(node.SelectSingleNode("lng").InnerText.ToString());
                    }


                    string formatted_address =
                       xmldoc.SelectNodes("//formatted_address").Item(0).InnerText.ToString();


                    string[] words = formatted_address.Split(',');
                    string dataMarker = string.Empty;
                    foreach (string word in words)
                    {
                        dataMarker += word + ";" + Environment.NewLine;
                    }

                    //Вариант 3.
                    //string[] words = formatted_address.Split(',');                
                    ////Дом.
                    //string house = words[1].Trim();
                    ////Улица.
                    //string Street = words[0].Trim();
                    ////Город.
                    //string City = words[2].Trim();
                    ////Область.
                    //string Region = words[3].Trim();                
                    ////Страна.
                    //string Country = words[4].Trim(); 
                    ////Почтовый индекс.
                    //string PostalCode = words[5].Trim();

                    //Вариант 4
                    ////Дом.
                    //string house = xmldoc.SelectNodes("//address_component").Item(0).SelectNodes("short_name").Item(0).InnerText.ToString();
                    ////Улица.
                    //string Street = xmldoc.SelectNodes("//address_component").Item(1).SelectNodes("short_name").Item(0).InnerText.ToString();
                    ////Область.
                    //string Region = xmldoc.SelectNodes("//address_component").Item(2).SelectNodes("short_name").Item(0).InnerText.ToString();
                    ////Город.
                    //string City = xmldoc.SelectNodes("//address_component").Item(3).SelectNodes("short_name").Item(0).InnerText.ToString();
                    ////Страна.
                    //string Country = xmldoc.SelectNodes("//address_component").Item(6).SelectNodes("long_name").Item(0).InnerText.ToString();
                    ////Почтовый индекс.
                    //string PostalCode = xmldoc.SelectNodes("//address_component").Item(7).SelectNodes("short_name").Item(0).InnerText.ToString();

                    //Создаем новый список маркеров, с указанием компонента 
                    //в котором они будут использоваться и названием списка.


                    //Инициализация нового ЗЕЛЕНОГО маркера, с указанием его координат.


                    //Указываем, что подсказку маркера, необходимо отображать всегда.

                    //Текст подсказки маркера.
                    //Для Варианта 1,2.


                    //Для Варианта 3,4.
                    //markerG.ToolTipText =
                    //   "Почтовый ин.: "+PostalCode + Environment.NewLine+
                    //   "Страна: " + Country + Environment.NewLine +
                    //   "Город: " + City + Environment.NewLine +
                    //   "Область: " + Region + Environment.NewLine +
                    //   "Улица: " + Street + Environment.NewLine +
                    //   "Номер дома: " + house + Environment.NewLine;

                    //Добавляем маркеры в список маркеров.


                    //Очищаем список маркеров компонента.


                    //Добавляем в компонент, список маркеров.


                    //Устанавливаем позицию карты.
                    gMapControl1.Position = new GMap.NET.PointLatLng(latitude, longitude);


                    gMapControl1.Zoom = 15;
                    gMapControl1.Refresh();
                }
            }
            catch
            { //MessageBox.Show("Введите адрес!"); 
            }
        }

        private void panel1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Size = new Size(panel1.Size.Width, 70);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            closemapev(markerR.ToolTipText);
            this.Close(); 
        }

        private void gMapControl1_MouseEnter(object sender, EventArgs e)
        {
            panel1.Size = new Size(panel1.Size.Width, 20);
        }
    }
}
