using System;
using System.Reflection ;
using System.Diagnostics;

using System.Collections;

namespace CatNotes
{
	/// <summary>
	/// Summary description for ProductInfo.
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
	public class ProductInfo
	{
		//TODO : implement all these
		public const string CUSTOM_PROPERTY_COPYRIGHT_TEXT = "CopyRightText";
		public const string CUSTOM_PROPERTY_COMPANY_URL = "CompanyUrl";
		public const string CUSTOM_PROPERTY_EULA_URL = "EulaUrl";
		public const string CUSTOM_PROPERTY_PRODUCT_URL = "ProductUrl";						
		
		public static string ProductName
		{
			get
			{
				AssemblyProductAttribute productAttribute  = (AssemblyProductAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyProductAttribute));
				if (productAttribute != null)
					return productAttribute.Product;
				else
					return "";
			}
		}
		public static string FileVersion
		{
			get
			{
				AssemblyFileVersionAttribute fileVersionAttribute  = (AssemblyFileVersionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyFileVersionAttribute));
				if (fileVersionAttribute != null)
					return fileVersionAttribute.Version;
				else
					return "";			
			}
		}
		public static string FriendlyVersion
		{
			get
			{
				AssemblyInformationalVersionAttribute informationalVersionAttribute = (AssemblyInformationalVersionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyInformationalVersionAttribute));
				if (informationalVersionAttribute != null)
					return informationalVersionAttribute.InformationalVersion;
				else
					return "";			
			}
		}
		public static string ProductDescription
		{
			get
			{
				AssemblyDescriptionAttribute descriptionAttribute = (AssemblyDescriptionAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyDescriptionAttribute));
				if (descriptionAttribute != null)
					return descriptionAttribute.Description;
				else
					return "";			
			}
		}
		public static string CopyrightOwnerName
		{
			get
			{
				AssemblyCopyrightAttribute copyrightOwnerAttribute = (AssemblyCopyrightAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCopyrightAttribute));
				if (copyrightOwnerAttribute != null)
					return copyrightOwnerAttribute.Copyright;
				else
					return "";			
			}
		}
		public static string CopyrightText
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_COPYRIGHT_TEXT);
			}
		}
		public static string GetAssemblyCustomProperty(string propertyName)
		{
			AssemblyCustomPropertyAttribute[] customAttributes = (AssemblyCustomPropertyAttribute[]) AssemblyDescriptionAttribute.GetCustomAttributes(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCustomPropertyAttribute));
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
		public static string EulaUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_EULA_URL);
			}
		}
		public static string ProductHomepageUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_PRODUCT_URL);
			}
		}
		public static string CompanyName
		{
			get
			{
				AssemblyCompanyAttribute companyAttribute = (AssemblyCompanyAttribute) AssemblyDescriptionAttribute.GetCustomAttribute(System.Reflection.Assembly.GetExecutingAssembly(), typeof(AssemblyCompanyAttribute));
				if (companyAttribute != null)
					return companyAttribute.Company;
				else
					return "";			
			}

		}
		public static string CompanyUrl
		{
			get
			{
				return GetAssemblyCustomProperty(CUSTOM_PROPERTY_COMPANY_URL);
			}
		}
		public static void LaunchSysInfo()
		{
			Process.Start("msinfo32.exe");					
		}
		
	}
}