﻿using System;
using System.Linq.Expressions;
using System.Reflection;

namespace Data.Eval.Invocation.Expressions
{
	internal sealed class GetInstanceMemberValueExpression
	{
		public Func<object, object> GetFunc(
			Type instanceType,
			string memberName)
		{
			FieldInfo member = instanceType.GetField(memberName, BindingFlags.Public | BindingFlags.Instance);

			ParameterExpression instance = Expression.Parameter(typeof(object), "i");

			MemberExpression memberExp = Expression.Field(Expression.Convert(instance, instanceType), member);

			Expression<Func<object, object>> getter = Expression.Lambda<Func<object, object>>(Expression.Convert(memberExp, typeof(object)), instance);

			Func<object, object> func = getter.Compile();

			return func;
		}
	}
}
