using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using Stock.Core.Domain;
using Stock.Core.Manager;
using Stock.Interfaces;

namespace Stock.Presenters
{
    public abstract class BasePresenter<T> where T : DomainObject<Int32>
    {
        public BasePresenter(T item, IBasicView<T> view)
        {
            _item = item;
            _view = view;

            //should be injected somehow
            _manager = ManagerFactory<T>.Create(); //creates manager class

            SetViewPropertiesFromModel();
            WireUpViewEvents();
        }

        protected T _item = null;
        protected IBasicView<T> _view;
        public IBasicManager<T> _manager = null;

        protected virtual void WireUpViewEvents()
        {
            _view.ItemsListChanged += GetAll;
            _view.ItemChanged += ItemChanged;
            _view.AddItem += Add;
            _view.GetItem += Get;
        }

        public virtual void Add(object sender, EventArgs e)
        {
            SetModelPropertiesFromView();
            _manager.Add(_item);
            
            GetAll(sender, e);
        }

        public virtual void Get(object sender, EventArgs e)
        {
            SetModelPropertiesFromView();
            _item = _manager.GetItem(_item.ID);
        }

        public virtual void GetAll(object sender, EventArgs e)
        {
            _view.ItemsList = _manager.GetAll();
        }

        public virtual void ItemChanged(object sender, EventArgs e)
        {
            SetModelPropertiesFromView();
        }

        #region Auto binding view to model & back 
        protected void SetViewPropertiesFromModel()
        {
            foreach (PropertyInfo viewProperty in _view.GetType().GetProperties())
            {
                if (!viewProperty.CanWrite)
                    continue;

                PropertyInfo modelProperty = _item.GetType().GetProperty(viewProperty.Name);
                if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
                {
                    object modelValue = modelProperty.GetValue(_item, null);
                    if (modelValue == null)
                        continue;

                    object valueToAssign = Convert.ChangeType(modelValue, viewProperty.PropertyType);
                    if (valueToAssign != null)
                        viewProperty.SetValue(_view, valueToAssign, null);
                }
            }
        }

        protected void SetModelPropertiesFromView()
        {
            foreach (PropertyInfo viewProperty in _view.GetType().GetProperties())
            {
                if (viewProperty.CanRead)
                {
                    PropertyInfo modelProperty = _item.GetType().GetProperty(viewProperty.Name);

                    if (modelProperty != null && modelProperty.PropertyType.Equals(viewProperty.PropertyType))
                    {
                        object valueToAssign = Convert.ChangeType(viewProperty.GetValue(_view, null), modelProperty.PropertyType);

                        if (valueToAssign != null)
                        {
                            modelProperty.SetValue(_item, valueToAssign, null);
                        }
                    }
                }
            }
        } 
        #endregion

    }
}
