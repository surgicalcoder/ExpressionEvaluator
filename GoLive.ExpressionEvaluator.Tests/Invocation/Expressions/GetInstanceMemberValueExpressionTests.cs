using Data.Eval.Invocation.Expressions;
using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.Invocation.Expressions
{
	[TestFixture]
	public class GetInstanceMemberValueExpressionTests
	{
		[Test]
		public void GetInstanceMemberValueExpression_Int()
		{
			var example = new ExampleClass
			{
				IntValue = 3
			};

			var func = new GetInstanceMemberValueExpression()
				.GetFunc(
					typeof(ExampleClass),
					"IntValue");

			int testValue = (int)func(example);

			Assert.AreEqual(3, testValue);
		}

		public class ExampleClass
		{
			public int IntValue;
		}
	}
}
