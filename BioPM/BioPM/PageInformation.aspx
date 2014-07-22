<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PageInformation.aspx.cs" Inherits="BioPM.PageInformation" %>

<!DOCTYPE html>
<script runat="server">
    string message = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["username"] == null && Session["password"] == null) Response.Redirect("PageLogin.aspx");
        if (!IsPostBack)
        {
            string id = Request.QueryString["key"];
            DeleteDataOnDatabase(id, Request.QueryString["type"]);
        }
    }
    
    protected void DeleteDataOnDatabase(string ID, string KEY)
    {
        switch (KEY)
        {
            case "0":
                {
                    //USER
                    break;
                }
                /*
            case "1":
                {
                    BioPM.ClassObjects.ProductCatalog.DeleteProduct(ID);
                    message = "DELETE SUCCESS! PRODUCT ID " + ID + " HAS BEEN DELETED. <a href='PageProduct.aspx'>BACK</a>.";
                    break;
                }
            case "2":
                {
                    BioPM.ClassObjects.ProductCatalog.DeleteProductType(ID);
                    message = "DELETE SUCCESS! PRODUCT TYPE ID " + ID + " HAS BEEN DELETED. <a href='PageProductType.aspx'>BACK</a>.";
                    break;
                }
            case "3":
                {
                    BioPM.ClassObjects.ProductCatalog.DeleteProductGroup(ID);
                    message = "DELETE SUCCESS! PRODUCT GROUP ID " + ID + " HAS BEEN DELETED. <a href='PageProductGroup.aspx'>BACK</a>.";
                    break;
                }
            case "4":
                {
                    BioPM.ClassObjects.BatchCatalog.DeleteBatch(ID);
                    message = "DELETE SUCCESS! VACCINE GROUP ID " + ID + " HAS BEEN DELETED. <a href='PagevaccineGroup.aspx'>BACK</a>.";
                    break;
                }
            case "5":
                {
                    BioPM.ClassObjects.QualityControlCatalog.DeleteQualityControlType(ID);
                    message = "DELETE SUCCESS! QUALITY CONTROL TYPE ID " + ID + " HAS BEEN DELETED. <a href='PageQualityControlType.aspx'>BACK</a>.";
                    break;
                }
            case "6":
                {
                    //QC METHOD
                    break;
                }
            case "7":
                {
                    BioPM.ClassObjects.BatchCatalog.DeleteBatch(ID);
                    message = "DELETE SUCCESS! BATCH ID " + ID + " HAS BEEN DELETED. <a href='PageBatch.aspx'>BACK</a>.";
                    break;
                }
            case "8":
                {
                    BioPM.ClassObjects.ItemCatalog.DeleteItemGroup(ID);
                    message = "DELETE SUCCESS! ITEM GROUP ID " + ID + " HAS BEEN DELETED. <a href='PageItemGroup.aspx'>BACK</a>.";
                    break;
                }
            case "9":
                {
                    BioPM.ClassObjects.ItemCatalog.DeleteItem(ID);
                    message = "DELETE SUCCESS! ITEM ID " + ID + " HAS BEEN DELETED. <a href='PageItem.aspx'>BACK</a>.";
                    break;
                }
            case "10":
                {
                    BioPM.ClassObjects.ItemCatalog.DeleteStyle(ID);
                    message = "DELETE SUCCESS! STYLE/PABRIKAN ID " + ID + " HAS BEEN DELETED. <a href='PageStyle.aspx'>BACK</a>.";
                    break;
                }
            case "11":
                {
                    BioPM.ClassObjects.VendorCatalog.DeleteVendorGroup(ID);
                    message = "DELETE SUCCESS! VENDOR GROUP ID " + ID + " HAS BEEN DELETED. <a href='PageVendorGroup.aspx'>BACK</a>.";
                    break;
                }
            case "12":
                {
                    BioPM.ClassObjects.VendorCatalog.DeleteVendor(ID);
                    message = "DELETE SUCCESS! VENDOR ID " + ID + " HAS BEEN DELETED. <a href='PageVendor.aspx'>BACK</a>.";
                    break;
                }
            case "13":
                {
                    BioPM.ClassObjects.DilutionCatalog.DeleteDilution(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! DILUTION SAMPLE FOR PRODUCT ID " + ID + " HAS BEEN DELETED. <a href='PageDilutionSample.aspx'>BACK</a>.";
                    break;
                }
            case "14":
                {
                    BioPM.ClassObjects.NvtCatalog.DeleteNVTBuilding(ID);
                    message = "DELETE SUCCESS! NVT BUILDING ID " + ID + " HAS BEEN DELETED. <a href='PageNVTBuilding.aspx'>BACK</a>.";
                    break;
                }
            case "15":
                {
                    //PRODUCT FORMULATION
                    break;
                }
            case "16":
                {
                    //QC PRODUCT
                    break;
                }
            case "17":
                {
                    //LABEL
                    break;
                }
            case "18":
                {
                    //LABEL CATEGORY
                    break;
                }
            case "19":
                {
                    //LABEL SUB CATEGORY
                    break;
                }
            case "20":
                {
                    //PRINT LABEL
                    break;
                }
                 * */
            case "21":
                {
                    BioPM.ClassObjects.CompetencyCatalog.DeleteCompetency(ID,Session["username"].ToString());
                    message = "DELETE SUCCESS! COMPETENCY ID " + ID + " HAS BEEN DELETED. <a href='PageCompetencyParameter.aspx'>BACK</a>.";
                    break;
                }
            case "22":
                {
                    BioPM.ClassObjects.CompetencyCatalog.DeleteCompetencyStructure(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! COMPETENCY STRUCTURE ID " + ID + " HAS BEEN DELETED. <a href='PageCompetencyRelation.aspx'>BACK</a>.";
                    break;
                }
            case "23":
                {
                    BioPM.ClassObjects.EventMethod.DeleteEventMethod(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! EVENT METHOD ID " + ID + " HAS BEEN DELETED. <a href='PageEventMethod.aspx'>BACK</a>.";
                    break;
                }
            case "24":
                {
                    BioPM.ClassObjects.ComDevEvent.DeleteComDevEvent(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! EVENT ID " + ID + " HAS BEEN DELETED. <a href='PageCompetencyDevelopmentEvent.aspx'>BACK</a>.";
                    break;
                }
            case "25":
                {
                    BioPM.ClassObjects.ComDevEvent.DeleteComDevEventTarget(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! COMDEV EVENT TARGET ID " + ID + " HAS BEEN DELETED. <a href='PageCompetencyDevelopmentEvent.aspx'>BACK</a>.";
                    break;
                }
            case "26":
                {
                    BioPM.ClassObjects.ComDevExecution.DeleteComDevExecution(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! COMDEV EXECUTION ID " + ID + " HAS BEEN DELETED. <a href='PageTrainingExecution.aspx'>BACK</a>.";
                    break;
                }
            case "27":
                {
                    BioPM.ClassObjects.ComDevPlan.DeleteComDevPlan(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! COMDEV PLAN ID " + ID + " HAS BEEN DELETED. <a href='PageSuggestTraining.aspx'>BACK</a>.";
                    break;
                }
            case "28":
                {
                    BioPM.ClassObjects.QualificationCatalog.DeleteQualification(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! EMPLOYEE QUALIFICATION ID " + ID + " HAS BEEN DELETED. <a href='PageEmployeeQualification.aspx'>BACK</a>.";
                    break;
                }
            case "29":
                {
                    BioPM.ClassObjects.Jabatan.DeleteJabatan(ID, Session["username"].ToString());
                    message = "DELETE SUCCESS! POSITION REQUIREMENT ID " + ID + " HAS BEEN DELETED. <a href='PageJabatan.aspx'>BACK</a>.";
                    break;
                }
            case "30":
                {
                    string RECID = (BioPM.ClassObjects.ComDevPlan.GetComDevPlanMaxID() + 1).ToString();
                    BioPM.ClassObjects.ComDevPlan.InsertComDevPlan(RECID, Session["username"].ToString(), ID, " ", " ", " ", Session["username"].ToString());
                    BioPM.ClassObjects.ComDevPlan.InsertComDevPlanStatus(RECID, "Requested", " ", Session["username"].ToString());
                    message = "REQUEST SUCCESS! REQUEST HAS BEEN ADDED. <a href='PageRequestTraining.aspx'>BACK</a>.";
                    break;
                }
            case "31":
                {
                    BioPM.ClassObjects.ComDevPlan.UpdateComDevPlanStatus(ID, "RequestRejected", Session["username"].ToString(), Session["username"].ToString());
                    message = "UPDATE SUCCESS! REQUEST HAS BEEN REJECTED. <a href='PageRequestFromEmployee.aspx'>BACK</a>.";
                    break;
                }
            case "32":
                {
                    BioPM.ClassObjects.ComDevPlan.UpdateComDevPlanStatus(ID, "Disetujui", Session["username"].ToString(), Session["username"].ToString());
                    message = "UPDATE SUCCESS! REQUEST HAS BEEN APPROVED. <a href='PageComdevPlan.aspx'>BACK</a>.";
                    break;
                }
            case "33":
                {
                    BioPM.ClassObjects.ComDevPlan.UpdateComDevPlanStatus(ID, "ConfirmRejected", Session["username"].ToString(), Session["username"].ToString());
                    message = "UPDATE SUCCESS! REQUEST HAS BEEN REJECTED. <a href='PageAppRequestHR.aspx'>BACK</a>.";
                    break;
                }
                

            
            default :
                {
                    break;
                }
                
        }
    }
</script>

<html lang="en">
<head>
    <% Response.Write(BioPM.ClassScripts.BasicScripts.GetMetaScript()); %>

    <title>Dashboard</title>

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
                        INFORMATION
                        <span class="tools pull-right">
                            <a href="javascript:;" class="fa fa-chevron-down"></a>
                            <a href="javascript:;" class="fa fa-times"></a>
                         </span>
                    </header>
                    <div class="panel-body">
                        <% Response.Write(message); %> 
                    </div>
                </section>
            </div>
        </div>
        <!-- page end-->
        </section>
    </section>
    <!--main content end-->
</section>

<!-- Placed js at the end of the document so the pages load faster -->
<% Response.Write(BioPM.ClassScripts.JS.GetCoreScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetDynamicTableScript()); %>
<% Response.Write(BioPM.ClassScripts.JS.GetInitialisationScript()); %>
</body>
</html>
