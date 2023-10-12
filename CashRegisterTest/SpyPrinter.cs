using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    internal class SpyPrinter : Printer
    {
        private int printMethodCalledCount;
        private string printContentRecived;

        public int PrintMethodCalledCount
        {
            get { return printMethodCalledCount; }
        }

        public string PrintContentRecived { get => printContentRecived; }

        public override void Print(string content)
        {
            this.printMethodCalledCount++;
            this.printContentRecived = content;
        }
    }
}
