<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormEvaluasiPelaksanaan.aspx.cs" Inherits="BioPM.FormEvaluasiPelaksanaan" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
    }

    protected void InsertAnswersIntoDatabase()
    {
        int ANSID;
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "13", RBL11.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "14", RBL12.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "15", RBL13.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "16", RBL14.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "17", RBL21.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "18", RBL22.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "19", RBL23.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "20", RBL24.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "21", RBL25.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "22", RBL31.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "23", RBL32.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "24", RBL41.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "25", RBL42.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "26", RBL43.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "27", RBL51.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "28", RBL52.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "29", TextArea1.Text, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "30", TextArea2.Text, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "31", TextArea3.Text, Session["username"].ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsPostBack) InsertAnswersIntoDatabase();
        Response.Redirect("PageTrainingSurvey.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PageUserPanel.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (Session["password"].ToString() == BioPM.ClassEngines.CryptographFactory.Encrypt(txtConfirmation.Text, true))
        //{
        //    InsertCompetencyIntoDatabase();
        //    Response.Redirect("PageCompetencyParameter.aspx");
        //}
        //else
        //{
        //    ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "YOUR PASSWORD IS INCORRECT" + "');", true);
        //}
    }
</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Evaluasi Pelaksanaan Pelatihan</title>

    <% Response.Write(BioPM.ClassScripts.StyleScripts.GetCoreStyle()); %>
    <% Response.Write(BioPM.ClassScripts.StyleScripts.GetFormStyle()); %>
    <% Response.Write(BioPM.ClassScripts.StyleScripts.GetCustomStyle()); %>
</head>

<body>

<section id="container" >
 
