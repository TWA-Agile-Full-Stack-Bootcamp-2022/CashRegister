namespace CashRegisterTest
{
	using CashRegister;
	using Xunit;

	public class CashRegisterTest
	{
		[Fact]
		public void Should_process_execute_printing()
		{
            //given
            var spyPrinter = new SpyPrinter();
            var cashRegister = new CashRegister(spyPrinter);
            var purchase = new Purchase();
			//when
            cashRegister.Process(purchase);
            //then
            //verify that cashRegister.process will trigger print
            Assert.Equal(1, spyPrinter.PrintMethodCalledCount);
		}

		[Fact]
		public void Should_pass_the_purchase_info_to_printer_by_given_Purchase_Object()
		{
            // given
            var spyPrinter = new SpyPrinter();
            var cashRegister = new CashRegister(spyPrinter);

            const string givenPurchaseInfo = "Some Given Purchase infomation";
            StubPurchase strubPurchase = new StubPurchase();
            strubPurchase.WhenAsStringThenReturn(givenPurchaseInfo);

            // when
            cashRegister.Process(strubPurchase);
            // then
            Assert.Equal(givenPurchaseInfo, spyPrinter.PrintContentRecived);
        }
    }
}
