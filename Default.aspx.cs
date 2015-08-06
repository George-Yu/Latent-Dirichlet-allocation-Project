// <project>Latent Dirichlet Allocation(LDA) Project</project>
// <author>George K Yu</author>
// <date>08/04/2015</date>

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.DataVisualization.Charting;
using System.Data;
using Oracle.DataAccess.Client;
using System.Drawing;

namespace DLAProj
{
    public partial class _Default : System.Web.UI.Page
    {
        Plotcom plotcom1 = new Plotcom();

        protected void Page_Load(object sender, EventArgs e)
        {
            Page.MaintainScrollPositionOnPostBack = true;
            if (!IsPostBack)
            {

                DataSet myds = plotcom1.getAllTopicsDS(plotcom1.getAllTopics());

                CheckBoxList1.AutoPostBack = true;
                CheckBoxList1.DataValueField = "TOPIC";
                CheckBoxList1.DataTextField = "WORDS";
                CheckBoxList1.DataSource = myds;
                CheckBoxList1.DataBind();

                Chart1.Series.Clear();
                DataSet ds_topic_dist = new DataSet();

                for (int cnt = 0; cnt < 40; cnt++)
                {
                    Series aSeries = new Series();

                    Chart1.Series.Add(aSeries[cnt]);
                    Chart1.Series[cnt].Name = "T" + cnt;
                    Chart1.Series[cnt].PostBackValue = "#SERIESNAME,#VALX,#VALY";
                    Chart1.Series[cnt].ChartType = SeriesChartType.Line;
                    Chart1.Series[cnt].BorderWidth = 2;
                    Chart1.Series[cnt].MarkerStyle = MarkerStyle.None;
                    Chart1.Series[cnt].XValueMember = "DATECOL";
                    Chart1.Series[cnt].YValueMembers = "T" + cnt;
                    Chart1.Series[cnt].ToolTip = "#SERIESNAME,#VALX,#VALY";
                   
                }//for loop ends
                Chart1.DataSource = plotcom1.getAllDocTopicDist();
                Chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
                Chart1.DataBind();                
            }         


                
        }

        protected void CheckBoxList1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Chart1.Series.Clear();

            ////generate 50 colors automatically
            //Random randomGen = new Random();
            //for (int i = 0; i < 50; i++)
            //{
            //    KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            //    KnownColor randomColorName = names[randomGen.Next(names.Length)];
            //    Color randomColor = Color.FromKnownColor(randomColorName);
                
            //    plotcom1.updateColorByTopicID(i, randomColor.Name);
            //}
            List<string> list_selecteditems = new List<string>();
            int j = 0;
            for (int i = 0; i < CheckBoxList1.Items.Count; i++)
            {
                if (CheckBoxList1.Items[i].Selected)
                {
                    j++;
                    CheckBoxList1.Items[i].Attributes.CssStyle.Add("background-color", plotcom1.getColorByTopicID(int.Parse(CheckBoxList1.Items[i].Value)));                    
                    CheckBoxList1.Items[i].Attributes.CssStyle.Add("font", "10pt");
                    CheckBoxList1.Items[i].Attributes.CssStyle.Add("font-weight", "bold");
                    list_selecteditems.Add(CheckBoxList1.Items[i].Value);                    
                }
            }//end of for loop

            if (j==0) Response.Redirect(Request.RawUrl);

            int cnt = list_selecteditems.Count;
            for (int i = 0; i < cnt; i++)
            {
                Series aSeries = new Series();
          
                Chart1.Series.Add(aSeries[i]);
                Chart1.Series[i].Name = "T" + list_selecteditems[i];
                Chart1.Series[i].PostBackValue = "#SERIESNAME,#VALX,#VALY";
                Chart1.Series[i].ChartType = SeriesChartType.Line;
                Chart1.Series[i].BorderWidth = 2;
                Chart1.Series[i].MarkerStyle = MarkerStyle.None;
                Chart1.Series[i].XValueMember = "DATECOL";
                Chart1.Series[i].YValueMembers = "T" + list_selecteditems[i];
                Chart1.Series[i].ToolTip = "#SERIESNAME,#VALX,#VALY";
                Chart1.Series[i].Color = System.Drawing.ColorTranslator.FromHtml(plotcom1.getColorByTopicID(int.Parse(list_selecteditems[i])));
            }
            Chart1.DataSource = plotcom1.getDocTopicDistByTopicNumberList(list_selecteditems);
            Chart1.ChartAreas[0].AxisX.IntervalType = DateTimeIntervalType.Days;
            Chart1.DataBind(); 

        }

        protected void Chart1_Unload(object sender, EventArgs e)
        {
            Chart1.Dispose();

        }

    }
}
