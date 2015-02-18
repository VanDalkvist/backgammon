using System;

using Backgammon.Core.Errors;

namespace Backgammon.Logic.Verification
{
    public class FieldVerificator
	{
		private event VerificationHelper Verify;

		public ErrorProvider ErrorProvider { get; private set; }

		public FieldVerificator()
		{
			Verify = VerifyAllCountersInHome;

			ErrorProvider = new ErrorProvider();
		}

		public bool OnVerify(VerificatedArgs args)
		{
			Verify(args);
			var result = ErrorProvider.Error == string.Empty;
			ErrorProvider.Reset();
			return result;
		}

		private void VerifyAllCountersInHome(VerificatedArgs args)
		{
			throw new NotImplementedException();
		}
	}
}