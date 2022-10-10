using System;

namespace CashRegister
{
	public class CashRegister
	{
		private readonly IPrinter printer;

		public CashRegister(IPrinter printer)
		{
			this.printer = printer;
		}

		public void Process(Purchase purchase)
		{
			try
			{
				printer.Print(purchase.AsString());
			}
			catch (PrinterOutOfPaperException e)
			{
				Console.WriteLine(e.Message);
				throw new HardwareException("Printer is out of paper.");
			}
		}
	}
}
