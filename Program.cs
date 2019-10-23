using System;
using System.Text.RegularExpressions;
using static System.Console;

namespace RegExp {
	class Program {

		private static readonly string StartMessage =
@" Welcome to RegEx Console
 Aviable commands:
 :regex <pattern> - set current regex pattern
 :reset - reset current regex pattern
 :clear - clear console
";



		static void Main(string[] args) {
			Regex pattern;

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
							WriteColoredLine(" Pattern changed!", ConsoleColor.Green);
							break;

						case "reset":
							pattern = null;
							WriteColoredLine(" Pattern removed!", ConsoleColor.Green);
							break;
					}
				}



				/*

				Console.Write("Enter Regex pattern: ");
				pattern = Console.ReadLine();
				Console.WriteLine();

				Regex r = new Regex(pattern);

				while(true) {
					Console.Write("Enter string: ");
					string line = Console.ReadLine();
					if(line.ToLower().Equals(":stop")) {
						Console.WriteLine();
						break;
					} else if(line.ToLower().Equals(":clear")) {
						Console.Clear();
						continue;
					}

					bool match = r.IsMatch(line);
					Console.WriteLine(match);
				}*/
			}			
		}


		public static void WriteColoredLine(String text, ConsoleColor color) {
			ConsoleColor old = ForegroundColor;
			ForegroundColor = color;
			Console.WriteLine(text);
			ForegroundColor = old;
		}
		
	}
}
