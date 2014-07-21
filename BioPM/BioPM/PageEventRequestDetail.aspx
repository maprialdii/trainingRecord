﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageEventRequestDetail.aspx.cs" Inherits="BioPM.PageEventRequestDetail" %>

<!DOCTYPE html>
<script runat="server">
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        if (!IsPostBack)
        {
            GetDataEvent();
            GetDataEmployee();
        }
    }
    
    protected void GetDataEvent()
    {
        //ddlEventName.Items.Clear();
        //foreach (object[] data in BioPM.ClassObjects.ComDevEvent.GetAllComdevEvent())
        //{
        //    ddlEventName.Items.Add(new ListItem(data[1].ToString(), data[0].ToString()));
        //}
    }

    protected void GetDataEmployee()
    {
        //ddlEmployeeName.Items.Clear();
        //foreach (object[] data in BioPM.ClassObjects.EmployeeCatalog.GetAllEmployee())
        //{
        //    ddlEmployeeName.Items.Add(new ListItem(data[1].ToString(), data[0].ToString()));
        //}
    }
    
    protected void InsertDataIntoDatabase()
    {
        //string RECID = (BioPM.ClassObjects.ComDevPlan.GetComDevPlanMaxID() + 1).ToString();
        //BioPM.ClassObjects.ComDevPlan.InsertComDevPlan(RECID, ddlEmployeeName.SelectedValue, ddlEventName.SelectedValue, txtMonth.Text, txtCost.Text, txtDuration.Text, Session["username"].ToString());
        //BioPM.ClassObjects.ComDevPlan.InsertComDevPlanStatus(RECID, "Diusulkan", " ", Session["username"].ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        InsertDataIntoDatabase();
        Response.Redirect("PageSuggestTraining.aspx");
    }
    
    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PageRequestTraining.aspx");
    }
    
    protected void btnSave_Click(object sender, EventArgs e)
    {
        //if (Session["password"].ToString() == BioPM.ClassEngines.CryptographFactory.Encrypt(txtConfirmation.Text, true))
        //{
        //    InsertDataIntoDatabase();
        //    Response.Redirect("PageSuggestTraining.aspx");
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

    <title>Competency Development Event Request</title>

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
                        Competency Development Event Request
                          <span class="tools pull-right">
                            <a class="fa fa-chevron-down" href="javascript:;"></a>
                            <a class="fa fa-times" href="javascript:;"></a>
                         </span>
                    </header>
                    <div class="panel-body">
                        <form id="Form1" class="form-horizontal " runat="server" >

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT NAME </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtEventName" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT METHOD </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtEventMethod" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT MONTH </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtMonth" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> COST ETIMATION </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtCost" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> DURATION </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtDuration" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> STATUS </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtStatus" runat="server" class="form-control m-bot15" ReadOnly="true">   
                                </asp:TextBox> 
                            </div>
                        </div>

                        <hr />
                            
                        

                        <h3>Status detail</h3>
                        <table class="table table-striped table-hover table-bordered" id="Table1" >
                                <thead>
                                <tr>
                                    <th>Persetujuan atasan</th>
                                    <th>Persetujuan HR</th>
                                </tr>
                                </thead>
                                <tbody>
                                <%--<% Response.Write(GenerateDataRekomendasi()); %>--%>
                                </tbody>
                            </table>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> </label>
                            <div class="col-lg-3 col-md-3">
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
