namespace Sytel.NotepadX
{
	public class NoteFormat
	{
		public enum NoteFormatEnum
		{
			//must match same letters as in string constants!
			//This enum is created for PropertyGrid
			Text, RTF, HTML, Worksheet, Hierarchy
		}

		public static string NoteFormatEnumToString(NoteFormatEnum noteFormatEnumToConvert)
		{
			string stringValueForEnum;
			switch(noteFormatEnumToConvert)
			{
				case NoteFormatEnum.Hierarchy:
					stringValueForEnum = FORMAT_HIERARCHY;
					break;
				case NoteFormatEnum.HTML :
					stringValueForEnum = FORMAT_HTML;
					break;
				case NoteFormatEnum.RTF :
					stringValueForEnum = FORMAT_RTF;
					break;
				case NoteFormatEnum.Text :
					stringValueForEnum = FORMAT_TEXT;
					break;
				case NoteFormatEnum.Worksheet:
					stringValueForEnum = FORMAT_WORKSHEET;
					break;
				default:
					throw new System.ArgumentOutOfRangeException("noteFormatEnumToConvert", noteFormatEnumToConvert, "Can not convert enum value to string because this value is not recognized");
					break;
			}
			return stringValueForEnum;
		}
		public static NoteFormatEnum StringToNoteFormatEnum(string stringToConvert)
		{
			NoteFormatEnum enumValueForString;
			switch(stringToConvert)
			{
				case FORMAT_HIERARCHY:
					enumValueForString = NoteFormatEnum.Hierarchy;
					break;
				case FORMAT_HTML:
					enumValueForString = NoteFormatEnum.HTML ;
					break;
				case FORMAT_RTF:
					enumValueForString = NoteFormatEnum.RTF ;
					break;
				case FORMAT_TEXT:
					enumValueForString = NoteFormatEnum.Text ;
					break;
				case FORMAT_WORKSHEET:
					enumValueForString = NoteFormatEnum.Worksheet;
					break;
				default:
					throw new System.ArgumentOutOfRangeException("stringToConvert", stringToConvert, "Can not convert string value to enum because this value is not recognized");
					break;
			}
			return enumValueForString;
		}
		
		
		public const string FORMAT_DEFAULT = "rtf";
		public const string FORMAT_TEXT = "text";
		public const string FORMAT_RTF = "rtf";
		public const string FORMAT_HTML = "html";
		public const string FORMAT_WORKSHEET = "worksheet";
		public const string FORMAT_HIERARCHY = "hierarchy";
		
		public static string GetFriendlyNameForFormat(string formatConstValue)
		{
			return formatConstValue;	//TODO : Put big Swicth here to return friendly name
		}
	}
		
	public interface INoteEditor
	{
		string GetNoteContent();
		void SetNoteContent(string noteID, string noteCaption, string noteContent);
		bool IsReadOnly {get;set;}
		bool IsModified {get;}
		bool IsVisible {get;set;}
		void ResetAll();
		void ClearContent();
		string CurrentFormat {get;set;}
		string EditorUserFriendlyName {get;}
		string EditorName{get;}
		string CurrentNoteCaption {get;set;}
		string CurrentNoteID {get;set;}
	}
}