using System;
using System.ComponentModel;
using System.Windows.Forms;

namespace Symulator.Infrastructure.datagrid
{
    public class BindingSourceInvoke : BindingSource
    {
        ISynchronizeInvoke invoke;

        public BindingSourceInvoke() { }

        public BindingSourceInvoke(ISynchronizeInvoke invoke)
        {
            this.invoke = invoke;
        }

        protected override void OnListChanged(ListChangedEventArgs e)
        {
            if (invoke?.InvokeRequired ?? false)
            {
                invoke.BeginInvoke(new Action<ListChangedEventArgs>(base.OnListChanged), new object[] { e });
            }
            else
            {
                base.OnListChanged(e);
            }
        }
    }
}
