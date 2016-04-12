<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SSOIn.aspx.cs" Inherits="SimpleSSO.SSOIn" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
	<title></title>
</head>
<body>
	<form id="form1" runat="server">
		<div>
			<table>
				<tr>
					<td colspan="2">Received Values</td>
				</tr>
				<tr>
					<td>User Role</td>
					<td>
						<asp:Literal runat="server" ID="ltUserRole"></asp:Literal></td>
				</tr>
				<tr>
					<td>User ID</td>
					<td>
						<asp:Literal runat="server" ID="ltUserID"></asp:Literal></td>
				</tr>
				<tr>
					<td>Email</td>
					<td>
						<asp:Literal runat="server" ID="ltEmail"></asp:Literal></td>
				</tr>
				<tr>
					<td>First Name</td>
					<td>
						<asp:Literal runat="server" ID="ltFistName"></asp:Literal></td>
				</tr>
				<tr>
					<td>Last Name</td>
					<td>
						<asp:Literal runat="server" ID="ltLastName"></asp:Literal></td>
				</tr>
				<tr>
					<td>Target URL</td>
					<td>
						<asp:Literal runat="server" ID="ltTargetURL"></asp:Literal></td>
				</tr>
				<tr>
					<td>Organization Name</td>
					<td>
						<asp:Literal runat="server" ID="ltOrganizationName"></asp:Literal></td>
				</tr>
				<tr>
					<td>Organization Number</td>
					<td>
						<asp:Literal runat="server" ID="ltOrganizationNumber"></asp:Literal></td>
				</tr>
				<tr>
					<td>Address Line 1</td>
					<td>
						<asp:Literal runat="server" ID="ltAddressLine1"></asp:Literal></td>
				</tr>
				<tr>
					<td>Address Line 2</td>
					<td>
						<asp:Literal runat="server" ID="ltAddressLine2"></asp:Literal></td>
				</tr>
				<tr>
					<td>City</td>
					<td>
						<asp:Literal runat="server" ID="ltCity"></asp:Literal></td>
				</tr>
				<tr>
					<td>State / Region</td>
					<td>
						<asp:Literal runat="server" ID="ltRegion"></asp:Literal></td>
				</tr>
				<tr>
					<td>Country</td>
					<td>
						<asp:Literal runat="server" ID="ltCountry"></asp:Literal></td>
				</tr>
				<tr>
					<td>Postal Code</td>
					<td>
						<asp:Literal runat="server" ID="ltPostalCode"></asp:Literal></td>
				</tr>
				<tr>
					<td>Security hashes match?</td>
					<td>
						<asp:Literal runat="server" ID="ltHashStatus"></asp:Literal><br/>
						<asp:literal runat="server" ID="ltHash"></asp:literal>
					</td>
				</tr>
			</table>
		</div>
	</form>
</body>
</html>
