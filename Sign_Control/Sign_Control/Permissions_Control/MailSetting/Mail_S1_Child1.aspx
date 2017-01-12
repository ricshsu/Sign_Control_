﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Mail_S1_Child1.aspx.cs" Inherits="EDA_Mail.Mail_S1_Child1" %>


<%@ Import Namespace="System.Data" %>
<%@ Import Namespace="System.Linq" %>
<%@ Import Namespace="System.Collections.Generic" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
  <form id="mail_" runat="server">
 
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
										<SelectionModel>
                                            <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server" Mode="single" InjectCheckbox="0">
                                       			
                                       			<Listeners>
                                                        <Select Handler="#{UserForm2}.getForm().loadRecord(record);" />
                                                  </Listeners>

                                                    <DirectEvents>
                                                         <Select OnEvent="Cell_Click">
                                                             <ExtraParams>
                                                                 <ext:Parameter Name="SYSTEM_ID" Value="record.get('SYSTEM_ID')" Mode="Raw" />  
                                                                    <ext:Parameter Name="USER_NOTES" Value="record.get('USER_NOTES')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="MAIL_ADS" Value="record.get('MAIL_ADS')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="IS_SEND" Value="record.get('IS_SEND')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="IS_MODIFY" Value="record.get('IS_MODIFY')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="IS_CC" Value="record.get('IS_CC')" Mode="Raw" /> 
                                                                    <ext:Parameter Name="Name" Value="record.get('Name')" Mode="Raw" /> 
 

                                                             </ExtraParams>
                                                         </Select>
                                                     </DirectEvents>
                								
                                              </ext:CheckboxSelectionModel>
                                        </SelectionModel>
										<BottomBar>
												<ext:PagingToolbar ID="PagingToolbar1" runat="server" StoreID="Storemail" HideRefresh ="true" />
                                    
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

 


                            </ext:Panel>
                        </Items>
                      </ext:FormPanel>
      
  
    </form>
</body>
</html>