<!--header start--> 
 <%Response.Write( BioPM.ClassScripts.SideBarMenu.TopMenuElement(Session["name"].ToString()) ); %> 
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
                        Evaluasi Pelaksanaan Pelatihan
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    
                    <div class="panel-body">
                        <form id="Form1" class="form-horizontal " runat="server" >
                        
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Topik Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtTopik" runat="server" class="form-control m-bot15" placeholder="Topik Pelatihan"></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator1" ControlToValidate="txtTopik" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Nama Peserta Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtNama" runat="server" class="form-control m-bot15" placeholder="Nama Peserta Pelatihan" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator2" ControlToValidate="txtNama" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Jabatan Peserta Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtJabatan" runat="server" class="form-control m-bot15" placeholder="Jabatan Peserta Pelatihan" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator3" ControlToValidate="txtJabatan" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Tanggal Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtTanggal" runat="server" class="form-control m-bot15" placeholder="Tanggal Pelatihan" ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator4" ControlToValidate="txtTanggal" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Tempat Pelaksanaan Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtTempat" runat="server" class="form-control m-bot15" placeholder="Tempat Pelaksanaan Pelatihan " ></asp:TextBox>
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator5" ControlToValidate="txtTempat" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Materi Pelatihan </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TextBox1" TextMode="multiline" Columns="60" Rows="5" runat="server" placeholder="Pisahkan dengan tanda koma (,)" />
                            </div>
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator6" ControlToValidate="TextBox1" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                        </div>

                        <hr />

                        <label>SKALA NILAI</label>
                        <table class="table table-striped table-hover table-bordered" id="Table1" >
                            <tr>
                                <th>1</th>
                                <th>2</th>
                                <th>3</th>
                                <th>4</th>
                                <th>5</th>
                            </tr>
                            <tr>
                                <td>Tidak puas</td>
                                <td>Kurang puas</td>
                                <td>Cukup puas</td>
                                <td>Puas</td>
                                <td>Sangat puas</td>
                            </tr>
                        </table>

                        <table class="table table-striped table-hover table-bordered" id="Table2" >
                            <tr>
                                <td>
                                    <h3>I. Tanggapan atas materi pelatihan</h3>

                                    <!-- Nomor 1.1 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (1) <br />
                                        Kejelasan bahasa materi pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator7" ControlToValidate="RBL11" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL11" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 1.2 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (2) <br />
                                        Sistematika penulisan materi</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator8" ControlToValidate="RBL12" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL12" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 1.3 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (3) <br />
                                        Kemudahan dalam memahami materi pelatihan secara keseluruhan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator9" ControlToValidate="RBL13" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL13" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 1.4 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (4) <br />
                                        Kualitas materi pelatihan & kedalaman materi pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator10" ControlToValidate="RBL14" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL14" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                                <td>
                                    <h3>II. Tanggapan atas instruktur</h3>
                                    <!-- Nomor 2.1 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (1) <br />
                                        Pengetahuan teoritis atas materi pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator11" ControlToValidate="RBL21" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL21" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 2.2 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (2) <br />
                                        Pengalaman yang mendukung atas materi pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator12" ControlToValidate="RBL22" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL22" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 2.3 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (3) <br />
                                        Kemampuan menguasai audiens (peserta pelatihan)</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator13" ControlToValidate="RBL23" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL23" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 2.4 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (4) <br />
                                        Kemampuan menjawab pertanyaan dari peserta pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator14" ControlToValidate="RBL24" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL24" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 2.5 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (5) <br />
                                        Cara penyampaian materi pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator15" ControlToValidate="RBL25" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL25" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td>
                                    <h3>III. Tanggapan atas fasilitas pelatihan</h3>

                                    <!-- Nomor 3.1 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (1) <br />
                                        Tempat/lokasi pelatihan/makanan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator16" ControlToValidate="RBL31" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL31" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 3.2 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (2) <br />
                                        Media pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator17" ControlToValidate="RBL32" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL32" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                </td>
                                <td>
                                    <h3>IV. Waktu pelaksanaan pelatihan</h3>
                                    <!-- Nomor 4.1 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (1) <br />
                                        Tanggal/hari pelaksanaan pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator18" ControlToValidate="RBL41" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL41" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 4.2 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (2) <br />
                                        Total waktu pelaksanaan pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator19" ControlToValidate="RBL42" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL42" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 4.3 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (3) <br />
                                        Pengalokasian waktu/susunan acara pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator20" ControlToValidate="RBL43" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL43" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <h3>V. Tanggapan atas program pelatihan</h3>
                                    <!-- Nomor 4.1 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (1) <br />
                                        Kesesuaian isi program terhadap sasaran pelatihan</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator21" ControlToValidate="RBL51" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL51" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>

                                    <!-- Nomor 4.2 -->
                                    <div class="form-group">
                                        <h4><label class="col-sm-3 control-label">
                                        (2) <br />
                                        Apakah program pelatihan ini memenuhi harapan?</label></h4>
                                        <asp:RequiredFieldValidator ID="RequiredFieldValidator22" ControlToValidate="RBL52" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                        <div class="col-lg-3 col-md-4">
                                            <div class="radio disable">
                                                <asp:RadioButtonList ID="RBL52" runat="server" RepeatDirection="Horizontal">
                                                    <asp:ListItem Text="1&nbsp;&nbsp;&nbsp;" Value="1" />
                                                    <asp:ListItem Text="2&nbsp;&nbsp;&nbsp;" Value="2" />
                                                    <asp:ListItem Text="3&nbsp;&nbsp;&nbsp;" Value="3" />
                                                    <asp:ListItem Text="4&nbsp;&nbsp;&nbsp;" Value="4" />
                                                    <asp:ListItem Text="5&nbsp;&nbsp;&nbsp;" Value="5" />
                                                </asp:RadioButtonList>
                                            </div>
                                        </div>
                                    </div>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <h3>VI. Rencana aplikasi hasil pelatihan dalam peningkatan/perbaikan
                                        kualitas pekerjaan saat ini.
                                    </h3>
                                    <div class="col-lg-3 col-md-4">
                                        <asp:TextBox id="TextArea1" TextMode="multiline" Columns="100" Rows="5" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator23" ControlToValidate="TextArea1" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                            <tr>
                                <td colspan="2">
                                    <h3>VII. Syarat-syarat/kondisi-kondisi yang harus dipenuhi agar hasil
                                        pelatihan dapat diaplikasikan
                                    </h3>
                                    <div class="col-lg-3 col-md-4">
                                        <asp:TextBox id="TextArea2" TextMode="multiline" Columns="100" Rows="5" runat="server" />
                                    </div>
                                    <asp:RequiredFieldValidator ID="RequiredFieldValidator24" ControlToValidate="TextArea2" runat="server" ErrorMessage="This field is required." ForeColor="Red"></asp:RequiredFieldValidator>
                                </td>
                            </tr>
                        </table>

                        <hr />

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Saran Anda: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TextArea3" TextMode="multiline" Columns="100" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Modal -->
                        <div aria-hidden="true" aria-labelledby="myModalLabel" role="dialog" tabindex="-1" id="myModal" class="modal fade">
                            <div class="modal-dialog">
                                <div class="modal-content">
                                    <div class="modal-header">
                                        <button type="button" class="close" data-dismiss="modal" aria-hidden="true">&times;</button>
                                        <h4 class="modal-title">Approver Confirmation</h4>
                                    </div>
                                    <div class="modal-body">
                                        <p>You Are Logged In As <% Response.Write(Session["name"].ToString()); %></p><br />
                                        <p>Are you sure to insert into database?</p>
                                        <asp:TextBox ID="txtConfirmation" runat="server" TextMode="Password" placeholder="Confirmation Password" class="form-control placeholder-no-fix"></asp:TextBox>
                                        <asp:TextBox ID="txtReason" TextMode="multiline" Columns="30" Rows="3" runat="server" placeholder="Reason" class="form-control placeholder-no-fix"></asp:TextBox>
                                    </div>
                                    <div class="modal-footer">
                                        <asp:Button ID="btnClose" runat="server" data-dismiss="modal" class="btn btn-default" Text="Cancel"></asp:Button>
                                        <asp:Button ID="btnSubmit" runat="server" class="btn btn-success" Text="Confirm" OnClick="btnSave_Click"></asp:Button>
                                    </div>
                                </div>
                            </div>
                        </div>
                        <!-- modal -->

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> </label>
                            <div class="col-lg-3 col-md-3">
                                <asp:Button class="btn btn-round btn-primary" ID="btnAdd" runat="server" Text="Add" OnClick="btnAdd_Click"/>
                                <asp:Button class="btn btn-round btn-primary" ID="btnCancel" runat="server" Text="Cancel" OnClick="btnCancel_Click"/>
                            </div>
                        </div>
                            
                        </form>
                    </div>
                    
                </section>
            </div>
        </div>
        <!-- page end-->
        </section>
    </section>
    <!--main content end-->
<!--right sidebar start-->
    <%Response.Write(BioPM.ClassScripts.SideBarMenu.RightSidebarMenuElement()); %> 
<!--right sidebar end-->
</section>

<!-- Placed js at the end of the document so the pages load faster -->
   
<% Response.Write(BioPM.ClassScripts.JS.GetCoreScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetCustomFormScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetInitialisationScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetPieChartScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetSparklineChartScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetFlotChartScript()); %>
</body>
</html>
