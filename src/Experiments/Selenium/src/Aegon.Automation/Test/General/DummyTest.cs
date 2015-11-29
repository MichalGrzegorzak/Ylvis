using Aegon.Base;
using Aegon.Base.TestRunner;

namespace Aegon.Test.General
{
    [TestDescriptor(ID = DummyTestId, Description = "Dummy test, always successful")]
    internal class DummyTest : ITest
    {
        public const string DummyTestId = "DUMMY";
        public string ID { get { return DummyTestId; } }

        public void Initialize(TestRunnerEngine runner, WebBrowser webBrowser)
        { }

        public void Execute(WebBrowser webBrowser)
        { }

        public void FinalExecute(WebBrowser webBrowser)
        { }
    }
}
