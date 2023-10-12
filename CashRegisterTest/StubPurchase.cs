using CashRegister;
using System;

namespace CashRegisterTest
{
    internal class StubPurchase : Purchase
    {
        private string purchaseInfo;

        public string PurchaseInfo { get => purchaseInfo; }

        public override string AsString()
        {
            return purchaseInfo;
        }

        public void WhenAsStringThenReturn(string givenPurchaseInfo)
        {
            this.purchaseInfo = givenPurchaseInfo;
        }
    }
}