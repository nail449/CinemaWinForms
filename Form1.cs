using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace Kino
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        Ticketsl1Dal _ticketsl1Dal = new Ticketsl1Dal();

        public void DataLoad()
        {
            dgw.DataSource = _ticketsl1Dal.GetAll();


        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            DataLoad();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            _ticketsl1Dal.Add(new Tickets1
            {
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Phone = txtTelefon.Text,
                Movie = comboBox1.Text
  
            });
            DataLoad();
        }

        private void dgw_CellEnter(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dgw.CurrentRow.Cells[0].Value.ToString();
            txtAd.Text = dgw.CurrentRow.Cells[1].Value.ToString();
            txtSoyad.Text=dgw.CurrentRow.Cells[2].Value.ToString();
            txtTelefon.Text = dgw.CurrentRow.Cells[3].Value.ToString();
            comboBox1.Text = dgw.CurrentRow.Cells[4].Value.ToString();

        }
        private void btnDelete_Click(object sender, EventArgs e)
        {
            _ticketsl1Dal.Delete(new Tickets1
            {
                ID = Convert.ToInt32(txtID.Text)
            });
            DataLoad();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            _ticketsl1Dal.Update(new Tickets1
            {
                ID = Convert.ToInt32(txtID.Text),
                Name = txtAd.Text,
                Surname = txtSoyad.Text,
                Phone = txtTelefon.Text,
                Movie = comboBox1.Text
            }) ;
            DataLoad();
        }

        public void SearchName(string key)
        {
            //dgw.DataSource = _ticketsl1Dal.GetAll().Where(a => a.Name.ToLower().Contains(key.ToLower())).ToList();
            dgw.DataSource = _ticketsl1Dal.GetByName(key);
        }
        private void txtSerach_TextChanged(object sender, EventArgs e)
        {
            SearchName(txtSerach.Text);
        }
    }
}
