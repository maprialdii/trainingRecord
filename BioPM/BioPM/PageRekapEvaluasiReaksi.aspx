<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageRekapEvaluasiReaksi.aspx.cs" Inherits="BioPM.PageRekapEvaluasiReaksi" %>

<%@ Register assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagprefix="asp" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        Page.Header.DataBind();
        Page.DataBind();
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        if (!IsPostBack)
        {
            GetDataEventandBatch();
        }
        if (Page.IsPostBack)
        {
            btnShow_Click();
            BindChart1();
            BindChart2();
            BindChart3();
            BindChart4();
            BindChart5();
            BindChart6();
            BindChart7();
            BindChart8();
            BindChart9();
            BindChart10();
            BindChart11();
            BindChart12();
            BindChart13();
            BindChart14();
            BindChart15();
        }
    }

    protected void GetDataEventandBatch()
    {
        ddlEvent.Items.Clear();
        foreach (object[] data in BioPM.ClassObjects.ComDevEvent.GetAllComdevEvent())
        {
            ddlEvent.Items.Add(new ListItem(data[1].ToString(), data[0].ToString()));
        }
        //ddlEvent.Items.Insert(0, new ListItem("Select Event", "NA"));

        ddlBatch.Items.Clear();
        
        foreach (object[] data in BioPM.ClassObjects.ComDevExecution.GetBatch(ddlEvent.SelectedValue))
        {
            ddlBatch.Items.Add(new ListItem(data[0].ToString() + " - " + data[1].ToString(), data[1].ToString()));
        }
        //ddlBatch.Items.Insert(0, new ListItem("Select Execution", "NA"));
    }

    protected String GenerateDataEvent()
    {
        string htmlelement = "";

        foreach (object[] data in BioPM.ClassObjects.ComDevEvent.GetAllComdevEvent())
        {
            htmlelement += "<tr class=''><td>" + data[1].ToString() + "</td><td>" + data[2].ToString() + "</td><td>" + data[3].ToString() + "</td><td><a class='edit' href='PageTargetTrainingK.aspx?key=" + data[0].ToString() + "'>View</a></td></tr>";
        }

        return htmlelement;
    }

    protected void btnShow_Click()
    {
        object[] data1 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "32");
        lbl14.Text = data1[4].ToString();
        lbl13.Text = data1[5].ToString();
        lbl12.Text = data1[6].ToString();
        lbl11.Text = data1[7].ToString();

        object[] data2 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "33");
        lbl24.Text = data2[4].ToString();
        lbl23.Text = data2[5].ToString();
        lbl22.Text = data2[6].ToString();
        lbl21.Text = data2[7].ToString();

        object[] data3 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "34");
        lbl34.Text = data3[4].ToString();
        lbl33.Text = data3[5].ToString();
        lbl32.Text = data3[6].ToString();
        lbl31.Text = data3[7].ToString();

        object[] data4 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "35");
        lbl44.Text = data4[4].ToString();
        lbl43.Text = data4[5].ToString();
        lbl42.Text = data4[6].ToString();
        lbl41.Text = data4[7].ToString();

        object[] data5 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "36");
        lbl54.Text = data5[4].ToString();
        lbl53.Text = data5[5].ToString();
        lbl52.Text = data5[6].ToString();
        lbl51.Text = data5[7].ToString();

        object[] data6 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "37");
        lbl64.Text = data6[4].ToString();
        lbl63.Text = data6[5].ToString();
        lbl62.Text = data6[6].ToString();
        lbl61.Text = data6[7].ToString();

        object[] data7 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "38");
        lbl74.Text = data7[4].ToString();
        lbl73.Text = data7[5].ToString();
        lbl72.Text = data7[6].ToString();
        lbl71.Text = data7[7].ToString();

        object[] data8 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "39");
        lbl84.Text = data8[4].ToString();
        lbl83.Text = data8[5].ToString();
        lbl82.Text = data8[6].ToString();
        lbl81.Text = data8[7].ToString();

        object[] data9 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "40");
        lbl94.Text = data9[4].ToString();
        lbl93.Text = data9[5].ToString();
        lbl92.Text = data9[6].ToString();
        lbl91.Text = data9[7].ToString();

        object[] data10 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "41");
        lbl104.Text = data10[4].ToString();
        lbl103.Text = data10[5].ToString();
        lbl102.Text = data10[6].ToString();
        lbl101.Text = data10[7].ToString();

        object[] data11 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "42");
        lbl114.Text = data11[4].ToString();
        lbl113.Text = data11[5].ToString();
        lbl112.Text = data11[6].ToString();
        lbl111.Text = data11[7].ToString();

        object[] data12 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "43");
        lbl124.Text = data12[4].ToString();
        lbl123.Text = data12[5].ToString();
        lbl122.Text = data12[6].ToString();
        lbl121.Text = data12[7].ToString();

        object[] data13 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "44");
        lbl134.Text = data13[4].ToString();
        lbl133.Text = data13[5].ToString();
        lbl132.Text = data13[6].ToString();
        lbl131.Text = data13[7].ToString();

        object[] data14 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "45");
        lbl144.Text = data14[4].ToString();
        lbl143.Text = data14[5].ToString();
        lbl142.Text = data14[6].ToString();
        lbl141.Text = data14[7].ToString();

        object[] data15 = BioPM.ClassObjects.Survey.GetRekapSurvey(ddlEvent.SelectedValue, ddlBatch.SelectedValue, "46");
        lbl154.Text = data15[4].ToString();
        lbl153.Text = data15[5].ToString();
        lbl152.Text = data15[6].ToString();
        lbl151.Text = data15[7].ToString();
    }

