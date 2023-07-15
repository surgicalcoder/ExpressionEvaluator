using Data.Eval.Invocation.Expressions;
using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.Invocation.Expressions
{
	[TestFixture]
	public class ExecuteInstanceMethodExpressionTests
	{
		[Test]
		public void ExecuteInstanceMethodExpression_NoArgumentsReturnInt()
		{
			var example = new ExampleClass();

			var func = new ExecuteInstanceMethodExpression()
				.GetFuncWithReturn(
					typeof(ExampleClass),
					"GetIntValue");

			int testValue = (int)func(
				example, 
				new object[] { });

			Assert.AreEqual(3, testValue);
		}

		public class ExampleClass
		{
			public int GetIntValue()
			{
				return 3;
			}
		}
	}
}
