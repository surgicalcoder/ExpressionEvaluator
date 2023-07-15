using NUnit.Framework;

namespace GoLive.ExpressionEvaluator.Tests.Reflection
{
	[TestFixture]
	public class ReflectionTests
	{
		[Test]
		public void Reflection_AnonymousTypeAccessor()
		{
			var test = new
			{
				prop = "something"
			};

			var accessor = new AnonymousTypeAccessor1(test);

			Assert.AreEqual("something", accessor.prop);
		}
	}
}
