﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormConfirmRequest.aspx.cs" Inherits="BioPM.FormApproveRequest" %>

<!DOCTYPE html>
<script runat="server">
    string RECID = null;
    string EMPID = null;
    string EVTID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        SetDataToForm();
        RECID=Request.QueryString["key"].ToString();
    }

    protected void SetDataToForm()
    {
        object[] values = BioPM.ClassObjects.ComDevPlan.GetComdevPlanById(Request.QueryString["key"].ToString());
        txtRecID.Text = values[0].ToString();
        txtEmpName.Text = values[6].ToString();
        EMPID = values[5].ToString();
        EVTID = values[1].ToString();
    }    
   
    protected void InsertDataIntoDatabase()
    {
        string m = txtMonth.Text.Substring(0, 2);
        string year = txtMonth.Text.Substring(6, 4);
        string month = BioPM.ClassEngines.DateFormatFactory.enumToString(m) + " " + year;
        BioPM.ClassObjects.ComDevPlan.UpdateComDevPlan(RECID, EMPID, EVTID, month, txtCost.Text, txtDuration.Text, Session["username"].ToString());
        BioPM.ClassObjects.ComDevPlan.UpdateComDevPlanStatus(RECID, "Confirmed", Session["username"].ToString(), Session["username"].ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        InsertDataIntoDatabase();
        Response.Redirect("PageRequestTraining.aspx");
    }

    protected void btnAddComp_Click(object sender, EventArgs e)
    {
        InsertDataIntoDatabase();
        Response.Redirect("PageLabel.aspx");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PageUserPanel.aspx");
    }

    protected String GenerateDataKompetensi()
    {
        string htmlelement = " ";
        
        return htmlelement;
    }
</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Confirm Request</title>

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
                        Confirm Request
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    <div class="panel-body">
                        <form id="Form1" class="form-horizontal " runat="server" >

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> REQUEST ID</label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtRecID" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EMPLOYEE NAME </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtEmpName" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT MONTH </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtMonth" value="" size="16" class="form-control form-control-inline input-medium default-date-picker" runat="server"></asp:TextBox>
                                <span class="help-block">Begin Date Format : month-day-year e.g. 01-31-2014</span>
                            <a href="PageJadwal.aspx" target="_blank"> LIHAT JADWAL </a>   
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT COST ESTIMATION </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtCost" runat="server" class="form-control m-bot15">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT DURATION </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtDuration" runat="server" class="form-control m-bot15">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> </label>
                            <div class="col-lg-3 col-md-3">
                                <asp:Button class="btn btn-round btn-primary" ID="btnAdd" runat="server" Text="Approve" OnClick="btnAdd_Click"/>
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