</script>

<html lang="en">
<head runat="server">
    <%# BioPM.ClassScripts.BasicScripts.GetMetaScript() %>

    <title>Rekap Evaluasi Pelaksanaan</title>

    <%# BioPM.ClassScripts.StyleScripts.GetCoreStyle() %>
    <%# BioPM.ClassScripts.StyleScripts.GetTableStyle() %>
    <%# BioPM.ClassScripts.StyleScripts.GetCustomStyle() %>
</head>

<body>

<section id="container" >
 
<!--header start--> 
 <%Response.Write( BioPM.ClassScripts.SideBarMenu.TopMenuElement(Session["name"].ToString())); %> 
<!--header end-->
   
<!--left side bar start-->
 <%Response.Write(BioPM.ClassScripts.SideBarMenu.LeftSidebarMenuElementAutoGenerated(Session["username"].ToString())); %> 
<!--left side bar end-->

    <!--main content start-->
    <section id="main-content">
        <section class="wrapper">
        <!-- page start-->
        <div class="row">
            <div class="col-sm-12">
                <section class="panel">
                    <header class="panel-heading">
                        Rekap Evaluasi Pelaksanaan
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    <div class="panel-body">

                        <div class="adv-table">
                            <div class="clearfix">
                                <div class="btn-group pull-right">
                                    <button class="btn btn-default dropdown-toggle" data-toggle="dropdown">Tools <i class="fa fa-angle-down"></i>
                                    </button>
                                    <ul class="dropdown-menu pull-right">
                                        <li><a href="#">Print</a></li>
                                        <li><a href="#">Save as PDF</a></li>
                                        <li><a href="#">Export to Excel</a></li>
                                    </ul>
                                </div>
                            </div>
                            <form id="Form2" class="form-horizontal " runat="server" >
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"> EVENT </label>
                                    <div class="col-lg-3 col-md-4">
                                        <asp:DropDownList ID="ddlEvent" runat="server" class="form-control m-bot15">   
                                        </asp:DropDownList> 
                                    </div>
                                </div> 
                                <div class="form-group">
                                    <label class="col-sm-3 control-label"> BATCH </label>
                                    <div class="col-lg-3 col-md-4">
                                        <asp:DropDownList ID="ddlBatch" runat="server" class="form-control m-bot15">   
                                        </asp:DropDownList> 
                                    </div>
                                </div> 
                                <div class="btn-group">
                                  <button id="editable-sample_new" onclick="document.location.href='PageRekapEvaluasiReaksi.aspx';" class="btn btn-primary"> View
                                  </button>
                                </div>
                            </form>
                            <table class="table table-striped table-hover table-bordered" id="dynamic-table">
                                <thead>
                                    <tr>                                
                                        <th>Aspek</th>
                                        <th>4</th>
                                        <th>3</th>
                                        <th>2</th>
                                        <th>1</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td colspan="6">
                                            <h4>I. Tujuan pelatihan</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Tujuan pelaksanaan pelatihan</td>
                                        <td><asp:Label ID="lbl14" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl13" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl12" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl11" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Tujuan anda mengikuti pelatihan ini</td>
                                        <td><asp:Label ID="lbl24" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl23" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl22" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl21" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <h4>II. Materi pelatihan</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Cakupan materi</td>
                                        <td><asp:Label ID="lbl34" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl33" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl32" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl31" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Kedalaman materi</td>
                                        <td><asp:Label ID="lbl44" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl43" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl42" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl41" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Daya tarik topik</td>
                                        <td><asp:Label ID="lbl54" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl53" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl52" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl51" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <h4>III. Alokasi waktu</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Alokasi waktu pelaksanaan pelatihan</td>
                                        <td><asp:Label ID="lbl64" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl63" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl62" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl61" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Alokasi waktu untuk diskusi</td>
                                        <td><asp:Label ID="lbl74" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl73" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl72" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl71" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <h4>IV. Instruktur</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Daya tarik penyampaian topik</td>
                                        <td><asp:Label ID="lbl84" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl83" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl82" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl81" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Penguasaan atas materi pelatihan</td>
                                        <td><asp:Label ID="lbl94" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl93" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl92" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl91" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Penyampaian materi</td>
                                        <td><asp:Label ID="lbl104" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl103" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl102" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl101" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Kemampuan menjawab pertanyaan</td>
                                        <td><asp:Label ID="lbl114" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl113" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl112" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl111" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <h4>V. Fasilitas pelatihan</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Kualitas tempat pelatihan</td>
                                        <td><asp:Label ID="lbl124" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl123" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl122" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl121" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Kualitas modul/handouts</td>
                                        <td><asp:Label ID="lbl134" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl133" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl132" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl131" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td colspan="6">
                                            <h4>VI. Hasil pelatihan</h4>
                                        </td>
                                    </tr>
                                    <tr>
                                        <td>Manfaat pelatihan</td>
                                        <td><asp:Label ID="lbl144" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl143" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl142" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl141" runat="server"></asp:Label></td>
                                    </tr>
                                    <tr>
                                        <td>Aplikasi pada pekerjaan</td>
                                        <td><asp:Label ID="lbl154" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl153" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl152" runat="server"></asp:Label></td>
                                        <td><asp:Label ID="lbl151" runat="server"></asp:Label></td>
                                    </tr>
                                </tbody>
                            </table>
                        </div>
                        <div class="form-group">
                            <asp:ScriptManager ID="ScriptManager1" runat="server"></asp:ScriptManager>
                            <h4>Chart pertanyaan 1</h4>
                            <asp:BarChart ID="barchart1" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q1)"></asp:BarChart>
                            <h4>Chart pertanyaan 2</h4>
                            <asp:BarChart ID="barchart2" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q2)"></asp:BarChart>
                            <h4>Chart pertanyaan 3</h4>
                            <asp:BarChart ID="barchart3" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q3)"></asp:BarChart>
                            <h4>Chart pertanyaan 4</h4>
                            <asp:BarChart ID="barchart4" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q1)"></asp:BarChart>
                            <h4>Chart pertanyaan 5</h4>
                            <asp:BarChart ID="barchart5" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q2)"></asp:BarChart>
                            <h4>Chart pertanyaan 6</h4>
                            <asp:BarChart ID="barchart6" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q3)"></asp:BarChart>
                            <h4>Chart pertanyaan 7</h4>
                            <asp:BarChart ID="barchart7" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q1)"></asp:BarChart>
                            <h4>Chart pertanyaan 8</h4>
                            <asp:BarChart ID="barchart8" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q2)"></asp:BarChart>
                            <h4>Chart pertanyaan 9</h4>
                            <asp:BarChart ID="barchart9" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q3)"></asp:BarChart>
                            <h4>Chart pertanyaan 10</h4>
                            <asp:BarChart ID="barchart10" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q1)"></asp:BarChart>
                            <h4>Chart pertanyaan 11</h4>
                            <asp:BarChart ID="barchart11" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q2)"></asp:BarChart>
                            <h4>Chart pertanyaan 12</h4>
                            <asp:BarChart ID="barchart12" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q3)"></asp:BarChart>
                            <h4>Chart pertanyaan 13</h4>
                            <asp:BarChart ID="barchart13" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q1)"></asp:BarChart>
                            <h4>Chart pertanyaan 14</h4>
                            <asp:BarChart ID="barchart14" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q2)"></asp:BarChart>
                            <h4>Chart pertanyaan 15</h4>
                            <asp:BarChart ID="barchart15" runat="server" ChartHeight="300" ChartWidth="600" ChartType="Column" ChartTitle="Evaluation Recap (Q3)"></asp:BarChart>
                        </div>
                    </div>
                </section>
            </div>
        </div>
        <!-- page end-->
        </section>
    </section>
    <!--main content end-->
<!--right sidebar start-->
    <%# BioPM.ClassScripts.SideBarMenu.RightSidebarMenuElement() %> 
<!--right sidebar end-->
</section>

<!-- Placed js at the end of the document so the pages load faster -->
    <%# BioPM.ClassScripts.JS.GetCoreScript() %>
    <%# BioPM.ClassScripts.JS.GetDynamicTableScript() %>
    <%# BioPM.ClassScripts.JS.GetInitialisationScript() %>
</body>
</html>
