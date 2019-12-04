<%@ Control Language="C#" AutoEventWireup="true" CodeFile="CacheViewer.ascx.cs" Inherits="RockWeb.Blocks.Cms.CacheManager" %>

<asp:UpdatePanel ID="upnlContent" runat="server">
    <ContentTemplate>
        <div class="panel panel-block">
            <div class="panel-heading">
                <h1 class="panel-title">
                    <i class="fa fa-tachometer"></i>
                    Cache Viewer
                </h1>
            </div>
            <div class="panel-body">
                <div class="well">
                    <Rock:RockDropDownList ID="ddlCacheTypes" runat="server" DataTextField="Name" DataValueField="Id" Label="Cache Type" />
                    <Rock:RockTextBox ID="rtbEntityId" runat="server" Label="Entity Id" />
                    <asp:LinkButton ID="btnRefresh" runat="server" CssClass="btn btn-xs btn-default" ToolTip="Refresh" OnClick="btnRefresh_Click">
                        <i class="fa fa-refresh"></i>
                        Load
                    </asp:LinkButton>
                </div>

                <Rock:RockLiteral ID="lResponse" runat="server" Label="Result" CssClass="margin-t-lg" />
            </div>
        </div>
    </ContentTemplate>
</asp:UpdatePanel>