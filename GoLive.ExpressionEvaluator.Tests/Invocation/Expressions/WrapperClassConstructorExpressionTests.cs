using System;
using Data.Eval.Invocation.Expressions;
using GoLive.ExpressionEvaluator.Tests.Reflection;
using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.Invocation.Expressions
{
	[TestFixture]
	public class WrapperClassConstructorExpressionTests
	{
		[Test]
		public void WrapperClassConstructor_SimpleTest()
		{
			var test = new
			{
				prop = "something"
			};

			WrapperClassConstructorExpression constructorCreator = new WrapperClassConstructorExpression();

			Func<object, object> constructor = constructorCreator.GetFunc(typeof(AnonymousTypeAccessor1));

			AnonymousTypeAccessor1 wrapper = (AnonymousTypeAccessor1)constructor(test);

			Assert.AreEqual("something", wrapper.prop);
		}
	}
}
