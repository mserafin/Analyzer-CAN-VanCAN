using System.Collections.Generic;
using System.ComponentModel;

namespace Symulator.Infrastructure.datagrid
{
    public class BindingListInvoke<T> : BindingList<T>
    {
        delegate void ListChangedDelegate(ListChangedEventArgs e);

        ISynchronizeInvoke invoke;

        public BindingListInvoke() { }

        public BindingListInvoke(ISynchronizeInvoke invoke)
        {
            this.invoke = invoke;
        }
        public BindingListInvoke(IList<T> items)
        {
            DataSource = items;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (invoke?.InvokeRequired ?? false)
            {
                invoke.BeginInvoke(new ListChangedDelegate(base.OnListChanged), new object[] { e });
            }
            else
            {
                base.OnListChanged(e);
            }
        }
        public IList<T> DataSource
        {
            get
            {
                return this;
            }
            set
            {
                if (value != null)
                {
                    ClearItems();
                    RaiseListChangedEvents = false;

                    foreach (T item in value)
                    {
                        Add(item);
                    }

                    RaiseListChangedEvents = true;
                    OnListChanged(new ListChangedEventArgs(ListChangedType.Reset, -1));
                }
            }
        }
    }
}
