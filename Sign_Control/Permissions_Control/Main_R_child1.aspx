<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_R_child1.aspx.cs" Inherits="EDA_IBF.sample_3" %>
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

<script>
    var template = '<span class="{0}">{1}</span>';
    var change = function (value) {
        return Ext.String.format(template, (value > 1) ? "positive" : "negative", value);
    };
 
</script>

</head>
<body class ="R_Child1">
    <form id="signup_" runat="server">
    <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Store ID="Store1" runat="server" PageSize="19" AutoSync="true">
        <Model>
            <ext:Model ID="Model1" runat="server" Name="Model_Custom">
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
                            <ext:Panel ID="Panel1" runat="server" Title="Grid Panel">
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
                                                <Renderer Fn="change"/>
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

           
                    <ext:FormPanel ID="UserForm2" Layout="Column" runat="server" Icon="User" Frame="true"
                             Title="選取資料">
                        <FieldDefaults LabelAlign="Right" AllowBlank="false" />
                        <Items>
                            <ext:Panel ID="Panel9" runat="server" Border="false" ColumnWidth="1" Layout="ColumnLayout" BodyStyle="padding:5px">
                                <Items>
                                    <ext:TextField ID="Text_Id" runat="server" FieldLabel="ID" Name="ID" ReadOnly="true"  />
                                    <ext:TextField ID="Text_Customer_ID" runat="server" FieldLabel="Customer_ID" Name="Customer_ID" />
                                </Items>
                            </ext:Panel>
                        </Items>

  
                     </ext:FormPanel>
               
                        <%-- update date --%>
                                <div class="divcss-right">
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
                                </div>
                                        </div> 
                                <div class="divcss-right">
                                <ext:Button runat="server" ID="Button1" Text="刪除" Icon="Cross">
                                    <DirectEvents>
                                        <Click OnEvent="btnDel_DirectClick">
                                        <EventMask ShowMask="true" Msg="處理中..."></EventMask>
                                         <ExtraParams>
                                                <ext:Parameter Name="Text_Customer_ID" runat="server" Value="Customer_ID"></ext:Parameter>
                                         </ExtraParams>
                                         </Click>
                                    </DirectEvents>
                                </ext:Button>  
 

            
  
    </form>
</body>
</html>
