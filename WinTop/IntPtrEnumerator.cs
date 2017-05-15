using System;
using System.Collections;
using System.Collections.Generic;

namespace WinTop
{
    public class IntPtrEnumerator : IEnumerator<IntPtr>
    {
        private IntPtrEnumerable _holder;

        public IntPtrEnumerator(IntPtrEnumerable holder)
        {
            _holder = holder;
        }

        public IntPtr Current { get; private set; }

        object IEnumerator.Current => Current;

        public void Dispose()
        {
        }

        public bool MoveNext()
        {
            var hasNext = _holder.Queue.Count > 0;
            if (hasNext)
            {
                Current = _holder.Queue.Dequeue();
            }
            return hasNext;
        }

        public void Reset()
        {
            throw new NotSupportedException();
        }
    }
}
