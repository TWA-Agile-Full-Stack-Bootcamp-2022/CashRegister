using CashRegister;

namespace CashRegisterTest
{
    public class MockOutOfPaperPrinter : IPrinter
    {
        public void Print(string content)
        {
            throw new PrinterOutOfPaperException();
        }
    }
}