using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Symulator
{
    public class ResponseSupport<T> // DelayPromise 
    {
        List<T> buff = new List<T>();

        public ResponseSupport<T> Append(T[] data)
        {
            buff.AddRange(data);
            return this;
        }

        public ResponseSupport<T> SetTimeout(Action<T[]> action, int delay)
        {
            this.Resolve();

            var tokenSource = new CancellationTokenSource();

            Task.Run(async () =>
            {
                await Task.Delay(delay);
                action.Invoke(buff.ToArray());
            }, tokenSource.Token);

            return this;
        }

        public ResponseSupport<T> Resolve()
        {
            return this;
        }
    }
}
