<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_R_child1_.aspx.cs" Inherits="EDA_IBF.sample_2" %>
<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel=stylesheet type="text/css" href="./style/Sample.css">
    <title></title>
 
 
</head>
<body>
    <form id="signup_" runat="server">
        <div class="container">
    

        <div>
         <asp:FileUpload ID="FileUpload_ASP"  runat="server">
        </asp:FileUpload>
        <asp:Button ID="Button1" runat="server" Text="CSV 上傳"  OnClick = "Upload_1" />
        </div>
            <br /><br /> 
        </div>
        <div class="container">        
         <ext:FileUploadField ID="BasicFieldEXT_1" runat="server" Width="400" Icon="Attach" />
         <ext:Button ID="Button_ext1" ></ext:Button>
         <ext:Button ID="Button_ext" runat="server" Text="NPOI_TO_IMP(CSV)" OnDirectClick="Upload_2" >
             <Listeners>
                 <Click Handler="alert('資料匯入');" />
             </Listeners>   
         </ext:Button>
        </div>
        </div>
            <br /><br /> 
        </div>
    <%--ext.net csv --%>

 

    <div class="container">
        <div>
         <asp:FileUpload ID="FileUpload_EXT"  runat="server">
         </asp:FileUpload>
         <asp:Button ID="Button2" runat="server" Text="excel 上傳"  OnClick = "Upload_2" />
         </div>
     </div>

<%--匯出資料 ext.net --%>

<br /><br /><br /><br /><br /><br /><br /><br /><br /><br />
 <div class="container">

 <ext:ResourceManager ID="ResourceManager1" runat="server" DirectMethodNamespace="extSample"   />
  <p>EXT.net</p>
     <div>
     <ext:FileUploadField ID="BasicFieldEXT" runat="server" Width="400" Icon="Attach" />
 
        <ext:Button ID="Button9" runat="server" Text="NPOI_TO_IMP(CSV)" OnDirectClick="Button_Upload_EXT">
             <Listeners>
                <Click Handler="alert('資料匯入');" />
            </Listeners>   

        </ext:Button>
        <ext:Button ID="Button10" runat="server" Text="NPOI_TO_EXP" OnDirectClick="ButtonExpEXCEL">
            <Listeners>
                <Click Handler="alert('資料匯出');" />
            </Listeners>
        </ext:Button>                    
 
<%--         <ext:Button ID="Button3"
                runat="server"
                Text="Click Me_show_time"
                AutoLoadingState="true"
                OnDirectClick="Button1_Click"
                />--%>
 
    </div>
<%--
     <h1>Simple Login Form with Ajax Submit</h1>

        <ext:Button
            ID="Button4"
            runat="server"
            Text="Logout"
            Icon="LockOpen">
            <Listeners>
                <Click Handler="#{Window1}.show();" />
            </Listeners>
        </ext:Button>

        <ext:Label ID="lblMessage" runat="server" />
 

</div>--%>
    </form>
</body>
</html>
