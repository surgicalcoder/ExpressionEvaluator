using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Eval.CodeWriting
{
	internal sealed class CSharpCodeWriter
	{
		public string GetClassText(string expression, List<Variable> variables, List<string> usings, List<string> methods, bool withReturn)
		{
			string signature;

			signature = withReturn ? "public object Eval()" : "public void Eval()";

			return GetClassText(expression, variables, usings, methods, signature);
		}

		private string GetClassText(string expression, List<Variable> variables, List<string> usings, List<string> methods, string signature)
		{
			StringBuilder classText = new StringBuilder();

			classText.Append("using System;\r\n");

			// adding other standard namespaces for convenience
			classText.Append("using System.Linq;\r\n\r\n");

			if (usings.Count > 0)
			{
				foreach (var usingNamespace in usings)
				{
					classText.Append($"using {usingNamespace};\r\n");
				}

				classText.Append("\r\n");
			}

			classText.Append("public sealed class CustomEvaluator\r\n{\r\n");

			var wrappedClasses = new Dictionary<string, string>();

			if (variables is { Count: > 0 })
			{
				CSharpClassNameFormatter formatter = new CSharpClassNameFormatter();

				foreach (Variable variable in variables)
				{
					string variableType = formatter.GetFullName(variable.Type);

					classText.Append($"\tpublic {variableType} {variable.Name};\r\n");

					if (variable.Type.IsNotPublic && !wrappedClasses.ContainsKey(variableType))
					{
						wrappedClasses[variableType] = new InternalTypeAccessorWriter().GetClassTest(variable.Type, variableType);
					}
				}

				classText.Append("\t\r\n");
			}

			if (methods != null)
			{
				foreach (string method in methods)
				{
					classText.Append($"{method}\r\n");
				}
			}

			classText.Append($"\t{signature}\r\n\t{{\r\n");

			classText.Append($"\t\t{expression};\r\n");

			classText.Append("\t}\r\n}\r\n");

			if (wrappedClasses.Count > 0)
			{
				classText.Append("\r\n");
				classText.Append(InternalTypeAccessorWriter.GetDependencyClasses());

				foreach (string wrappedClassDefinition in wrappedClasses.Values)
				{
					classText.Append("\r\n");
					classText.Append(wrappedClassDefinition);
				}
			}

			return classText.ToString();
		}

		public struct Variable
		{
			public string Name;

			public Type Type;
		}
	}
}
