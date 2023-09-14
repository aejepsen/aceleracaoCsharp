using System.Reflection;

static class UnitTestDetector
{

    private static bool _runningFromXUnit = false;      

    static UnitTestDetector()
    {
        foreach (Assembly assem in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assem.FullName.ToLowerInvariant().StartsWith("xunit"))
            {
                _runningFromXUnit = true;
                break;
            }
        }
    }

    public static bool IsRunningFromXUnit
    {
        get { return _runningFromXUnit; }
    }
}