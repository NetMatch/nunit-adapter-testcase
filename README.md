# nunit-adapter-testcase
This repository illustrates a problem with reporting NUnit test cases in VS Test Explorer when
using custom case names, reported in [nunit3-vs-adapter/#607](https://github.com/nunit/nunit3-vs-adapter/issues/607)

## bug reproductions

**IMPORTANT!!**  
For the #2 scenario below, start from a blank VS Test Explorer! Test case names seem to be held onto from the #1 scenario and
are correctly reported as having run in such a case. They are not, when starting blank.
	 
1. Choose 'Run All' from the VS Test Explorer to run all tests
   * OK  : All custom-named test cases show up as having run.
   * BUG : Original test method names remain present as not run.

2. Right-click the 'Tests' node from the VS Test Explorer and choose to run *only* the tests inside that test fixture.
   * BUG : None of the test cases show up as having run.  
           The VS Output panel mentions a warning in the Tests category:  
           ``No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Concat|FullyQualifiedName=Testcase.Tests.Tests.Add` ``
   * BUG : Original test method names remain present as not run.

3. Right-click the 'Add' node from the VS Test Explorer and choose to run only that test.
	 * BUG : None of the Add test cases show up as having run.  
           The VS Output panel mentions a warning in the Tests category:  
           ``No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Add` ``
	 * BUG : Original test method names remain present as not run.
	 
4. Right-click the 'Concat' node from the VS Test Explorer and choose to run only that test.
	 * BUG : None of the Concat test cases show up as having run.  
           The VS Output panel mentions a warning in the Tests category:  
           ``No test matches the given testcase filter `FullyQualifiedName=Testcase.Tests.Tests.Concat` ``
	 * BUG : Original test method names remain present as not run.
