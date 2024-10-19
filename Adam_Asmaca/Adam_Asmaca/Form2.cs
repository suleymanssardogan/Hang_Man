using Bunifu.Framework.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam_Asmaca
{
    public partial class Form2 : Form
    {
        
        public Form2()
        {
            InitializeComponent();

        }
        char[] gizli_sehir;
        string secilen_sehir;
        string buton_harf=" ";
        int hak = 6;
        int zaman =60;
      

        //Şehirleri rastegele seçme fonksiyonu
        private void Basla()
        {
            string[] sehirler = { "Adana", "Adıyaman", "Afyonkarahisar", "Ağrı", "Amasya", "Ankara", "Antalya", "Artvin", "Aydın", "Balıkesir",
                            "Bilecik", "Bingöl", "Bitlis", "Bolu", "Burdur", "Bursa", "Çanakkale", "Çankırı", "Çorum", "Denizli",
                            "Diyarbakır", "Edirne", "Elazığ", "Erzincan", "Erzurum", "Eskişehir", "Gaziantep", "Giresun", "Gümüşhane",
                            "Hakkari", "Hatay", "Iğdır", "Isparta", "İstanbul", "İzmir", "Kahramanmaraş", "Karabük", "Karaman", "Kars",
                            "Kastamonu", "Kayseri", "Kırıkkale", "Kırklareli", "Kırşehir", "Kilis", "Kocaeli", "Konya", "Kütahya",
                            "Malatya", "Manisa", "Mardin", "Mersin", "Muğla", "Muş", "Nevşehir", "Niğde", "Ordu", "Osmaniye",
                            "Rize", "Sakarya", "Samsun", "Siirt", "Sinop", "Sivas", "Tekirdağ", "Tokat", "Trabzon", "Tunceli",
                            "Şanlıurfa", "Uşak", "Van", "Yalova", "Yozgat", "Zonguldak"};
            Random sehir = new Random();
            secilen_sehir = sehirler[sehir.Next(sehirler.Length)].ToUpper();
            int uzunluk = secilen_sehir.Length;

            //boyut belirleme
            gizli_sehir = new char[uzunluk];

            //char değiskeni olan gizli sehrin her elamanına boşluk karakteri atanıyor
            for (int i = 0; i < uzunluk; i++)
            {
                gizli_sehir[i] = '-';
            }
            //'-' yazdırılması
            label3.Text=new string(gizli_sehir);
        }


        
        

        //zamanlayıcı fonksiyonu
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Ayarlanan her ınterval için zaman o milisaniye kadar geri geri sayacak
            zaman--;
            label5.Text = zaman.ToString();
            if (zaman <= 0)
            {
                timer1.Stop();
                MessageBox.Show("Süreniz Bitti");
                //form kapanır
                this.Close();
            }

        }


        private void Form2_Load(object sender, EventArgs e)
        {

            Basla();
            label4.Text = Convert.ToString(hak + " hak kaldı");
            timer1.Start();
            //Form açıldığında fotoğrafı getir
            pictureBox2.Image = Properties.Resources.bir;
            //1000ms => 1sn
            timer1.Interval = 1000;
        }


        //Kelime kontrolu için foknsiyon
        private void KelimeKontrol()
        {
            //Buton basılınca alınan harf
            string harf = buton_harf.ToUpper();

                bool dogru_tahmin = false;

                if (secilen_sehir.Contains(harf))
                {

                    //harfi olduğu yerine basma
                    for (int i = 0; i < secilen_sehir.Length; i++)
                    {

                        if (secilen_sehir[i] == harf[0])
                        {
                            //basılan  harf kaçıncı indiste ise harfi o indise basma
                            gizli_sehir[i] = harf[0];
                            dogru_tahmin = true;
                        }
                    }


                    if (dogru_tahmin)
                    {
                        // Güncellenmiş gizli şehri göster
                        label3.Text = new string(gizli_sehir);
                    }

                    //Rastgele seçilen şehir ve gizli şehirle aynı ise oyun biter
                    if (new string(gizli_sehir) == secilen_sehir)
                    {
                        MessageBox.Show("KELİMEYİ BİLDİNİZ");
                        //oyun kapanır
                        this.Close();
                    }
                }

                else
                {
                    
                    hak--;

                //hak her azaldığında adam fotoğrafı değişeceği için kullanıcı harfin olup olmadığını kontrol edebilir.
                    switch (hak)
                    {
                        case 5:
                            pictureBox2.Image = Properties.Resources.iki;
                            break;
                        case 4:
                            pictureBox2.Image = Properties.Resources.uc;
                            break;
                        case 3:
                            pictureBox2.Image = Properties.Resources.dort;
                            break;
                        case 2:
                            pictureBox2.Image = Properties.Resources.bes;
                            break;
                        case 1:
                            pictureBox2.Image = Properties.Resources.alti;
                            break;
                        case 0:
                            pictureBox2.Image = Properties.Resources.yedi;
                            break;
                    }
                    label4.Text = Convert.ToString(hak + "  hak  kaldı");
                    //hak biterse
                    if (hak == 0 || hak < 0)
                    {

                        MessageBox.Show("Şehir " + " " + secilen_sehir);
                        MessageBox.Show("OYUN BİTTİ");
                        // oyun kapanır

                    this.Close();
                    }
                }
        }





        //Bütün butonları olaylarına "tikla" fonksiyonu ekleyerek bütün butonlara aynı  özelliği verme
        private void tikla(object sender, MouseEventArgs e)
        {

            //case lerde belirtilen buton isimlerine ulaşmak için;
            //Consoloe.WriteLine(sender.ToStirng().FullName);

            //bu kod ile butona basıldığında nasıl bir ad ile sisteme geldiğini bularak case alanına koyabiliriz
            Button btn = sender as Button;
            btn.Enabled = false;
            switch (sender.ToString())
            {
                case "System.Windows.Forms.Button, Text: A":
                    buton_harf = "A";
                    break;
                case "System.Windows.Forms.Button, Text: B":
                    buton_harf = "B";
                    break;
                case "System.Windows.Forms.Button, Text: C":
                    buton_harf = "C";
                    break;
                case "System.Windows.Forms.Button, Text: Ç":
                    buton_harf = "Ç";
                    break;
                case "System.Windows.Forms.Button, Text: D":
                    buton_harf = "D";
                    break;
                case "System.Windows.Forms.Button, Text: E":
                    buton_harf = "E";
                    break;
                case "System.Windows.Forms.Button, Text: F":
                    buton_harf = "F";
                    break;
                case "System.Windows.Forms.Button, Text: G":
                    buton_harf = "G";
                    break;
                case "System.Windows.Forms.Button, Text: Ğ":
                    buton_harf = "Ğ";
                    break;
                case "System.Windows.Forms.Button, Text: H":
                    buton_harf = "H";
                    break;
                case "System.Windows.Forms.Button, Text: I":
                    buton_harf = "I";
                    break;
                case "System.Windows.Forms.Button, Text: İ":
                    buton_harf = "İ";
                    break;
                case "System.Windows.Forms.Button, Text: J":
                    buton_harf = "J";
                    break;
                case "System.Windows.Forms.Button, Text: K":
                    buton_harf = "K";
                    break;
                case "System.Windows.Forms.Button, Text: L":
                    buton_harf = "L";
                    break;
                case "System.Windows.Forms.Button, Text: M":
                    buton_harf = "M";
                    break;
                case "System.Windows.Forms.Button, Text: N":
                    buton_harf = "N";
                    break;
                case "System.Windows.Forms.Button, Text: O":
                    buton_harf = "O";
                    break;
                case "System.Windows.Forms.Button, Text: Ö":
                    buton_harf = "Ö";
                    break;
                case "System.Windows.Forms.Button, Text: P":
                    buton_harf = "P";
                    break;
                case "System.Windows.Forms.Button, Text: R":
                    buton_harf = "R";
                    break;
                case "System.Windows.Forms.Button, Text: S":
                    buton_harf = "S";
                    break;
                case "System.Windows.Forms.Button, Text: Ş":
                    buton_harf = "Ş";
                    break;
                case "System.Windows.Forms.Button, Text: T":
                    buton_harf = "T";
                    break;
                case "System.Windows.Forms.Button, Text: U":
                    buton_harf = "U";
                    break;
                case "System.Windows.Forms.Button, Text: Ü":
                    buton_harf = "Ü";
                    break;
                case "System.Windows.Forms.Button, Text: V":
                    buton_harf = "V";
                    break;
                case "System.Windows.Forms.Button, Text: Y":
                    buton_harf = "Y";
                    break;
                case "System.Windows.Forms.Button, Text: Z":
                    buton_harf = "Z";
                    break;
            }
            //Ana algortima fonksiyonunu çağırma
            KelimeKontrol();

        }

        private void button30_Click(object sender, EventArgs e)
        {
           
            if (zaman != 60)
            {
                zaman = 60;
            }
            timer1.Start();

            this.Close();
           
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            
            Form1 form1 = new Form1();
            form1.Show();
           
        }
    }
}
