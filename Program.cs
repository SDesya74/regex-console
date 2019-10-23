using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegExp {
	class Program {

		private static readonly string StartMessage = 
@"Welcome to RegEx Console
Aviable commands:
:stop - stops current regex testing
:clear - clear console
";



		static void Main(string[] args) {
			while(true) {
				string pattern;

				Console.Write("Enter Regex pattern: ");
				pattern = Console.ReadLine();
				Console.WriteLine();

				Regex r = new Regex(pattern);

				while(true) {
					Console.Write("Enter string: ");
					string line = Console.ReadLine();
					if(line.ToLower().Equals(":stop")){
						Console.WriteLine();
						break;
					}else if(line.ToLower().Equals(":clear")) {
						Console.Clear();
						continue;
					}

					bool match = r.IsMatch(line);
					Console.WriteLine(match);
				}
			}
		}
	}
}
