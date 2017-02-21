<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="MqttWebClient.Dashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">        
        <asp:ScriptManager ID="ScriptManager1" runat="server" />
        <asp:UpdatePanel runat="server" id="UpdatePanel">
            <ContentTemplate>
                <asp:Button runat="server" id="Button1" text="Connect" OnClick="Button1_Click" />
                <asp:Timer runat="server" id="Timer2" Interval="5000" OnTick="Timer2_Tick"></asp:Timer>
                <br>
                Tempurature 1 :
                <asp:Label runat="server" id="Sensor1" BackColor="#FFCCFF" /><br>                             
                Humidity 1 :
                <asp:Label runat="server" id="Sensor2" BackColor="#66FF33" />                
            </ContentTemplate>
        </asp:UpdatePanel>
    </form>
</body>
</html>
