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
using Lab_4_ADO.Repositories;

namespace Lab_4_ADO
{
    public partial class MainForm : Form
    {
        private readonly string connectionString = System.Configuration
            .ConfigurationManager
            .ConnectionStrings["Lab_4_ADO.Properties.Settings.seriesConnectionString"]
            .ConnectionString;
        private readonly SeriesRepository seriesRepository;
        private readonly EpisodeRepository episodeRepository;

        public MainForm()
        {
            seriesRepository = new SeriesRepository(connectionString);
            episodeRepository = new EpisodeRepository(connectionString);
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'seriesDataSet.episode' table. You can move, or remove it, as needed.
            episodeTableAdapter.FillByJoin(this.seriesDataSet.episode);
        }

        private void addSeriesButton_Click(object sender, EventArgs e)
        {
            var series = new Series();
            var addForm = new AddSeriesForm(series);
            if (addForm.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
            seriesRepository.Add(series);
            RefreshDataGrid();
        }

        private void addEpisodeButton_Click(object sender, EventArgs e)
        {
            var episode = new Episode();
            var series = seriesRepository.GetAll();
            var addForm = new AddUpdateEpisodeForm(series.ToArray(), episode);
            if (addForm.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
            episodeRepository.Add(episode);
            RefreshDataGrid();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            var episodeId = GetCurrentEpisodeId();
            episodeRepository.Delete(episodeId);
            RefreshDataGrid();
        }

        private void editButton_Click(object sender, EventArgs e)
        {
            var episode = episodeRepository.Get(GetCurrentEpisodeId());
            var series = seriesRepository.GetAll();
            var addForm = new AddUpdateEpisodeForm(series.ToArray(), episode);
            if (addForm.ShowDialog(this) == DialogResult.Cancel)
            {
                return;
            }
            episodeRepository.Update(episode);
            RefreshDataGrid();
        }

        private void RefreshDataGrid()
        {
            episodeTableAdapter.FillByJoin(this.seriesDataSet.episode);
        }

        private int GetCurrentEpisodeId()
        {
            var currentRowIndex = dataGridView.CurrentCell.RowIndex;
            var episodeId = (int)dataGridView[episodeidDataGridViewTextBoxColumn.Name, currentRowIndex].Value;
            return episodeId;
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void shortestSeriesButton_Click(object sender, EventArgs e)
        {
            MessageBox.Show(seriesRepository.GetTheShortestSeries().Name);
        }
    }
}
