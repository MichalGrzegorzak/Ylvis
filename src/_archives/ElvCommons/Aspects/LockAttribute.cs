using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using PostSharp.Laos;

namespace Core.Aspects
{
    [Serializable]
    public class ReadOperationAttribute : PostSharp.Laos.OnMethodInvocationAspect
    {
        public override void OnInvocation(MethodInvocationEventArgs eventArgs)
        {
            ReaderWriterLock rwLock = null; // GetLock(); - get the right lock
            rwLock.AcquireReaderLock(10000);
            try { eventArgs.Proceed(); }
            finally { rwLock.ReleaseReaderLock(); }
        }
    }

    public class Foo
    {
        [ReadOperation]
        public string Bar
        {

            get { return "stuff"; }
            set { Console.WriteLine(value); }
        }

        [ReadOperation]
        public void Test(string input)
        {
            Console.WriteLine(input);
        }
    }
    

}
