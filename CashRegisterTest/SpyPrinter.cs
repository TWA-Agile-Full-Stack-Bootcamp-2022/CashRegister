using System;
using System.Collections.Generic;
using System.Text;

namespace CashRegister
{
    internal class SpyPrinter : Printer
    {
        private int printMethodCalledCount;

        public int PrintMethodCalledCount
        {
            get { return printMethodCalledCount; }
        }

        public override void Print(string content)
        {
            this.printMethodCalledCount++;
        }
    }
}
