<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_R_child1.aspx.cs" Inherits="EDA_Sign.Child1_" %>
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
                            <!--查詢資料 -->
                        <ext:Panel ID="FormPanel1" Layout="Column" runat="server"   Frame="true" Title="查詢資料">
                             <Items>
                                <ext:Panel ID="Panel2" runat="server" Border="false" ColumnWidth="1" Layout=ColumnLayout BodyStyle="padding:1px">
                                    <Items>
                                        <ext:TextField ID="Find_Category" runat="server" FieldLabel="Category" Name="Find_Category"   EnforceMaxLength = "true"  MaxLength = "8" />
  
                                        <ext:TextField ID="Find_Part_Id" runat="server" FieldLabel="Part_Id" Name="Find_Part_Id"   EnforceMaxLength = "true"  MaxLength = "7" />
                          
                                        <ext:TextField ID="Find_EDA_Item" runat="server" FieldLabel="EDA_Item" Name="Find_EDA_Item" EnforceMaxLength = "true"  MaxLength = "30"  />
                                   </Items>
                                </ext:Panel>
                            </Items>
                            <Buttons>
                             <ext:Button runat="server" ID="btnLookup" Text="查詢" Icon="Accept">
                                    <DirectEvents>
                                        <Click OnEvent="btnLookup_DirectClick">
                                        <EventMask ShowMask="true" Msg="處理中..."></EventMask>
                                         <ExtraParams>
                                                <ext:Parameter Name="Text_Customer_ID" runat="server" Value="Customer_ID"></ext:Parameter>
                                         </ExtraParams>
                                         </Click>
                                    </DirectEvents>
                             </ext:Button> 
                             </Buttons>                  
                        </ext:Panel>
                      

  <!--資料庫資料-->
        <ext:Store ID="Store1" runat="server" PageSize="19" AutoSync="true" >
        <Model>
            <ext:Model ID="Model1" runat="server" Name="Model_Custom" >
                <Fields>
                    <ext:ModelField Name="ID" Type="String" />
                    <ext:ModelField Name="Customer_ID" Type="String" />
                    <ext:ModelField Name="Category" Type="String" />
                    <ext:ModelField Name="Part" Type="String" />
					<ext:ModelField Name="Part_Id" Type="String" />
					<ext:ModelField Name="Yield_Impact_Item" Type="String" />
					<ext:ModelField Name="Key_Module" Type="String" />
					<ext:ModelField Name="Data_Source" Type="String" />
					<ext:ModelField Name="Critical_Item" Type="String" />
					<ext:ModelField Name="EDA_Item" Type="String" />
					<ext:ModelField Name="MAIN_ID" Type="String" />
                </Fields>
            </ext:Model>
        </Model>
    </ext:Store>
                    <%-- DATA LIST--%>
                
                        <Items>
                            <ext:Panel ID="Panel1" runat="server" Title="Sign data">
                                <Items>
                                    <ext:GridPanel ID="GridPanel1" runat="server" StoreID="Store1">
                                        <ColumnModel ID="ColumnModel1" runat="server">

                                            <Columns>
 				                            <ext:Column ID="Column5" runat="server" Text="ID" DataIndex="ID"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField1" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column6" runat="server" Text="Customer_ID" DataIndex="Customer_ID"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField2" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column7" runat="server" Text="Category" DataIndex="Category"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField3" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column8" runat="server" Text="Part" DataIndex="Part"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField4" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column9" runat="server" Text="Part_Id" DataIndex="Part_Id"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField5" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column10" runat="server" Text="Yield_Impact_Item" DataIndex="Yield_Impact_Item"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField6" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column11" runat="server" Text="Key_Module" DataIndex="Key_Module"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField7" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column12" runat="server" Text="Data_Source" DataIndex="Data_Source"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField8" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column13" runat="server" Text="Critical_Item" DataIndex="Critical_Item"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField9" runat="server" />
                                                </Editor>
                                            </ext:Column>
				                            <ext:Column ID="Column14" runat="server" Text="EDA_Item" DataIndex="EDA_Item"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField10" runat="server" />
                                                </Editor>
                                            </ext:Column>       
				                            <ext:Column ID="Column15" runat="server" Text="MAIN_ID" DataIndex="MAIN_ID"  Sortable="false">
                                                <Editor>
                                                    <ext:TextField ID="TextField11" runat="server" />
                                                </Editor>
                                              <%---- javascript   <Renderer Fn="change"/>--%> 
                                            </ext:Column>       
                                            </Columns>
 
                                        </ColumnModel>
                                        <%--選擇GRID的資料 --%>
										<SelectionModel>
                                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="single" InjectCheckbox="0">
                                       			
                                       			<Listeners>
                                                        <Select Handler="#{UserForm2}.getForm().loadRecord(record);" />
                                                  </Listeners>

                                                    <DirectEvents>
                                                         <Select OnEvent="Cell_Click">
                                                             <ExtraParams>
                                                                 <ext:Parameter Name="ID" Value="record.get('ID')" Mode="Raw" />  
                                                                    <ext:Parameter Name="Customer_ID" Value="record.get('Customer_ID')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Category" Value="record.get('Category')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Part" Value="record.get('Part')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Part_Id" Value="record.get('Part_Id')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Yield_Impact_Item" Value="record.get('Yield_Impact_Item')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Key_Module" Value="record.get('Key_Module')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Data_Source" Value="record.get('Data_Source')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Critical_Item" Value="record.get('Critical_Item')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="EDA_Item" Value="record.get('EDA_Item')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="MAIN_ID" Value="record.get('MAIN_ID')" Mode="Raw" />        

                                                             </ExtraParams>
                                                         </Select>
                                                     </DirectEvents>
                								
                                              </ext:CheckboxSelectionModel>
                                        </SelectionModel>
										<BottomBar>
												<ext:PagingToolbar ID="PagingToolbar1" runat="server" StoreID="Store1" HideRefresh ="true" />
                                    
     							        </BottomBar>
 
                                    </ext:GridPanel>
                                </Items>
                            </ext:Panel>
                        </Items>


                


                <%--點div 並顯示在欄位上--%>

           
                    <ext:FormPanel ID="UserForm2" Layout="Column" runat="server" Icon="User" Frame="true" Title="選取資料">
                        <FieldDefaults LabelAlign="Right" AllowBlank="false" />
                        <Items>
                            <ext:Panel ID="Panel9" runat="server" Border="false" ColumnWidth="1" Layout="ColumnLayout" BodyStyle="padding:5px">
                                <Items>
                                    <ext:TextField ID="Text_Id" runat="server" FieldLabel="ID" Name="ID" ReadOnly="true"  />
                                    <ext:TextField ID="Text_Customer_ID" runat="server" FieldLabel="Customer_ID" Name="Customer_ID"  Length='15' EnforceMaxLength = "true"  MaxLength = "15"/>
                                    <ext:TextField ID="Text_Category" runat="server" FieldLabel="Category" Name="Category" EnforceMaxLength = "true"  MaxLength = "8" />
                                    <ext:TextField ID="Text_Part" runat="server" FieldLabel="Part" Name="Part" EnforceMaxLength = "true"  MaxLength = "7"/>
                                    <ext:TextField ID="Text_Part_Id" runat="server" FieldLabel="Part_Id" Name="Part_Id" ReadOnly="true"  />
                                    <ext:TextField ID="Text_Yield_Impact_Item" runat="server" FieldLabel="Yield_Impact_Item" Name="Yield_Impact_Item" EnforceMaxLength = "true"  MaxLength = "15"/>
                                    <ext:TextField ID="Text_Key_Module" runat="server" FieldLabel="Key_Module" Name="Key_Module" EnforceMaxLength = "true"  MaxLength = "15" />
                                    <ext:TextField ID="Text_Data_Source" runat="server" FieldLabel="Data_Source" Name="Data_Source" EnforceMaxLength = "true"  MaxLength = "10" />
                                    <ext:TextField ID="Text_Critical_Item" runat="server" FieldLabel="Critical_Item" Name="Critical_Item" EnforceMaxLength = "true"  MaxLength = "50"/>
                                    <ext:TextField ID="Text_EDA_Item" runat="server" FieldLabel="EDA_Item" Name="EDA_Item" ReadOnly="true"  />
                                    <ext:TextField ID="Text_MAIN_ID" runat="server" FieldLabel="MAIN_ID" Name="MAIN_ID" EnforceMaxLength = "true"  MaxLength = "2" />
                                </Items>

                          <%-- update date --%>
                                 <Buttons>
                                <ext:Button runat="server" ID="btnOK" Text="修改" Icon="Accept">
                                    <DirectEvents>
                                        <Click OnEvent="btnUpdae_DirectClick">
                                        <EventMask ShowMask="true" Msg="處理中..."></EventMask>
                                         <ExtraParams>
                                                <ext:Parameter Name="Text_Customer_ID" runat="server" Value="Customer_ID"></ext:Parameter>
                                         </ExtraParams>
                                         </Click>
                                    </DirectEvents>
                                </ext:Button>  
                                </Buttons> 
                                
                                <Buttons>
                               <ext:Button runat="server" ID="Button1" Text="刪除" Icon="Cross">
                                    <DirectEvents>
                                        <Click OnEvent="btnDel_DirectClick">
                                        <EventMask ShowMask="true" Msg="處理中..."></EventMask>

                                         </Click>
                                    </DirectEvents>
                                </ext:Button>
                                </Buttons>


                            </ext:Panel>
                        </Items>
                      </ext:FormPanel>
      
  
    </form>
</body>
</html>
