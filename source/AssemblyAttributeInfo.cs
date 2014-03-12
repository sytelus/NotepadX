using System;
using System.Reflection ;
using System.Diagnostics;

using System.Collections;
using System.IO;
using Sytel.AssemblyCustomProperty;

namespace Sytel.AssemblyCustomProperty
{
	/// <summary>
	/// Summary description for AssemblyCustomAttribute.
	/// </summary>
	[AttributeUsage (AttributeTargets.Assembly, AllowMultiple=true)] 	
	public sealed class AssemblyCustomPropertyAttribute : Attribute
	{
		string m_propertyName;
		string m_propertyValue;
		public AssemblyCustomPropertyAttribute(string propertyName, string propertyValue)
		{
			m_propertyName = propertyName;
			m_propertyValue = propertyValue;
		}
		public string PropertyName
		{
			get
			{
				return m_propertyName;
			}
		}
		public string PropertyValue
		{
			get
			{
				return m_propertyValue;
			}
		}
	}

	/// <summary>
	/// Summary description for ProductInfo.
	/// </summary>
	public class AssemblyAttributeInfo
	{
		//TODO : implement all these
		public const string CUSTOM_PROPERTY_HELP_FILE_NAME = "HelpFileName";
		public const string CUSTOM_PROPERTY_SOURCECODE_CREDITS = "SourceCodeCredits";
		public const string CUSTOM_PROPERTY_COPYRIGHT_TEXT = "CopyRightText";
		public const string CUSTOM_PROPERTY_COMPANY_URL = "CompanyUrl";
		public const string CUSTOM_PROPERTY_EULA_URL = "EulaUrl";
		public const string CUSTOM_PROPERTY_PRODUCT_URL = "ProductUrl";						
		public const string CUSTOM_PROPERTY_SEND_COMMENTS_URL = "SendCommentsUrl";						
		public const string CUSTOM_PROPERTY_CHECK_PRODUCT_UPDATES_URL = "CheckProductUpdatesUrl";						

		public Assembly AssemblyToUse = null;
		
		public AssemblyAttributeInfo(Assembly assemblyToUse)
		{
			AssemblyToUse = assemblyToUse;
		}

		public AssemblyAttributeInfo()
		{
			AssemblyToUse = Assembly.GetExecutingAssembly();
		}
		
		public string ProductName
		{
			get
			{
				AssemblyProductAttribute productAttribute  = (AssemblyProductAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyProductAttribute));
				if (productAttribute != null)
					return productAttribute.Product;
				else
					return "";
			}
		}
		public string ProductTitle
		{
			get
			{
				AssemblyTitleAttribute titleAttribute  = (AssemblyTitleAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyTitleAttribute));
				if (titleAttribute != null)
					return titleAttribute.Title;
				else
					return "";
			}
		}
		public string BuildVersion
		{
			get
			{
				return AssemblyToUse.GetName().Version.ToString();
				/*
				AssemblyVersionAttribute versionAttribute  = (AssemblyVersionAttribute) AssemblyVersionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyVersionAttribute));
				if (versionAttribute != null)
					return versionAttribute.Version;
				else
					return "";			
				*/
			}
		}
		public string FileVersion
		{
			get
			{
				AssemblyFileVersionAttribute fileVersionAttribute  = (AssemblyFileVersionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyFileVersionAttribute));
				if (fileVersionAttribute != null)
					return fileVersionAttribute.Version;
				else
					return "";			
			}
		}
		public string FriendlyVersion
		{
			get
			{
				AssemblyInformationalVersionAttribute informationalVersionAttribute = (AssemblyInformationalVersionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyInformationalVersionAttribute));
				if (informationalVersionAttribute != null)
					return informationalVersionAttribute.InformationalVersion;
				else
					return "";			
			}
		}
		public string ProductDescription
		{
			get
			{
				AssemblyDescriptionAttribute descriptionAttribute = (AssemblyDescriptionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyDescriptionAttribute));
				if (descriptionAttribute != null)
					return descriptionAttribute.Description;
				else
					return "";			
			}
		}
		public string CopyrightOwnerName
		{
			get
			{
				AssemblyCopyrightAttribute copyrightOwnerAttribute = (AssemblyCopyrightAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyCopyrightAttribute));
				if (copyrightOwnerAttribute != null)
					return copyrightOwnerAttribute.Copyright;
				else
					return "";			
			}
		}
		public string CopyrightText
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_COPYRIGHT_TEXT);
			}
		}
		public string SourceCodeCredits
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_SOURCECODE_CREDITS);
			}
		}
		public string HelpFileName
		{
			get
			{
				string helpFileNamePart = GetAssemblyCustomProperty(CUSTOM_PROPERTY_HELP_FILE_NAME);
				return Path.Combine(Path.GetDirectoryName(AssemblyToUse.Location), helpFileNamePart);
			}
		}
		public string GetAssemblyCustomProperty(string propertyName)
		{
			AssemblyCustomPropertyAttribute[] customAttributes = (AssemblyCustomPropertyAttribute[]) AssemblyDescriptionAttribute.GetCustomAttributes(AssemblyToUse, typeof(AssemblyCustomPropertyAttribute));
			string customAttributeValue = "";
			if (customAttributes != null)
			{
				foreach (AssemblyCustomPropertyAttribute customAttribute in customAttributes)
				{
					if (String.Compare(customAttribute.PropertyName, propertyName, true) == 0)
					{
						customAttributeValue = customAttribute.PropertyValue;
						break;
					}
				}
			}
			else
				customAttributeValue = "";
			return customAttributeValue;
		}
		public string EulaUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_EULA_URL);
			}
		}
		public string ProductHomepageUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_PRODUCT_URL);
			}
		}
		public string SendCommentsUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_SEND_COMMENTS_URL);
			}
		}
		public string CheckProductUpdatesUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_CHECK_PRODUCT_UPDATES_URL);
			}
		}
		public string CompanyName
		{
			get
			{
				AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(AssemblyToUse, typeof(AssemblyCompanyAttribute));
				if (companyAttribute != null)
					return companyAttribute.Company;
				else
					return "";			
			}

		}
		public string CompanyUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_COMPANY_URL);
			}
		}
	}
}