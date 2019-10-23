using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace RegExp {
	class Program {

		private static readonly string StartMessage =
@"
 Welcome to RegEx Console (v1.0)
 Aviable commands:
 :regex <pattern> - set current regex pattern
 :reset - reset current regex pattern
 :clear - clear console
";



		static void Main(string[] args) {
			Regex pattern = null;

			WriteLine(StartMessage);

			while(true) {
				Write(" > ");
				string line = ReadLine();
				if(line.StartsWith(":")) {
					string[] command = line.Substring(1).Split(' ');
					switch(command[0].ToLower()) {
						case "regex":
							if(command.Length < 2) {
								WriteColoredLine(" :regex <pattern> - set current regex pattern", ConsoleColor.Red);
								break;
							}
							pattern = new Regex(command[1]);
							WriteColored(" Pattern changed! Current pattern:          ", ConsoleColor.Green);
							WriteColored(command[1], ConsoleColor.DarkYellow);
							WriteLine();
							break;

						case "reset":
							pattern = null;
							WriteColoredLine(" Pattern removed!", ConsoleColor.Green);
							break;

						case "clear":
							Clear();
							WriteLine(StartMessage);
							break;
					}
				} else {
					if(pattern != null) {
						bool match = pattern.IsMatch(line);
						WriteColoredLine(match ? " Yes!" : " No!", match ? ConsoleColor.Green : ConsoleColor.Red);
					}
				}
			}			
		}


		public static void WriteColoredLine(String text, ConsoleColor color) {
			ConsoleColor old = ForegroundColor;
			ForegroundColor = color;
			Console.WriteLine(text);
			ForegroundColor = old;
		}

		public static void WriteColored(String text, ConsoleColor color) {
			ConsoleColor old = ForegroundColor;
			ForegroundColor = color;
			Console.Write(text);
			ForegroundColor = old;
		}

	}
}
