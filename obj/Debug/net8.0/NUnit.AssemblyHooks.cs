// <auto-generated />
#pragma warning disable

using System.CodeDom.Compiler;
using System.Diagnostics;
using global::System.Runtime.CompilerServices;
using System.Threading.Tasks;

[GeneratedCode("Reqnroll", "2.4.1")]
[global::NUnit.Framework.SetUpFixture]
public static class ProjectTurnUp_NUnitAssemblyHooks
{
    [global::NUnit.Framework.OneTimeSetUp]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static async Task AssemblyInitializeAsync()
    {
        var currentAssembly = typeof(ProjectTurnUp_NUnitAssemblyHooks).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunStartAsync(currentAssembly);
    }

    [global::NUnit.Framework.OneTimeTearDown]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static async ValueTask AssemblyCleanupAsync()
    {
        var currentAssembly = typeof(ProjectTurnUp_NUnitAssemblyHooks).Assembly;
        await global::Reqnroll.TestRunnerManager.OnTestRunEndAsync(currentAssembly);
    }
}
#pragma warning restore
