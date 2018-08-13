<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MainPage.aspx.cs" Inherits="Weather_dashboard_challenge.WebForm1" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <script src="../Scripts/bootstrap.js"></script>
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
    <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
    <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <title></title>
</head>
<body>
    <script src="http://code.jquery.com/jquery.js"></script>
    <script src="../Scripts/bootstrap.min.js"></script>
    <form id="mainPage" runat="server">
        <div class="container">
            <div class="jumbotron" style="margin-left: 25%; margin-right: 25%">
                <h1>Weather dashboard</h1> 
            </div>
        </div>

        <div class="container">
            <div class="row">
                <div class="col-md-2">
                    <asp:Label ID="lblCity" runat="server" Text="City"></asp:Label>
                    
                    <asp:DropDownList ID="ddlCity" runat="server" AutoPostBack="True" DataSourceID="XmlParametersDataSource" DataTextField="name" DataValueField="name" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" TabIndex="1">
                    </asp:DropDownList>
                    
                    <asp:XmlDataSource ID="XmlParametersDataSource" runat="server" DataFile="~/XML/SearchingParameters.xml" XPath="/parameters/cities/city"></asp:XmlDataSource>
                    <br />
                    <br />
                    <asp:Label ID="lblEscala" runat="server" Text="Scale"></asp:Label>
                    
                    <asp:DropDownList ID="ddlScale" runat="server" AutoPostBack="True" DataSourceID="XmlScaleDataSource" DataTextField="name" DataValueField="value" OnSelectedIndexChanged="ddlScale_SelectedIndexChanged" TabIndex="2">
                    </asp:DropDownList>
                    
                    <asp:XmlDataSource ID="XmlScaleDataSource" runat="server" DataFile="~/XML/SearchingParameters.xml" XPath="/parameters/scales/scale"></asp:XmlDataSource>
                </div>
                <div class="col-md-2">
                    <asp:Label ID="lblDays" runat="server" Text="Days"></asp:Label>
                    <br />
                    <asp:DropDownList ID="ddlDays" runat="server" AutoPostBack="True" DataSourceID="XmlDaysDataSource" DataTextField="number" DataValueField="value" OnSelectedIndexChanged="ddlCity_SelectedIndexChanged" TabIndex="1" OnTextChanged="ddlDays_TextChanged">
                    </asp:DropDownList>
                    <asp:XmlDataSource ID="XmlDaysDataSource" runat="server" DataFile="~/XML/SearchingParameters.xml" XPath="parameters/days/day"></asp:XmlDataSource>
                    <asp:XmlDataSource ID="XmlDataSource1" runat="server"></asp:XmlDataSource>
                </div>
                <div class="col-md-4">  
                    <asp:Calendar ID="calendar" runat="server" SelectionMode="None"></asp:Calendar>
                </div>
                <div class="col-md-4">
                    <asp:Table ID="tblTemperatures" runat="server">
                        <asp:TableRow runat="server" HorizontalAlign="Center" VerticalAlign="Middle">
                            <asp:TableCell runat="server">Date</asp:TableCell>
                            <asp:TableCell runat="server">Temperature</asp:TableCell>
                        </asp:TableRow>
                    </asp:Table>
                </div>
             </div>
        </div>
        <div class="container">
            <div class="col-md-12">
                <asp:Chart ID="chartTemperatures" runat="server" style="width:100%" Width="1250px" TabIndex="4">
                    <Series>
                        <asp:Series ChartType="Line" Name="Series1">
                        </asp:Series>
                    </Series>
                    <ChartAreas>
                        <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </ChartAreas>
                </asp:Chart>
            </div>
        </div>
    </form>
</body>
</html>
