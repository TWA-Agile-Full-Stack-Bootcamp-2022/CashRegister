using System.Security;
using CashRegister;

namespace CashRegisterTest
{
    public class MockExceptionPrinter : IPrinter
    {
        public void Print(string content)
        {
            throw new PrinterOutOfPaperException();
        }
    }
}