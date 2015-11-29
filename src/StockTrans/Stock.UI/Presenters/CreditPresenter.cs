using System;
using Stock.Core.Domain;
using Stock.Core.Manager;
using Stock.Interfaces;

namespace Stock.Presenters
{
    public class CreditPresenter : BasePresenter<Credit>
    {
        public CreditPresenter(Credit model, ICreditView view) : base(model, view)
        {
            Initialize();
        }

        public CreditPresenter(Credit model, ICreditView view, IBasicManager<Credit> manager) : base(model, view)
        {
            _manager = manager;
            Initialize();
        }

        public void Initialize()
        {
            GetAll(this, null); //refresh grid on startup
        }
    }
}
