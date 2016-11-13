using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_4_ADO.Models;

namespace Lab_4_ADO
{
    public partial class AddSeriesForm : Form
    {
        private readonly Series series;

        public AddSeriesForm(Series series)
        {
            InitializeComponent();

            this.series = series;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            if (!DataIsValide())
            {
                return;
            }
            series.Name = seriesNameTextBox.Text;
            DialogResult = DialogResult.OK;
            Close();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private bool DataIsValide()
        {
            if (string.IsNullOrWhiteSpace(seriesNameTextBox.Text))
            {
                MessageBox.Show("Вы не ввели имя сериала!", "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }
    }
}
