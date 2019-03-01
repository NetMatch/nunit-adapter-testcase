using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Testcase.Tests
{
	/*
	 * REPRODUCTIONS:
	 *
	 * IMPORTANT!!
	 *   For the #2 scenario below, start from a blank VS Test Explorer!
	 *   Test case names seem to be held onto from the #1 scenario and
	 *   are correctly reported as having run in such a case.
	 *   They are not, when starting blank.
	 *
	 *   1. Choose 'Run All' from the VS Test Explorer to run all tests
	 *      -> OK  : All custom-named test cases show up as having run.
	 *      -> BUG : Original test method names remain present as not run.
	 *
	 *   2. Right-click the 'Tests' node from the VS Test Explorer and
	 *      choose to run *only* the tests inside that test fixture.
	 *      -> BUG : None of the test cases show up as having run.
	 *               The tests log output mentions a warning:
	 *               "No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Concat|FullyQualifiedName=Testcase.Tests.Tests.Add`"
	 *      -> BUG : Original test method names remain present as not run.
	 *
	 *   3. Right-click the 'Add' node from the VS Test Explorer and
	 *      choose to run only that test.
	 *      -> BUG : None of the Add test cases show up as having run.
	 *               The tests log output mentions a warning:
	 *               "No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Add`"
	 *      -> BUG : Original test method names remain present as not run.
	 *
	 *   4. Right-click the 'Concat' node from the VS Test Explorer and
	 *      choose to run only that test.
	 *      -> BUG : None of the Concat test cases show up as having run.
	 *               The tests log output mentions a warning:
	 *               "No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Concat`"
	 *      -> BUG : Original test method names remain present as not run.
	 */

	[TestFixture]
	public class Tests
	{
		public static IEnumerable<TestCaseData> AddCases
		{
			get
			{
				return Enumerate().Select(testCase => testCase
					.SetName($"{{m}}{{a}} : {testCase.ExpectedResult}")
				);

				IEnumerable<TestCaseData> Enumerate()
				{
					yield return new TestCaseData(1,1).Returns(2);
					yield return new TestCaseData(1,2).Returns(3);
					yield return new TestCaseData(1,3).Returns(4);
				}
			}
		}

		public static IEnumerable<TestCaseData> ConcatCases
		{
			get
			{
				return Enumerate().Select(testCase => testCase
					.SetName($"{{m}}{{a}} : \"{testCase.ExpectedResult}\"")
				);

				IEnumerable<TestCaseData> Enumerate()
				{
					yield return new TestCaseData("a", "b").Returns("ab");
					yield return new TestCaseData("a", "c").Returns("ac");
					yield return new TestCaseData("a", "d").Returns("ad");
				}
			}
		}

		[TestCaseSource("AddCases")]
		public int Add(int a, int b)
		{
			return a + b;
		}

		[TestCaseSource("ConcatCases")]
		public string Concat(string a, string b)
		{
			return a + b;
		}
	}
}