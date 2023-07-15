using Data.Eval.Invocation.Expressions;
using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.Invocation.Expressions
{
	[TestFixture]
	public class DefaultClassConstructorExpressionTests
	{
		[Test]
		public void DefaultClassConstructorExpression_NoConstructor()
		{
			var func = new DefaultClassConstructorExpression()
				.GetFunc(
					typeof(ExampleClass));

			ExampleClass testObj = (ExampleClass)func();

			Assert.IsNotNull(testObj);
		}

		public class ExampleClass
		{
			
		}
	}
}
