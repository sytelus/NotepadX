//using System;
//
////TODO: Use this class instead of hard coding string setting names and categories
//
//namespace Sytel.NotepadX
//{
//	/// <summary>
//	/// Summary description for NotepadXAppSettings.
//	/// </summary>
//	public class NotepadXAppSettings
//	{
//		private static NotepadXApplicationSettings m_NotepadXApplicationSettings;
//
//		static NotepadXAppSettings()
//		{
//			m_NotepadXApplicationSettings = new NotepadXApplicationSettings(true);
//		}
//		
//		public static void Save()
//		{
//			m_NotepadXApplicationSettings.Save();
//		}
//
//		public static bool AutoSaveOnExit
//		{
//			get
//			{
//				return bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "AutoSave On Exit", false.ToString()).ToLower());		
//			}
//		}
//
//		public static bool RememberWindowLayout
//		{
//			get
//			{
//				return bool.Parse(m_NotepadXApplicationSettings.GetSetting("Preferences", "Remember Window Size", true.ToString()));
//			}
//		}
//		
//		public static int GetWindowWidth(int defaultValue)
//		{
//			return int.Parse (m_NotepadXApplicationSettings.GetSetting ("Last Values", "Window Width", defaultValue.ToString()));
//		}
//		
//		
//		public static string CurrentConfigurationSet
//		{
//			get
//			{
//				return m_NotepadXApplicationSettings.CurrentConfigurationSet;
//			}
//			set
//			{
//				m_NotepadXApplicationSettings.CurrentConfigurationSet = value;
//			}
//		}
//		
//	}
//}
