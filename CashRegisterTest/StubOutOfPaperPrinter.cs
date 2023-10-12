using CashRegister;

namespace CashRegisterTest
{
    internal class StubOutOfPaperPrinter : Printer
    {
        public override void Print(string content)
        {
            throw new PrinterOutOfPaperException();
        }
    }
}