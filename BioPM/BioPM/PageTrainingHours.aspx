﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageTrainingHours.aspx.cs" Inherits="BioPM.PageTrainingHours" %>

<!DOCTYPE html>
<script runat="server">
    string total=null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
    }

    protected String GenerateDataPositionReq()
    {
        string htmlelement = "";

        foreach (object[] data in BioPM.ClassObjects.ComDevExecution.GetComdevExecutionByUserId(Session["username"].ToString()))
        {
            //htmlelement += "<tr class=''><td>" + data[1].ToString() + "</td><td>" + data[2].ToString() + "</td><td>" + data[3].ToString() + "</td><td><a class='edit' href='FormUpdate.aspx?key=" + data[0].ToString() + "'>Edit</a></td><td><a class='delete' href='#.aspx?key=" + data[0].ToString() + "&type=000'>Delete</a></td></tr>";
            htmlelement += "<tr class=''><td>" + data[1].ToString() + "</td><td>" + data[6].ToString() + "</td><td>" + data[5].ToString() + "</td><td>" + data[9].ToString() + "</td><td>" + data[8].ToString() + "</td></tr>";
        }

        object[] values = BioPM.ClassObjects.ComDevExecution.GetTotalHoursExecution(Session["username"].ToString());
        total = values[0].ToString();              
        return htmlelement;
    }

   
</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Position Requirements</title>

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
                        Position Requirements
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    <div class="panel-body">
                        <div class="adv-table">
                            <div class="clearfix">
                                <div class="btn-group">
                                    <button id="editable-sample_new" onclick="document.location.href='FormInputPositionRequirements.aspx';" class="btn btn-primary"> Add New <i class="fa fa-plus"></i>
                                    </button>
                                </div>
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
                            <table class="table table-striped table-hover table-bordered" id="dynamic-table" >
                                <thead>
                                <tr>
                                    <th>Event Name</th>
                                    <th>Tanggal Pelaksanaan</th> 
                                    <th>Institution</th>
                                    <th>Score</th>   
                                    <th>Status</th>                                   
                                </tr>
                                </thead>
                                <tbody>
                                <% Response.Write(GenerateDataPositionReq()); %>
                                    <tr><td colspan="5">Total Training Hours: <%Response.Write(total); %></td></tr>
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
