<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPages/BackEnd.Master" AutoEventWireup="true" CodeBehind="Competency.aspx.cs" Inherits="BioRMM.Pages.Competency" %>

<asp:Content ID="Content1" ContentPlaceHolderID="cpHead" runat="server">
    <link rel="stylesheet" type="text/css" href="/CSS/Feature/jquery.nestable.css" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cpMainContent" runat="server">
    <%--<div class="panel-body">
        <div class="dd" id="nestable_list_1">
            <ol class="dd-list">
                <li class="dd-item" data-id="1">
                    <div class="dd-handle">Item 1</div>
                </li>
                <li class="dd-item" data-id="2">
                    <div class="dd-handle">Item 2</div>
                    <ol class="dd-list">
                        <li class="dd-item" data-id="3">
                            <div class="dd-handle">Item 3</div>
                        </li>
                        <li class="dd-item" data-id="4">
                            <div class="dd-handle">Item 4</div>
                        </li>
                        <li class="dd-item" data-id="5">
                            <div class="dd-handle">Item 5</div>
                            <ol class="dd-list">
                                <li class="dd-item" data-id="6">
                                    <div class="dd-handle">Item 6</div>
                                </li>
                                <li class="dd-item" data-id="7">
                                    <div class="dd-handle">Item 7</div>
                                </li>
                                <li class="dd-item" data-id="8">
                                    <div class="dd-handle">Item 8</div>
                                </li>
                            </ol>
                        </li>
                        <li class="dd-item" data-id="9">
                            <div class="dd-handle">Item 9</div>
                        </li>
                        <li class="dd-item" data-id="10">
                            <div class="dd-handle">Item 10</div>
                        </li>
                    </ol>
                </li>
                <li class="dd-item" data-id="11">
                    <div class="dd-handle">Item 11</div>
                </li>
                <li class="dd-item" data-id="12">
                    <div class="dd-handle">Item 12</div>
                </li>
            </ol>
        </div>
    </div>--%>
    <div class="row">
        <div class="col-lg-12">
            <section class="panel">
                <header class="panel-heading">
                    Competency Relation
		    <span class="tools pull-right">
			<a href="javascript:;" class="icon-chevron-down"></a>
			<a href="javascript:;" class="icon-remove"></a>
		    </span>
                </header>
                <div class="panel-body">
                    <div class="dd" id="nestable_list_1">
			<ol class="dd-list" id="List" runat="server">
			    
			</ol>
                    </div>
                </div>
            </section>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="cpScriptLibContent" runat="server">
    <script src="/JS/Feature/jquery.nestable.js" type="text/javascript"></script>
</asp:Content>
<asp:Content ID="Content4" ContentPlaceHolderID="cpScriptContent" runat="server">
    <script src="/JS/nestable.js"></script>
</asp:Content>
