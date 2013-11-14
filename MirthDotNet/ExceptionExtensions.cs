using System;
using System.Reflection;
using System.Runtime.Serialization;

namespace MirthDotNet
{
    public static class ExceptionExtensions
    {
        private static MethodInfo preserveStackTrace = typeof(Exception).GetMethod("InternalPreserveStackTrace", BindingFlags.Instance | BindingFlags.NonPublic);

        /// <remarks>
        /// Pulled from http://stackoverflow.com/a/11284872/507
        /// </remarks>
        public static void PreserveStackTrace(this Exception e)
        {
            preserveStackTrace.Invoke(e, null);
        }
    }
}
