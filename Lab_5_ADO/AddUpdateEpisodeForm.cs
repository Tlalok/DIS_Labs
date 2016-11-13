using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Lab_4_ADO.Models;

namespace Lab_4_ADO
{
    public partial class AddUpdateEpisodeForm : Form
    {
        private readonly Episode episode;

        public AddUpdateEpisodeForm(Series[] seriesList, Episode episode)
        {
            InitializeComponent();

            this.episode = episode;
            seriesComboBox.Items.AddRange(seriesList);
            seriesComboBox.SelectedIndex = 0;
            episodeNameTextBox.Text = episode.Name;
            durationTextBox.Text = episode.Duration.ToString(@"hh\:mm\:ss");
            realeseDateTimePicker.Value = episode.ReleaseDate;
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            durationTextBox.Text = durationTextBox.Text.Replace(' ', '0');
            if (durationTextBox.Text.EndsWith(":"))
            {
                durationTextBox.Text += "00";
            }

            if (!DataIsValide())
            {
                return;
            }

            episode.SeriesId = ((Series) seriesComboBox.SelectedItem).Id;
            episode.Duration = TimeSpan.Parse(durationTextBox.Text);
            episode.Name = episodeNameTextBox.Text;
            episode.ReleaseDate = realeseDateTimePicker.Value;
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
            if (string.IsNullOrWhiteSpace(episodeNameTextBox.Text))
            {
                ShowErrorMessage("Вы не ввели имя серии!");
                return false;
            }
            if (TimeSpan.Parse(durationTextBox.Text) == TimeSpan.Zero)
            {
                ShowErrorMessage("Вы не ввели продолжительность серии!");
                return false;
            }
            return true;
        }

        private void ShowErrorMessage(string text)
        {
            MessageBox.Show(text, "Ошибка!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}
