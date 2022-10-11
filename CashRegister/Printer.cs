using System;

namespace CashRegister
{
    public class Printer : IPrinter
    {
        private string needPrintContent;

        public Printer() => needPrintContent = null;

        public void Print(string content)
        {
            this.needPrintContent = content;
            // send message to a real printer
            Console.WriteLine(this.needPrintContent);
        }

        public string GetNeedPrintContent()
        {
            return this.needPrintContent;
        }
    }
}