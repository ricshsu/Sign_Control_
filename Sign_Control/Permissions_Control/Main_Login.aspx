<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main_Login.aspx.cs" Inherits="Permissions_Control.Main_Login" %>
<%@ Register assembly="Ext.Net" namespace="Ext.Net" tagprefix="ext" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">

    <script>
        // Invalidate the login fields with the given reason.
        var invalidateLogin = function (reason) {
            App.txtUsername.setValidation(reason);
            App.txtPassword.setValidation(reason);
            App.txtUsername.validate();
            App.txtPassword.validate();
            console.log("here am i");
            Ext.MessageBox.show({
                title: '驗證錯誤',
                msg: reason,
                buttons: Ext.MessageBox.OK,
                animateTarget: 'Window1',
                icon: 'Error'
            });
        };

        var handleLogin = function () {
            var form = App.Window1.el.up().dom; // Window1 is a direct child of the form element.

            App.Window1.close();

            // Now this would work for Chrome, and we already triggered autoComplete for IE.
            // Chrome's is only triggered after the destination page is loaded.
            setForm(form, "Main_R.aspx", form.target);
            form.submit();
            restoreForm(form);
        };

        var orgFormAction, orgFormTarget,
            btn = null, iframe = null;

        // If we are on IE, we will create a button and click it (at once),
        // so autoComplete is triggered.
        var handleClientClick = function () {
            var form = App.Window1.el.up().dom; // Window1 is a direct child of the form element.

            if (Ext.isIE) {
                if (iframe == null) {
                    iframe = document.createElement("IFRAME");
                    iframe.name = "ie_login_flush";
                    iframe.style.display = "none";
                    form.appendChild(iframe);
                }

                if (btn == null) {
                    btn = document.createElement("BUTTON");
                    btn.type = "submit";
                    btn.id = "submitButton";
                    btn.style.display = "none";
                    form.appendChild(btn);
                }

                // On WebForms, we have to force set the form settings as we run or else we'll
                // break directEvent calls.
                setForm(form, "about:blank", "ie_login_flush");
                btn.click();
                restoreForm(form);
            }
        }

        var setForm = function (form, action, target) {
            // Back up original settings once per execution.
            if (typeof orgFormAction == 'undefined') {
                orgFormAction = form.action;
            }
            if (typeof orgFormTarget == 'undefined') {
                orgFormTarget = form.target;
            }

            form.action = action;
            form.target = target;
        };

        var restoreForm = function (form) {
            form.action = orgFormAction;
            form.target = orgFormTarget;
        };
    </script> 

</head>
<body>
     <form id="Form1" runat="server">
        <ext:ResourceManager runat="server" />
 
        <ext:Window
            ID="Window1"
            runat="server"
            Closable="false"
            Resizable="false"
            Height="200"
            Icon="Lock"
            Title="Login"
            Draggable="true"
            Width="350"
            Modal="false"
            BodyPadding="5"
            Layout="Form">
            <Items>
                <ext:TextField
                    ID="txtUsername"
                    runat="server"
                    Name="username"
                    FieldLabel="Username"
                    AllowBlank="false"
                    BlankText="Your username is required." />
                <ext:TextField
                    ID="txtPassword"
                    runat="server"
                    Name="password"
                    InputType="Password"
                    FieldLabel="Password"
                    AllowBlank="false"
                    BlankText="Your password is required." />
            </Items>
            <Buttons>
                <ext:Button
                    ID="Button1"
                    runat="server"
                    Text="Login"
                    Icon="Accept"
                    FormBind="true"
                    Handler="handleClientClick">
                    <DirectEvents>
                        <Click
                            OnEvent="Button1_Click"
                            Success="handleLogin"
                            Failure="invalidateLogin(result.errorMessage);"
                            ShowWarningOnFailure="false">
                            <EventMask ShowMask="true" Msg="驗證中..." MinDelay="1000" />
                            <ExtraParams>
                                <ext:Parameter Name="user" Value="App.txtUsername.value" Mode="Raw" />
                                <ext:Parameter Name="pass" Value="App.txtPassword.value" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Buttons>
        </ext:Window>
    </form>
</body>
</html>
