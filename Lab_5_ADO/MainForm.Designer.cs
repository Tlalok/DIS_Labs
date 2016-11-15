namespace Lab_4_ADO
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.episodeidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesidDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.seriesnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodenameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.durationDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.releasedateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.episodeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seriesDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.seriesDataSet = new Lab_4_ADO.seriesDataSet();
            this.episodeTableAdapter = new Lab_4_ADO.seriesDataSetTableAdapters.episodeTableAdapter();
            this.addSeriesButton = new System.Windows.Forms.Button();
            this.addEpisodeButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.shortestSeriesButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataSet)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToAddRows = false;
            this.dataGridView.AllowUserToDeleteRows = false;
            this.dataGridView.AutoGenerateColumns = false;
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.episodeidDataGridViewTextBoxColumn,
            this.seriesidDataGridViewTextBoxColumn,
            this.seriesnameDataGridViewTextBoxColumn,
            this.episodenameDataGridViewTextBoxColumn,
            this.durationDataGridViewTextBoxColumn,
            this.releasedateDataGridViewTextBoxColumn});
            this.dataGridView.DataSource = this.episodeBindingSource;
            this.dataGridView.Location = new System.Drawing.Point(12, 50);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.ReadOnly = true;
            this.dataGridView.Size = new System.Drawing.Size(598, 333);
            this.dataGridView.TabIndex = 0;
            // 
            // episodeidDataGridViewTextBoxColumn
            // 
            this.episodeidDataGridViewTextBoxColumn.DataPropertyName = "episode_id";
            this.episodeidDataGridViewTextBoxColumn.HeaderText = "episode_id";
            this.episodeidDataGridViewTextBoxColumn.Name = "episodeidDataGridViewTextBoxColumn";
            this.episodeidDataGridViewTextBoxColumn.ReadOnly = true;
            this.episodeidDataGridViewTextBoxColumn.Width = 75;
            // 
            // seriesidDataGridViewTextBoxColumn
            // 
            this.seriesidDataGridViewTextBoxColumn.DataPropertyName = "series_id";
            this.seriesidDataGridViewTextBoxColumn.HeaderText = "series_id";
            this.seriesidDataGridViewTextBoxColumn.Name = "seriesidDataGridViewTextBoxColumn";
            this.seriesidDataGridViewTextBoxColumn.ReadOnly = true;
            this.seriesidDataGridViewTextBoxColumn.Width = 60;
            // 
            // seriesnameDataGridViewTextBoxColumn
            // 
            this.seriesnameDataGridViewTextBoxColumn.DataPropertyName = "series_name";
            this.seriesnameDataGridViewTextBoxColumn.HeaderText = "series_name";
            this.seriesnameDataGridViewTextBoxColumn.Name = "seriesnameDataGridViewTextBoxColumn";
            this.seriesnameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // episodenameDataGridViewTextBoxColumn
            // 
            this.episodenameDataGridViewTextBoxColumn.DataPropertyName = "episode_name";
            this.episodenameDataGridViewTextBoxColumn.HeaderText = "episode_name";
            this.episodenameDataGridViewTextBoxColumn.Name = "episodenameDataGridViewTextBoxColumn";
            this.episodenameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // durationDataGridViewTextBoxColumn
            // 
            this.durationDataGridViewTextBoxColumn.DataPropertyName = "duration";
            this.durationDataGridViewTextBoxColumn.HeaderText = "duration";
            this.durationDataGridViewTextBoxColumn.Name = "durationDataGridViewTextBoxColumn";
            this.durationDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // releasedateDataGridViewTextBoxColumn
            // 
            this.releasedateDataGridViewTextBoxColumn.DataPropertyName = "release_date";
            this.releasedateDataGridViewTextBoxColumn.HeaderText = "release_date";
            this.releasedateDataGridViewTextBoxColumn.Name = "releasedateDataGridViewTextBoxColumn";
            this.releasedateDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // episodeBindingSource
            // 
            this.episodeBindingSource.DataMember = "episode";
            this.episodeBindingSource.DataSource = this.seriesDataSetBindingSource;
            // 
            // seriesDataSetBindingSource
            // 
            this.seriesDataSetBindingSource.DataSource = this.seriesDataSet;
            this.seriesDataSetBindingSource.Position = 0;
            // 
            // seriesDataSet
            // 
            this.seriesDataSet.DataSetName = "seriesDataSet";
            this.seriesDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // episodeTableAdapter
            // 
            this.episodeTableAdapter.ClearBeforeFill = true;
            // 
            // addSeriesButton
            // 
            this.addSeriesButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addSeriesButton.BackgroundImage")));
            this.addSeriesButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addSeriesButton.Location = new System.Drawing.Point(12, 16);
            this.addSeriesButton.Name = "addSeriesButton";
            this.addSeriesButton.Size = new System.Drawing.Size(30, 30);
            this.addSeriesButton.TabIndex = 1;
            this.addSeriesButton.UseVisualStyleBackColor = true;
            this.addSeriesButton.Click += new System.EventHandler(this.addSeriesButton_Click);
            // 
            // addEpisodeButton
            // 
            this.addEpisodeButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("addEpisodeButton.BackgroundImage")));
            this.addEpisodeButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.addEpisodeButton.Location = new System.Drawing.Point(77, 16);
            this.addEpisodeButton.Name = "addEpisodeButton";
            this.addEpisodeButton.Size = new System.Drawing.Size(30, 30);
            this.addEpisodeButton.TabIndex = 2;
            this.addEpisodeButton.UseVisualStyleBackColor = true;
            this.addEpisodeButton.Click += new System.EventHandler(this.addEpisodeButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("deleteButton.BackgroundImage")));
            this.deleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.deleteButton.Location = new System.Drawing.Point(113, 16);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(30, 30);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // editButton
            // 
            this.editButton.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("editButton.BackgroundImage")));
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.Location = new System.Drawing.Point(149, 16);
            this.editButton.Name = "editButton";
            this.editButton.Size = new System.Drawing.Size(30, 30);
            this.editButton.TabIndex = 4;
            this.editButton.UseVisualStyleBackColor = true;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // shortestSeriesButton
            // 
            this.shortestSeriesButton.Location = new System.Drawing.Point(225, 20);
            this.shortestSeriesButton.Name = "shortestSeriesButton";
            this.shortestSeriesButton.Size = new System.Drawing.Size(158, 23);
            this.shortestSeriesButton.TabIndex = 5;
            this.shortestSeriesButton.Text = "Самый короткий сериал";
            this.shortestSeriesButton.UseVisualStyleBackColor = true;
            this.shortestSeriesButton.Click += new System.EventHandler(this.shortestSeriesButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Location = new System.Drawing.Point(535, 20);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(75, 23);
            this.exitButton.TabIndex = 6;
            this.exitButton.Text = "Выход";
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(621, 395);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.shortestSeriesButton);
            this.Controls.Add(this.editButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.addEpisodeButton);
            this.Controls.Add(this.addSeriesButton);
            this.Controls.Add(this.dataGridView);
            this.Name = "MainForm";
            this.Text = "Лабораторная работа №5 ADO.NET";
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.episodeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.seriesDataSet)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView;
        private System.Windows.Forms.BindingSource seriesDataSetBindingSource;
        private seriesDataSet seriesDataSet;
        private System.Windows.Forms.BindingSource episodeBindingSource;
        private seriesDataSetTableAdapters.episodeTableAdapter episodeTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodeidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn seriesidDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn episodenameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn durationDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn releasedateDataGridViewTextBoxColumn;
        private System.Windows.Forms.Button addSeriesButton;
        private System.Windows.Forms.Button addEpisodeButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.Button shortestSeriesButton;
        private System.Windows.Forms.Button exitButton;
    }
}

