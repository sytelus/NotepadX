/*
* Arguments class: application arguments interpreter
*
* Authors:		R. LOPES
* Contributors:	R. LOPES, Shital Shah
* Created:		25 October 2002
* Modified:		28 October 2002
*
* Version:		1.0
*/

using System;
using System.Collections.Specialized;
using System.Text.RegularExpressions;

namespace Sytel
{
	/// <summary>
	/// Arguments class
	/// </summary>
	public class CommandLineParser
	{
		// Variables
		public readonly StringDictionary CommandLineOptions = null;

		// Constructor
		public CommandLineParser(string[] Args)
		{
			ParseCommandLine(Args, new string[]{});
		}
		public CommandLineParser(string[] Args, string[] positionalParameterNames)
		{
			CommandLineOptions=ParseCommandLine(Args, positionalParameterNames);
		}
				
		private StringDictionary ParseCommandLine(string[] Args, string[] positionalParameterNames)
		{
			int nextPositionalParameterNameIndex = 0;
			
			StringDictionary parsedCommandLine=new StringDictionary();
			Regex Spliter=new Regex(@"^-{1,2}|^/",RegexOptions.IgnoreCase|RegexOptions.Compiled);
			Regex Remover= new Regex(@"^['""]?(.*?)['""]?$",RegexOptions.IgnoreCase|RegexOptions.Compiled);
			string Parameter=null;
			string[] Parts;

			// Valid parameters forms:
			// {-,/,--}param{ ,=,:}((",')value(",'))
			// Examples: -param1 value1 --param2 /param3:"Test-:-work" /param4=happy -param5 '--=nice=--'
			foreach(string Txt in Args)
			{
				// Look for new parameters (-,/ or --) and a possible enclosed value (=,:)
				Parts=Spliter.Split(Txt,3);
				switch(Parts.Length)
				{
						// Found a value (for the last parameter found (space separator))
					case 1:
						if(Parameter!=null)
						{
							if(!parsedCommandLine.ContainsKey(Parameter.ToLower()))
							{
								Parts[0]=Remover.Replace(Parts[0],"$1");
								parsedCommandLine.Add(Parameter.ToLower(),Parts[0]);
							}
							Parameter=null;
						}
						else
						{
							string parameterName;
							//Positional parameter names
							if (nextPositionalParameterNameIndex < positionalParameterNames.Length)
							{
								parameterName = positionalParameterNames[nextPositionalParameterNameIndex];
							}
							else parameterName = "_poistional_param_" + nextPositionalParameterNameIndex.ToString();
							nextPositionalParameterNameIndex+=1;
							
							parsedCommandLine.Add(parameterName.ToLower(), Parts[0]);
						}
						
						break;
						// Found just a parameter
					case 2:
						// The last parameter is still waiting. With no value, set it to true.
						if(Parameter!=null)
						{
							if(!parsedCommandLine.ContainsKey(Parameter.ToLower())) parsedCommandLine.Add(Parameter.ToLower(),"true");
						}
						else
						{
							string parameterName;
							//Positional parameter names
							if (nextPositionalParameterNameIndex < positionalParameterNames.Length)
							{
								parameterName = positionalParameterNames[nextPositionalParameterNameIndex];
							}
							else parameterName = "_poistional_param_" + nextPositionalParameterNameIndex.ToString();
							nextPositionalParameterNameIndex+=1;
							
							parsedCommandLine.Add(parameterName.ToLower(), Parts[0]);
						}
						Parameter=Parts[1];
						break;
						// Parameter with enclosed value
					case 3:
						// The last parameter is still waiting. With no value, set it to true.
						if(Parameter!=null)
						{
							if(!parsedCommandLine.ContainsKey(Parameter.ToLower())) parsedCommandLine.Add(Parameter.ToLower(),"true");
						}
						Parameter=Parts[1];
						// Remove possible enclosing characters (",')
						if(!parsedCommandLine.ContainsKey(Parameter.ToLower()))
						{
							Parts[2]=Remover.Replace(Parts[2],"$1");
							parsedCommandLine.Add(Parameter.ToLower(),Parts[2]);
						}
						Parameter=null;
						break;
				}
			}
			// In case a parameter is still waiting
			if(Parameter!=null)
			{
				if(!parsedCommandLine.ContainsKey(Parameter.ToLower())) 
					parsedCommandLine.Add(Parameter.ToLower(),"true");
			}
			
			return parsedCommandLine;
		}

	}
}
