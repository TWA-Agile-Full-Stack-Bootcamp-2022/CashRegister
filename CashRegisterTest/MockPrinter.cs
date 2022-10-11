using CashRegister;

namespace CashRegisterTest
{
    public class MockPrinter : IPrinter
    {
        private string content;

        public void Print(string info)
        {
            this.content = info;
        }

        public string GetPrintContent()
        {
            return this.content;
        }
    }
}