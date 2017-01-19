<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail_S1_Child2.aspx.cs" Inherits="EDA_Mail.Child2_" %>
<%@ Register Assembly="System.Web, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a" Namespace="System.Web.UI.WebControls" TagPrefix="asp" %>

<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<link rel=stylesheet type="text/css" href="./style/Sign_style.css">
    <title></title>
<script src="js/jquery-1.9.1.js" type="text/javascript"></script>
 

</head>
<body class ="R_Child1">

    <form id="signup_" runat="server">
 
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
    
 
 

  <!--資料庫資料-->
        <ext:Store ID="Storemail" runat="server" PageSize="19" AutoSync="true" >
        <Model>
            <ext:Model ID="Model1" runat="server" Name="Model_Custom" >
                <Fields>
                    <ext:ModelField Name="SYSTEM_ID" Type="String" />
                    <ext:ModelField Name="USER_NOTES" Type="String" />
                    <ext:ModelField Name="MAIL_ADS" Type="String" />
                    <ext:ModelField Name="IS_SEND" Type="String" />
					<ext:ModelField Name="IS_MODIFY" Type="String" />
					<ext:ModelField Name="IS_CC" Type="String" />
					<ext:ModelField Name="Name" Type="String" />
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>

    <!-- 新增資料-->
                        <ext:FormPanel ID="FormPanel2" Layout="Column" runat="server" Icon="User" Frame="true" Title="新增資料">
                        <FieldDefaults LabelAlign="Right" AllowBlank="false" />
                        <Items>
                            <ext:Panel ID="Panel3" runat="server" Border="false" ColumnWidth="1" Layout="ColumnLayout" BodyStyle="padding:5px">
                                <Items>
<%--                                    <ext:TextField  ID="New_SYSTEM_ID" runat="server" FieldLabel="SYSTEM_ID" Name="New_SYSTEM_ID"  Length="15" EnforceMaxLength = "true"  MaxLength = "15" AllowBlank ="false"/>--%>
                                    <ext:TextField ID="New_USER_NOTES" runat="server" FieldLabel="USER_NOTES" Name="New_USER_NOTES" EnforceMaxLength = "true"  MaxLength = "16" AllowBlank ="false" />
                                    <ext:TextField ID="New_MAIL_ADS" runat="server" FieldLabel="MAIL_ADS" Name="New_MAIL_ADS" EnforceMaxLength = "true"  MaxLength = "64" AllowBlank ="false"/>
                                    <ext:TextField ID="New_IS_SEND" runat="server" FieldLabel="IS_SEND" Name="New_IS_SEND" EnforceMaxLength = "true" AllowBlank ="false"  MaxLength = "1"/>
                                    <ext:TextField ID="New_IS_MODIFY" runat="server" FieldLabel="MODIFY" Name="New_IS_MODIFY" EnforceMaxLength = "true"  MaxLength = "1" AllowBlank ="false"/>
                                    <ext:TextField ID="New_IS_CC" runat="server" FieldLabel="IS_CC" Name="New_IS_CC" EnforceMaxLength = "true"  MaxLength = "1" AllowBlank ="false"  />
                                    <ext:TextField ID="New_Name" runat="server" FieldLabel="Name" Name="New_Name" EnforceMaxLength = "true"  MaxLength = "20" AllowBlank ="false" />
                               </Items>

                          <%-- update date --%>
                                 <Buttons>
                                <ext:Button runat="server" ID="Button3" Text="新增" Icon="Accept">
                                    <DirectEvents>
                                        <Click OnEvent="btnNew_DirectClick">
                                        <EventMask ShowMask="true" Msg="處理中..."></EventMask>
                                         <ExtraParams>
                                                <ext:Parameter Name="New_SYSTEM_ID" runat="server" Value="New_SYSTEM_ID"></ext:Parameter>
                                         </ExtraParams>
                                         </Click>
                                    </DirectEvents>
                                </ext:Button>  
                                </Buttons> 
                               
                            </ext:Panel>
                        </Items>
                      </ext:FormPanel>

                    <%-- DATA LIST--%>
                
                        <Items>
                            <ext:Panel ID="Panel1" runat="server" Title="Sign data">
                                <Items>
                                    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="Storemail">
                                        <ColumnModel ID="ColumnModel1" runat="server">

                                            <Columns>
				                            <ext:Column ID="Column6" runat="server" Text="SYSTEM_ID" DataIndex="SYSTEM_ID"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField2" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column7" runat="server" Text="USER_NOTES" DataIndex="USER_NOTES"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField3" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column8" runat="server" Text="MAIL_ADS" DataIndex="MAIL_ADS"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField4" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column9" runat="server" Text="IS_SEND" DataIndex="IS_SEND"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField5" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column10" runat="server" Text="IS_MODIFY" DataIndex="IS_MODIFY"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField6" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column11" runat="server" Text="IS_CC" DataIndex="IS_CC"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField7" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column12" runat="server" Text="Name" DataIndex="Name"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField1" runat="server" />
                                                </Editor>
                                            </ext:Column>

                                              <%---- javascript   <Renderer Fn="change"/>--%> 
                                           
                                            </Columns>
 
                                        </ColumnModel>
                                        <%--選擇GRID的資料 --%>
	 
										<BottomBar>
												<ext:PagingToolbar ID="PagingToolbar1" runat="server" StoreID="Storemail" HideRefresh ="true" />
                                    
     							        </BottomBar>
 
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>

 

           
                    
      
  
    </form>
</body>
</html>
