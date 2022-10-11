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
			var newPrinter = new Printer();
			var cashRegister = new CashRegister(newPrinter);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			//verify that cashRegister.process will trigger print
			Assert.NotNull(newPrinter.GetNeedPrintContent());
		}
	}
}
