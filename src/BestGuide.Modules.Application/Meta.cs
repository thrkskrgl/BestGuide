using System.Reflection;

namespace BestGuide.Modules.Application
{
    public static class Meta
    {
        public static Assembly Assembly => typeof(Meta).Assembly;
    }
}
