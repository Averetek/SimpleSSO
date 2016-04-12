using System;

namespace SimpleSSO
{
	public partial class SSOOut : System.Web.UI.Page
	{
		private static readonly string receiverURL = System.Configuration.ConfigurationManager.AppSettings["receiverURL"];

		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;

			var userRole = "Partner";
			var userId = "003f005601409FoI6ABC";
			var email = "johnsmith@test.com";
			var first = "John";
			var last = "Smith";
			var targetURL = string.Empty; //Deeplink URL

			var organizationName = "Fake, Inc.";
			var organizationNumber = "000-000-000";
			var address1 = "123 Fake St.";
			var address2 = string.Empty;
			var city = "Seattle";
			var region = "WA";
			var country = "US";
			var postalCode = "98125";

			var sharedKey = System.Configuration.ConfigurationManager.AppSettings["SharedKey"];
			var hashInfo = string.Format("{0}{1}{2}", organizationNumber, email, sharedKey);
			var hash = CalculateSha1(hashInfo);


			Response.Clear();
			var sb = new System.Text.StringBuilder();
			sb.Append("<html>");
			sb.AppendFormat("<body onload='document.forms[0].submit()'>");
			sb.AppendFormat("<form id='marketingLogin' name='marketingLogin' action='{0}' method='post'>", receiverURL);
			sb.AppendFormat("<input type='hidden' name='userRole' value='{0}'>", userRole);
			sb.AppendFormat("<input type='hidden' name='userId' value='{0}'>", userId);
			sb.AppendFormat("<input type='hidden' name='email' value='{0}'>", email);
			sb.AppendFormat("<input type='hidden' name='first' value='{0}'>", first);
			sb.AppendFormat("<input type='hidden' name='last' value='{0}'>", last);
			sb.AppendFormat("<input type='hidden' name='targetURL' value='{0}'>", targetURL);
			sb.AppendFormat("<input type='hidden' name='v' value='{0}'>", hash);
			sb.AppendFormat("<input type='hidden' name='organizationName' value='{0}'>", organizationName);
			sb.AppendFormat("<input type='hidden' name='organizationNumber' value='{0}'>", organizationNumber);
			sb.AppendFormat("<input type='hidden' name='address1' value='{0}'>", address1);
			sb.AppendFormat("<input type='hidden' name='address2' value='{0}'>", address2);
			sb.AppendFormat("<input type='hidden' name='city' value='{0}'>", city);
			sb.AppendFormat("<input type='hidden' name='region' value='{0}'>", region);
			sb.AppendFormat("<input type='hidden' name='country' value='{0}'>", country);
			sb.AppendFormat("<input type='hidden' name='postalCode' value='{0}'>", postalCode);
			sb.Append("</form>");
			sb.Append("</body>");
			sb.Append("</html>");
			Response.Write(sb.ToString());
			Response.End();
		}

		private static string CalculateSha1(string text)
		{
			var buffer = System.Text.Encoding.UTF8.GetBytes(text);
			var cryptoTransformSha1 = new System.Security.Cryptography.SHA1CryptoServiceProvider();
			var hash = BitConverter.ToString(cryptoTransformSha1.ComputeHash(buffer)).Replace("-", "");

			return hash;
		}
	}
}