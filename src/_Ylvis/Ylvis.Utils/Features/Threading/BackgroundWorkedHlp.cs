using System.ComponentModel;

namespace Ylvis.Utils.Helpers
{
    public static class BackgroundWorkerHlp
    {
        public static void Run(DoWorkEventHandler doWork,
                  RunWorkerCompletedEventHandler completed = null,
                  ProgressChangedEventHandler progressChanged = null)
        {
            using (var backgroundWorker = new BackgroundWorker())
            {
                backgroundWorker.DoWork += doWork;

                if (completed != null)
                    backgroundWorker.RunWorkerCompleted += completed;

                if (progressChanged != null)
                {
                    backgroundWorker.WorkerReportsProgress = true;
                    backgroundWorker.ProgressChanged += progressChanged;
                }
                backgroundWorker.RunWorkerAsync();
            }
        }

        //private void Example()
        //{
        //    BackgroundWorkerHlp.Run(
        //        (s, e) =>
        //        {
        //            var baskets = FoxDataAccess.GetOrderBaskets().Select(i =>
        //              new StaggedBlotterOrderBasketViewModel(i));
        //            var mainList = new ObservableCollection
        //              <StaggedBlotterOrderBasketViewModel>(baskets);
        //            e.Result = mainList;
        //        },
        //        (s, e) =>
        //        {
        //            Debug.Print(string.Format("Completed BackgroundWorker {0}",
        //              sw.ElapsedMilliseconds));
        //            _mainList = (ObservableCollection
        //              <StaggedBlotterOrderBasketViewModel>)e.Result;
        //            RaisePropertyChanged("MainListSource");
        //            Debug.Print(string.Format("Converted Basket Data {0}",
        //              sw.ElapsedMilliseconds));
        //            IsBusy = false;
        //        }
        //    );
        //}
    }
}
