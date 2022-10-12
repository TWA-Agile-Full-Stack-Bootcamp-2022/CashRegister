using System;

namespace CashRegister
{
	public class Printer : IPrinter
	{
		public string PrintContent { get; private set; }

		public void Print(string content)
		{
			this.PrintContent = content;
			// send message to a real printer
		}
	}
}
