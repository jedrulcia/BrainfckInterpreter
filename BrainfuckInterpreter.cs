using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrainfckInterpreter
{
	public class BrainfuckInterpreter
	{
		public int[] Memory { get; private set; }
		public int Pointer { get; private set; }

		public BrainfuckInterpreter()
		{
			Memory = new int[30000];
			Pointer = 0;
		}

		public void Execute(char command)
		{
			switch (command)
			{
				case '>': Pointer = (Pointer + 1) % Memory.Length; break;
				case '<': Pointer = (Pointer - 1 + Memory.Length) % Memory.Length; break;
				case '+': Memory[Pointer]++; break;
				case '-': Memory[Pointer]--; break;
				case '.': Console.Write((char)Memory[Pointer]); break;
				case ',': break;
				default: break;
			}
		}

		public void Run(string code)
		{
			foreach (char command in code)
			{
				Execute(command);
			}
		}
	}
}
