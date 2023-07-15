using System;

namespace Data.Eval.Invocation.Expressions
{
	internal sealed class CastExpression<T>
	{
		public Func<object, T> GetFunc()
		{
			Func<object, T> func = (obj) => (T)Convert.ChangeType(obj, typeof(T));
			return func;
		}
	}
}
