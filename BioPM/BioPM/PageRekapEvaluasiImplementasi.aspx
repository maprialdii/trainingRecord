﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageRekapEvaluasiImplementasi.aspx.cs" Inherits="BioPM.PageRekapEvaluasiImplementasi" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
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

    }

</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Rekap Evaluasi Pelaksanaan</title>

    <% Response.Write(BioPM.ClassScripts.StyleScripts.GetCoreStyle()); %>
<% Response.Write(BioPM.ClassScripts.StyleScripts.GetTableStyle()); %>
<% Response.Write(BioPM.ClassScripts.StyleScripts.GetCustomStyle()); %>
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
                                  <button id="editable-sample_new" onclick="document.location.href='PageRekapEvaluasiImplementasi.aspx';" class="btn btn-primary"> View
                                  </button>
                                </div>
                            </form>
                            <table class="table table-striped table-hover table-bordered" id="dynamic-table">
                                <thead>
                                    <tr>                                
                                        <th>Aspek</th>
                                        <th>5</th>
                                        <th>4</th>
                                        <th>3</th>
                                        <th>2</th>
                                        <th>1</th>
                                    </tr>
                                </thead>
                                <tbody>
                                    <tr>
                                        <td>Dalam melaksanakan tugasnya apakah hasil pelatihan sudah diaplikasikan dalam pekerjaannya?</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Dalam melaksanakan tugasnya apakah sudah ada perbaikan dalam pekerjaannya?</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Dalam melaksanakan tugasnya apakah ada peningkatan kualitas dalam bekerja?</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                    <tr>
                                        <td>Setelah mengikuti pelatihan, apakah ada perubahan sikap dan perilaku kerja dalam menjalankan perannya sebagai karyawan secara keseluruhan?</td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                        <td></td>
                                    </tr>
                                </tbody>
                            </table>
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
    <%Response.Write( BioPM.ClassScripts.SideBarMenu.RightSidebarMenuElement() ); %> 
<!--right sidebar end-->
</section>

<!-- Placed js at the end of the document so the pages load faster -->
    <% Response.Write(BioPM.ClassScripts.JS.GetCoreScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetDynamicTableScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetInitialisationScript()); %>
</body>
</html>