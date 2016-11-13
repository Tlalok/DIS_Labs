using System.Data.OleDb;

namespace Lab_4_ADO
{


    public partial class seriesDataSet
    {

    }

    
}

namespace Lab_4_ADO.seriesDataSetTableAdapters
{
    partial class episodeTableAdapter
    {
        [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Data.Design.TypedDataSetGenerator", "4.0.0.0")]
        [global::System.ComponentModel.Design.HelpKeywordAttribute("vs.data.TableAdapter")]
        [global::System.ComponentModel.DataObjectMethodAttribute(global::System.ComponentModel.DataObjectMethodType.Fill,
            false)]
        public virtual int FillByJoin(seriesDataSet.episodeDataTable dataTable)
        {
            var command = new OleDbCommand();
            command.Connection = Connection;
            command.CommandText = "SELECT episode.episode_id, episode.series_id, series.series_name, episode.episode_name, episode.duration, episode.release_date FROM series INNER JOIN episode ON series.series_id = episode.series_id;";
            command.CommandType = global::System.Data.CommandType.Text;
            this.Adapter.SelectCommand = command;
            if ((this.ClearBeforeFill == true))
            {
                dataTable.Clear();
            }
            int returnValue = this.Adapter.Fill(dataTable);
            return returnValue;
        }
    }
}