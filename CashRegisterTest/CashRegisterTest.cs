using System;
using Moq;

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
			Mock<IPrinter> printerMock = new Mock<IPrinter>();
			printerMock.Setup(p => p.Print(It.IsAny<string>()));
			var cashRegister = new CashRegister(printerMock.Object);
			var purchase = new Purchase();
			//when
			cashRegister.Process(purchase);
			//then
			printerMock.Verify(p => p.Print(
				It.Is<string>(s => s.StartsWith("content"))), Times.Once());
			//verify that cashRegister.process will trigger print
		}
	}
}
