using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Adam_Asmaca
{
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public Form1()
        {
            InitializeComponent();
        }
      
      
        private void Form1_Load(object sender, EventArgs e)
        {
            //BD9466  kodlu renk  ayarı yapma
               this.BackColor = System.Drawing.ColorTranslator.FromHtml("#BD9466");
               


        }
        private void btn_basla_Click(object sender, EventArgs e)
        {
            //Arka plana atılır
            this.Hide();
            //Form2 açılır 
            
            form2.ShowDialog();
        }

       
    }
}
