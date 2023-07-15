using System;
using Data.Eval.CodeWriting;
using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.CodeWriting
{
	[TestFixture]
	public class CSharpClassNameFormatterTests
	{
		[Test]
		public void CSharpClassNameFormatter_NullableInt()
		{
			var formatter = new CSharpClassNameFormatter();

			Type testType = typeof(int?);

			var className = formatter.GetFullName(
				testType);

			Assert.AreEqual(
				"System.Int32?",
				className);
		}
	}
}
