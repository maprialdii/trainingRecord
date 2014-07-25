<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageEvaluasiReaksiPeserta.aspx.cs" Inherits="BioPM.PageEvaluasiReaksiPeserta" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        if (!IsPostBack)
            SetDataToPage();
    }

    protected void InsertReasonIntoDatabase()
    {
        BioPM.ClassObjects.Reason.InsertReason(txtReason.Text, "Submit Evaluasi 1", Session["username"].ToString());
    }

    protected void SetDataToPage()
    {
        string excid = Request.QueryString["key"].ToString();
        object[] data = null;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "32");

        string keterangan11 = null;
        if (data[1].ToString() == "4")
            keterangan11 = "Tercapai";
        else if (data[1].ToString() == "3")
            keterangan11 = "Cukup Tercapai";
        else if (data[1].ToString() == "2")
            keterangan11 = "Kurang Tercapai";
        else if (data[1].ToString() == "1")
            keterangan11 = "Tidak Tercapai";
        txt11.Text = keterangan11;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "33");

        string keterangan12 = null;
        if (data[1].ToString() == "4")
            keterangan12 = "Tercapai";
        else if (data[1].ToString() == "3")
            keterangan12 = "Cukup Tercapai";
        else if (data[1].ToString() == "2")
            keterangan12 = "Kurang Tercapai";
        else if (data[1].ToString() == "1")
            keterangan12 = "Tidak Tercapai";
        txt12.Text = keterangan12;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "34");

        string keterangan21 = null;
        if (data[1].ToString() == "4")
            keterangan21 = "Sangat lengkap";
        else if (data[1].ToString() == "3")
            keterangan21 = "Lengkap";
        else if (data[1].ToString() == "2")
            keterangan21 = "Kurang lengkap";
        else if (data[1].ToString() == "1")
            keterangan21 = "Tidak lengkap";
        txt21.Text = keterangan21;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "35");

        string keterangan22 = null;
        if (data[1].ToString() == "4")
            keterangan22 = "Sangat dalam";
        else if (data[1].ToString() == "3")
            keterangan22 = "Cukup dalam";
        else if (data[1].ToString() == "2")
            keterangan22 = "Dangkal";
        else if (data[1].ToString() == "1")
            keterangan22 = "Sangat dangkal";
        txt22.Text = keterangan22;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "36");

        string keterangan23 = null;
        if (data[1].ToString() == "4")
            keterangan23 = "Sangat menarik";
        else if (data[1].ToString() == "3")
            keterangan23 = "Cukup menarik";
        else if (data[1].ToString() == "2")
            keterangan23 = "Kurang menarik";
        else if (data[1].ToString() == "1")
            keterangan23 = "Sangat tidak menarik";
        txt23.Text = keterangan23;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "37");

        string keterangan31 = null;
        if (data[1].ToString() == "4")
            keterangan31 = "Panjang";
        else if (data[1].ToString() == "3")
            keterangan31 = "Cukup panjang";
        else if (data[1].ToString() == "2")
            keterangan31 = "Pendek";
        else if (data[1].ToString() == "1")
            keterangan31 = "Sangat pendek";
        txt31.Text = keterangan31;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "38");

        string keterangan32 = null;
        if (data[1].ToString() == "4")
            keterangan32 = "Banyak";
        else if (data[1].ToString() == "3")
            keterangan32 = "Cukup banyak";
        else if (data[1].ToString() == "2")
            keterangan32 = "Sedikit";
        else if (data[1].ToString() == "1")
            keterangan32 = "Sangat sedikit";
        txt32.Text = data[1].ToString();
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "39");

        string keterangan41 = null;
        if (data[1].ToString() == "4")
            keterangan41 = "Sangat menarik";
        else if (data[1].ToString() == "3")
            keterangan41 = "Cukup menarik";
        else if (data[1].ToString() == "2")
            keterangan41 = "Kurang menarik";
        else if (data[1].ToString() == "1")
            keterangan41 = "Sangat tidak menarik";
        txt41.Text = keterangan41;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "40");

        string keterangan42 = null;
        if (data[1].ToString() == "4")
            keterangan42 = "Sangat baik";
        else if (data[1].ToString() == "3")
            keterangan42 = "Baik";
        else if (data[1].ToString() == "2")
            keterangan42 = "Buruk";
        else if (data[1].ToString() == "1")
            keterangan42 = "Sangat buruk";
        txt42.Text = keterangan42;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "41");

        string keterangan43 = null;
        if (data[1].ToString() == "4")
            keterangan43 = "Sistematik";
        else if (data[1].ToString() == "3")
            keterangan43 = "Cukup sistemasik";
        else if (data[1].ToString() == "2")
            keterangan43 = "Kurang sistematik";
        else if (data[1].ToString() == "1")
            keterangan43 = "Tidak sistematik";
        txt43.Text = keterangan43;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "42");

        string keterangan44 = null;
        if (data[1].ToString() == "4")
            keterangan44 = "Sangat baik";
        else if (data[1].ToString() == "3")
            keterangan44 = "Baik";
        else if (data[1].ToString() == "2")
            keterangan44 = "Buruk";
        else if (data[1].ToString() == "1")
            keterangan44 = "Sangat buruk";
        txt44.Text = keterangan44;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "43");

        string keterangan51 = null;
        if (data[1].ToString() == "4")
            keterangan51 = "Sangat baik";
        else if (data[1].ToString() == "3")
            keterangan51 = "Baik";
        else if (data[1].ToString() == "2")
            keterangan51 = "Buruk";
        else if (data[1].ToString() == "1")
            keterangan51 = "Sangat buruk";
        txt51.Text = keterangan51;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "44");

        string keterangan52 = null;
        if (data[1].ToString() == "4")
            keterangan52 = "Sangat baik";
        else if (data[1].ToString() == "3")
            keterangan52 = "Baik";
        else if (data[1].ToString() == "2")
            keterangan52 = "Buruk";
        else if (data[1].ToString() == "1")
            keterangan52 = "Sangat buruk";
        txt52.Text = keterangan52;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "45");

        string keterangan61 = null;
        if (data[1].ToString() == "4")
            keterangan61 = "Sangat bermanfaat";
        else if (data[1].ToString() == "3")
            keterangan61 = "Cukup bermanfaat";
        else if (data[1].ToString() == "2")
            keterangan61 = "Kurang bermanfaat";
        else if (data[1].ToString() == "1")
            keterangan61 = "Tidak bermanfaat";
        txt61.Text = keterangan61;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "46");

        string keterangan62 = null;
        if (data[1].ToString() == "4")
            keterangan62 = "Aplikatif";
        else if (data[1].ToString() == "3")
            keterangan62 = "Cukup aplikatif";
        else if (data[1].ToString() == "2")
            keterangan62 = "Kurang aplikatif";
        else if (data[1].ToString() == "1")
            keterangan62 = "Tidak aplikatif";
        txt62.Text = keterangan62;
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "47");
        
        TextBox2.Text = data[1].ToString();
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "48");
        
        txt7.Text = data[1].ToString();
        data = BioPM.ClassObjects.Survey.GetAnswerById(excid, "49");
        
        TextBox1.Text = data[1].ToString();
    }


    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["password"].ToString() == BioPM.ClassEngines.CryptographFactory.Encrypt(txtConfirmation.Text, true))
        {
            InsertReasonIntoDatabase();
            Response.Redirect("PageCompetencyParameter.aspx");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "YOUR PASSWORD IS INCORRECT" + "');", true);
        }
    }
</script>


<html xmlns="http://www.w3.org/1999/xhtml">
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
                                <asp:TextBox id="txt11" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt12" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt21" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt22" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt23" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt31" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt32" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt41" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt42" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt43" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt44" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt51" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt52" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt61" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt62" runat="server" ReadOnly="true" />
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
                                <asp:TextBox id="txt7" runat="server" ReadOnly="true" />
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
