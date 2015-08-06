<%--<project>Latent Dirichlet Allocation(LDA) Project</project>
<author>George K Yu</author>
<date>08/04/2015</date>--%>

<%@ Page Title="Home Page" Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="DLAProj._Default" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
 <script language="javascript" type="text/javascript">
     $(document).ready(function () {
         var window_width = $(window).width() - 280;
         $("#chartdiv").css("width", window_width + "px");
     });

     $(window).resize(function () {
         var window_width = $(window).width() - 280;
         $("#chartdiv").css("width", window_width + "px");
     });
</script>
</head>
<body>
    <form id="form1" runat="server">
    <h2>Tesla Motors' Latent Dirichlet Allocation (LDA) </h2>
    <p>Last updated 08/04/2015</p>
    <div>
        <asp:CheckBoxList ID="CheckBoxList1" runat="server" RepeatDirection="Vertical" 
            onselectedindexchanged="CheckBoxList1_SelectedIndexChanged" TextAlign="Right" Font-Size="Small" >

        </asp:CheckBoxList>
        <p style="font-style:italic; margin-left:20px">Note: If no topic is selected, then all topics (40) will be plotted by default.</p>
     
    </div>

    <div id="chartdiv" style="overflow:scroll">
        <asp:Chart ID="Chart1" runat="server" BorderlineColor="Black"
  BorderlineDashStyle="Solid" BackColor="#B6D6EC" BackGradientStyle="TopBottom"
  BackSecondaryColor="White" Height="700px" Width="1800px" 
                    style="margin-top: 0px; margin-left: 10px; OVERFLOW:scroll;"
         EnableViewState="true" onunload="Chart1_Unload" >        
           
            <Series>
                <asp:Series Name="Series1">
                </asp:Series>
            </Series>
            <ChartAreas>
                <asp:ChartArea Name="ChartArea1">
                </asp:ChartArea>
            </ChartAreas>
        </asp:Chart>
    
    </div>
    <br /><br /><br /><br />
    <p>Developed by George Yu</p>
    
    </form>
</body>
</html>

