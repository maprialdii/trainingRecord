﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="FormInputEvent.aspx.cs" Inherits="BioPM.FormInsertEvent" %>

<!DOCTYPE html>
<script runat="server">
    string EVTID = null;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        if (!IsPostBack) SetExistingMethod();
    }

    protected void InsertReasonIntoDatabase()
    {
        BioPM.ClassObjects.Reason.InsertReason(txtReason.Text, "Input Event", Session["username"].ToString());
    }

    protected void SetExistingMethod()
    {
        ddlEventMethod.Items.Clear();
        foreach (object[] data in BioPM.ClassObjects.EventMethod.GetAllEventMethod())
        {
            ddlEventMethod.Items.Add(new ListItem(data[1].ToString(), data[0].ToString()));
        }
    }
    
    protected void InsertEventIntoDatabase()
    {
        EVTID = (BioPM.ClassObjects.ComDevEvent.GetComDevEventMaxID() + 1).ToString();
        BioPM.ClassObjects.ComDevEvent.InsertComDevEvent(EVTID, txtEvtName.Text, ddlEventMethod.SelectedValue, txtEventGroup.Text, Session["username"].ToString());
    }

    protected void btnAdd_Click(object sender, EventArgs e)
    {
        if (IsPostBack) InsertEventIntoDatabase();
        Response.Redirect("FormInputTargetTraining.aspx?key="+EVTID+"");
    }

    protected void btnCancel_Click(object sender, EventArgs e)
    {
        Response.Redirect("PageCompetencyDevelopmentEvent.aspx");
    }

    protected void btnSave_Click(object sender, EventArgs e)
    {
        if (Session["password"].ToString() == BioPM.ClassEngines.CryptographFactory.Encrypt(txtConfirmation.Text, true))
        {
            InsertEventIntoDatabase();
            InsertReasonIntoDatabase();
            Response.Redirect("FormInputTargetTraining.aspx?key=" + EVTID + "");
        }
        else
        {
            ClientScript.RegisterStartupScript(this.GetType(), "myalert", "alert('" + "YOUR PASSWORD IS INCORRECT" + "');", true);
        }
    }
    
</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>COMPETENCY DEVELOPMENT EVENT ENTRY FORM</title>

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
                        Competency Development Event Entry Form
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
                                <asp:TextBox ID="txtEvtName" runat="server" class="form-control m-bot15" placeholder="EVENT NAME" ></asp:TextBox>
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT METHOD </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:DropDownList ID="ddlEventMethod" runat="server" class="form-control m-bot15">   
                                </asp:DropDownList> 
                            </div>
                        </div>

                        <div class="form-group">
                            <label class="col-sm-3 control-label"> EVENT GROUP </label>
                            <div class="col-lg-3 col-md-4">
                                <asp:TextBox ID="txtEventGroup" runat="server" class="form-control m-bot15" placeholder="EVENT NAME" ></asp:TextBox>
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
