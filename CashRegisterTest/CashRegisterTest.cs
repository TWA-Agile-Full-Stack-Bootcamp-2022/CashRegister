namespace CashRegisterTest
{
	using CashRegister;
	using System;
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

		[Fact]
		public void Should_throw_HardwareException_given_printer_is_out_of_paper()
        {
            //given
            var stubOutOfPaperPrinter = new StubOutOfPaperPrinter();
            var cashRegister = new CashRegister(stubOutOfPaperPrinter);
            var purchase = new Purchase();
            //when
            Action action = () => cashRegister.Process(purchase);
            //then
            Exception exception = Assert.Throws<HardwareException>(action);
            Assert.Equal("Printer is out of paper.", exception.Message);
        }
    }
}
