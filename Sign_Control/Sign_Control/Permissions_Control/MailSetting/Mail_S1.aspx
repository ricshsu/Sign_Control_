<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail_S1.aspx.cs" Inherits="EDA_Mail.MailS1Main_" %>
<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel=stylesheet type="text/css" href="./style/Sign_style.css">
 
    <style type="text/css">
        .style1 {
            width: 100px;
            height: 100px;
        }
    </style>
 
</head>

<body class= "main_body">

<form id="signup_" runat="server">

<img alt="" class="style1" src="../Files/Top_pic.png" /><br /> 
<%--匯出資料 ext.net --%>


 <ext:ResourceManager ID="ResourceManager_2" runat="server" />

     <div class="divcss-left" >
 
    </div>
    <div>
 
     </div>

  <%--樣板 --%>
 
          <ext:TabPanel ID="TabPanel1"  runat="server" Height="800"  Layout="FitLayout"
            DeferredRender="false" >
            <Items>

                <ext:Panel ID="Panel2" runat="server" Title="Update , Delete"  >
                    <Loader ID="Loader2"  runat="server" Url="Mail_S1_Child1.aspx" Mode="Frame" AutoLoad ="true" >
                        <LoadMask ShowMask="true" />
                    </Loader>
                </ext:Panel>

                
                <ext:Panel ID="Panel1" runat="server" Title="Create(single)"  >
                    <Loader ID="Loader1"  runat="server" Url="Mail_S1_Child2.aspx" Mode="Frame" AutoLoad ="true" >
                        <LoadMask ShowMask="true" />
                    </Loader>
                </ext:Panel>

            </Items>
         </ext:TabPanel>
     <!-- 新增資料-->
 
  
 <%--樣板 --%>  
    </form>
</body>
</html>
