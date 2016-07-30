using System;

namespace SimpleSSO
{
	public partial class SSOIn : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
			if (IsPostBack) return;
            #region Read Form
            var userRole = Request.Form["userRole"].Trim();
			var userId = Request.Form["userId"].Trim();
			var email = (Request.Form["email"] ?? string.Empty).Trim();
			var first = (Request.Form["first"] ?? string.Empty).Trim();
			var last = (Request.Form["last"] ?? string.Empty).Trim();
			var targetURL = (Request.Form["targetURL"] ?? string.Empty).Trim();
			var v = (Request.Form["v"] ?? string.Empty).Trim();
			var organizationName = (Request.Form["organizationName"] ?? string.Empty).Trim();
			var organizationNumber = (Request.Form["organizationNumber"] ?? string.Empty).Trim();
			var address1 = (Request.Form["address1"] ?? string.Empty).Trim();
			var address2 = (Request.Form["address2"] ?? string.Empty).Trim();
			var city = (Request.Form["city"] ?? string.Empty).Trim();
			var region = (Request.Form["region"] ?? string.Empty).Trim();
			var country = (Request.Form["country"] ?? string.Empty).Trim();
			var postalCode = (Request.Form["postalCode"] ?? string.Empty).Trim();

			var sharedKey = System.Configuration.ConfigurationManager.AppSettings["SharedKey"];
			var hashInfo = string.Format("{0}{1}{2}", organizationNumber, email, sharedKey);
			var hash = CalculateSha1(hashInfo);
            var hashStatus = hash.ToLower().Equals(v.ToLower());
            #endregion 

            /* This is here for testing purposes only. Remove after a successful setup. */
            #region Validation
            var regexUtils = new Library.RegexUtilities();
            if(regexUtils.IsValidEmail(email))
            {
                Response.Write("ERROR: Missing or invalid email address");
                return;
            }
            if(string.IsNullOrWhiteSpace(country))
            {
                Response.Write("ERROR: Missing country");
                return;
            }
            if(string.IsNullOrWhiteSpace(userId))
            {
                Response.Write("ERROR: Missing userId");
                return;
            }
            if(string.IsNullOrWhiteSpace(organizationNumber))
            {
                Response.Write("ERROR: Missing organizationNumber");
                return;
            }
            if(string.IsNullOrWhiteSpace(organizationName))
            {
                Response.Write("ERROR: Missing organizationName");
                return;
            }
            if(string.IsNullOrWhiteSpace(v))
            {
                Response.Write("ERROR: Missing v e.g. SHA1(organizationNumber + email + sharedKey)");
                return;
            }
            if(!hashStatus)
            {
                Response.Write($"ERROR: Invalid verification code (v). Expecting {hash}");
                return;
            }
            #endregion

            #region Output
            ltUserRole.Text = userRole;
			ltUserID.Text = userId;
			ltEmail.Text = email;
			ltFistName.Text = first;
			ltLastName.Text = last;
			ltTargetURL.Text = targetURL;
			ltOrganizationName.Text = organizationName;
			ltOrganizationNumber.Text = organizationNumber;
			ltAddressLine1.Text = address1;
			ltAddressLine2.Text = address2;
			ltCity.Text = city;
			ltRegion.Text = region;
			ltCountry.Text = country;
			ltPostalCode.Text = postalCode;

			ltHashStatus.Text = hash.ToLower().Equals(v.ToLower()) ? "True" : "False";
			ltHash.Text = hash.ToLower().Equals(v.ToLower()) ? hash : hash + " != " + v;
            #endregion
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