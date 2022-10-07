using System;

namespace CashRegister
{
	public class HardwareException : Exception
	{
		public HardwareException(string message) : base(message)
		{
		}
	}
}