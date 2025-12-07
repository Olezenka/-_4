using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using РКИСЛР_4.FolderModel;

namespace РКИСЛР_4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        ModelEF model = new ModelEF();
        List<Pavilion> pavilions = new List<Pavilion>();
        List<Pavilion> pavilionChanges = new List<Pavilion>();
        List<string> pavilionProp = new List<string>();

        private void loadStartData()
        {
            pavilionBindingSource.DataSource = pavilionChanges;
        }

        private void LoadDataCombo()
        {
            pavilionProp = typeof(Pavilion).GetProperties().Select(p => p.Name).ToList();
            pavilionProp.RemoveRange(pavilionProp.Count - 2, 2);
            comboBox1.DataSource = pavilionProp;
            comboBox1.SelectedIndex = 0;
        }
        private void LoadOrder()
        {
            pavilionChanges = checkBox1.Checked ?
            pavilionChanges.OrderByDescending(p => p.GetType().GetProperties().First(x => x.Name == comboBox1.SelectedItem.ToString()).GetValue(p)).ToList() : pavilionChanges.OrderBy(p => p.GetType().GetProperties().First(x => x.Name == comboBox1.SelectedItem.ToString()).GetValue(p)).ToList();
            loadStartData();

        }
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            pavilionChanges = pavilions.Where(x => x.Status.Contains(textBox1.Text)).ToList();
            LoadOrder();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            pavilionChanges = pavilions = model.Pavilion.ToList();
            loadStartData();
            LoadDataCombo();
        }

        private void pavilionDataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }
    }
}
