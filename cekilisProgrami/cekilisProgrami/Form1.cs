using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cekilisProgrami
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }

        private void rtxtAdaylar_TextChanged(object sender, EventArgs e)
        {
            lblCekilisSayi.Text = rtxtAdaylar.Lines.Count().ToString();
            if (rtxtAdaylar.Lines.Count()>0)
            {
                nMiktar.Maximum = rtxtAdaylar.Lines.Count()-1;

            }
            else
            {
                nMiktar.Minimum = 1;
            }


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dtgList.ColumnCount = 2;
            dtgList.Columns[0].Name = "Sıra no";
            dtgList.Columns[1].Name = "Ad Soyad";
           
        }
        int _cekilisSay = 1;

        private void btnCekilis_Click(object sender, EventArgs e)
        {
            
            int cekilisSayisi = Convert.ToInt32(nMiktar.Text);
            List<string> ListAdaylar = new List<string>(rtxtAdaylar.Text.Split('\n'));

            if (rtxtAdaylar.Text=="")
            {
                MessageBox.Show("Adayları girmelisiniz!");
            }
            else
            {
                Random uret = new Random();

                for (int i = 0; i < cekilisSayisi; i++)
                {
                    int kazananAday = uret.Next(0, ListAdaylar.Count);
                    dtgList.Rows.Add(_cekilisSay++,ListAdaylar[kazananAday]);
                    ListAdaylar.Remove(ListAdaylar[kazananAday]);
                }

            }
        }

        private void btnTemizle_Click(object sender, EventArgs e)
        {
            rtxtAdaylar.Clear();
            dtgList.Rows.Clear();
            _cekilisSay = 1;
            nMiktar.Value = 1;

        }

        private void nMiktar_ValueChanged(object sender, EventArgs e)
        {
            nMiktar.Maximum = rtxtAdaylar.Lines.Count();
        }
    }
}
