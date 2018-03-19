
namespace Aegon.Base.TestRunner
{
    internal interface ITest
    {
        string ID { get; }
        void Initialize(TestRunnerEngine runner, WebBrowser webBrowser);
        void Execute(WebBrowser webBrowser);
        void FinalExecute(WebBrowser webBrowser);
    }
}
