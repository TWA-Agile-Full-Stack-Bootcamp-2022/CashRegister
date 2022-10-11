using System;

namespace CashRegister
{
    public class CashRegister
    {
        private readonly IPrinter printer;

        public CashRegister(IPrinter newPrinter)
        {
            this.printer = newPrinter;
        }

        public void Process(IPurchase purchase)
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