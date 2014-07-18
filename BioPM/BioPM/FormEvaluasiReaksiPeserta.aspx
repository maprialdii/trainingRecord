<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormEvaluasiReaksiPeserta.aspx.cs" Inherits="BioPM.FormEvaluasiReaksiPeserta" %>

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
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "32", RBL11.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "33", RBL12.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "34", RBL21.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "35", RBL22.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "36", RBL23.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "37", RBL31.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "38", RBL32.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "39", RBL41.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "40", RBL42.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "41", RBL43.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "42", RBL44.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "43", RBL51.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "44", RBL52.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "45", RBL61.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "46", RBL62.SelectedValue, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "47", TextBox2.Text, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "48", RBL7.Text, Session["username"].ToString());
        ANSID = BioPM.ClassObjects.Survey.GetAnswersMaxID() + 1;
        BioPM.ClassObjects.Survey.SubmitAnswers(ANSID.ToString(), Request.QueryString["key"].ToString(), "49", TextBox1.Text, Session["username"].ToString());
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
    }</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Evaluasi I - Evaluasi Atas Reaksi Peserta</title>

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
                        Evaluasi III (EVALUASI IMPLEMENTASI PELATIHAN)
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    
                    <div class="panel-body">
                        <form id="Form1" class="form-horizontal " runat="server" >
                        
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Topik </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtTopik" runat="server" class="form-control m-bot15" placeholder="Topik Pelatihan"></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Hari/Tanggal </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtHariTanggal" runat="server" class="form-control m-bot15" placeholder="Hari/Tanggal" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Pembicara </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtPembicara" runat="server" class="form-control m-bot15" placeholder="Pembicara" ></asp:TextBox>
                            </div>
                        </div>

                        <hr />

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Nama </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtNama" runat="server" class="form-control m-bot15" placeholder="Nama" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Bagian </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtBagian" runat="server" class="form-control m-bot15" placeholder="Bagian" ></asp:TextBox>
                            </div>
                        </div>

                        <hr />

                        <label>Pilih yang menurut anda paling sesuai dan berikan alasannya</label>
                        <br />
                        
                        <h3>Tujuan Pelatihan</h3>
                        
                        <!-- Nomor 1.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Tujuan pelaksanaan pelatihan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL11" runat="server">
                                        <asp:ListItem Text="4 (Tercapai)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak tercapai)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB11" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 1.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Tujuan anda mengikuti pelatihan ini</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL12" runat="server">
                                        <asp:ListItem Text="4 (Tercapai)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak tercapai)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB12" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <h3>Materi Pelatihan</h3>

                        <!-- Nomor 2.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Cakupan materi</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL21" runat="server">
                                        <asp:ListItem Text="4 (Sangat lengkap)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak lengkap)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB21" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 2.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Kedalaman materi</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL22" runat="server">
                                        <asp:ListItem Text="4 (Sangat dalam)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat dangkal)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB22" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 2.3 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (3) <br />
                            Daya tarik topik</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL23" runat="server">
                                        <asp:ListItem Text="4 (Sangat menarik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat tidak menarik)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB23" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <h3>Alokasi Waktu</h3>

                        <!-- Nomor 3.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Alokasi waktu pelaksanaan pelatihan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL31" runat="server">
                                        <asp:ListItem Text="4 (Panjang)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat pendek)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB31" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 3.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Alokasi waktu untuk diskusi</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL32" runat="server">
                                        <asp:ListItem Text="4 (Banyak)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat sedikit)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB32" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <h3>Instruktur</h3>

                        <!-- Nomor 4.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Daya tarik penyampaian topik</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL41" runat="server">
                                        <asp:ListItem Text="4 (Sangat menarik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak tidak menarik)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB41" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 4.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Penguasaan atas materi pelatihan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL42" runat="server">
                                        <asp:ListItem Text="4 (Sangat baik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat buruk)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB42" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 4.3 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (3) <br />
                            Penyampaian materi</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL43" runat="server">
                                        <asp:ListItem Text="4 (Sistematik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak sistematik)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB43" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 4.4 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (4) <br />
                            Kemampuan menjawab pertanyaan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL44" runat="server">
                                        <asp:ListItem Text="4 (Sangat baik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat buruk)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB44" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <h3>Fasilitas Pelatihan</h3>

                        <!-- Nomor 5.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Kualitas tempat pelatihan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL51" runat="server">
                                        <asp:ListItem Text="4 (Sangat baik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat buruk)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB51" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 5.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Kualitas modul/handouts</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL52" runat="server">
                                        <asp:ListItem Text="4 (Sangat baik)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Sangat buruk)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB52" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <h3>Hasil Pelatihan</h3>

                        <!-- Nomor 6.1 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (1) <br />
                            Manfaat pelatihan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL61" runat="server">
                                        <asp:ListItem Text="4 (Sangat bermanfaat)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak bermanfaat)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB61" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <!-- Nomor 6.2 -->
                        <div class="form-group">
                            <h4><label class="col-sm-3 control-label">
                            (2) <br />
                            Aplikasi pada pekerjaan</label></h4>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL62" runat="server">
                                        <asp:ListItem Text="4 (Aplikatif)" Value="4" />
                                        <asp:ListItem Text="3" Value="3" />
                                        <asp:ListItem Text="2" Value="2" />
                                        <asp:ListItem Text="1 (Tidak aplikatif)" Value="1" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>
                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Alasan: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TB62" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <hr />

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Syarat/kondisi yang harus dipenuhi agar pelatihan ini
                                dapat diaplikasikan pada pekerjaan anda
                            </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TextBox2" TextMode="multiline" Columns="60" Rows="5" runat="server" />
                                </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Jika pelatihan ini dapat diaplikasikan pada pekerjaan
                                anda, berapa lama kira-kira waktu yang anda butuhkan untuk mengaplikasikannya?
                            </label>
                            <div class="col-lg-3 col-md-4">
                                <div class="radio disable">
                                    <asp:RadioButtonList ID="RBL7" runat="server">
                                        <asp:ListItem Text="1 minggu" Value="1" />
                                        <asp:ListItem Text="2 minggu" Value="2" />
                                        <asp:ListItem Text="3 minggu" Value="3" />
                                        <asp:ListItem Text="4 minggu" Value="4" />
                                    </asp:RadioButtonList>
                                </div>
                            </div>
                        </div>

                        <hr />

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> Saran: </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox id="TextBox1" TextMode="multiline" Columns="60" Rows="5" runat="server" />
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
                                <asp:LinkButton data-toggle="modal" class="btn btn-round btn-primary" ID="btnAction" runat="server" Text="Add" href="#myModal"/>
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
