<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_R.aspx.cs" Inherits="EDA_IBF.Sample_" %>
<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel=stylesheet type="text/css" href="./style/Sample.css">
</head>


<body class= "main_body">

<form id="signup_" runat="server">


<%--匯出資料 ext.net --%>

<br /> 
 <ext:ResourceManager ID="ResourceManager_2" runat="server" />

     <div class="divcss-right">
            <ext:Button ID="Button_r" runat="server" Text="Logout" Icon="UserGo">
                <DirectEvents>
                    <Click OnEvent="Button_Click">
                    </Click>
                </DirectEvents>
             </ext:Button>
     </div>

     <div class="divcss=left" >
         <asp:FileUpload ID="FileUpload_ASP"  runat="server">
        </asp:FileUpload>
        <asp:Button   class="button" ID="Button12" runat="server" Text="CSV 上傳"  OnClick = "Upload_1" />
     </div>

  <%--樣板 --%>
          <ext:TabPanel ID="TabPanel1"  runat="server" Height="630"  Layout="FitLayout"
            DeferredRender="false">
            <Items>

                <ext:Panel ID="Panel2" runat="server" Title="Sign detail">
                    <Loader ID="Loader2"  runat="server" Url="Main_R_child1.aspx" Mode="Frame" >
                        <LoadMask ShowMask="true" />
                    </Loader>
                </ext:Panel>

                <ext:Panel ID="Panel1" runat="server" Title="匯入檔案">
                    <Loader ID="Loader1" runat="server" Url="Main_R_child1_.aspx" Mode="Frame">
                        <LoadMask ShowMask="true" />
                    </Loader>
                </ext:Panel> 
            </Items>
         </ext:TabPanel>
 <%--樣板 --%>  
    </form>
</body>
</html>
