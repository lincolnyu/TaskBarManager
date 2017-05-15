using System;
using System.Collections;
using System.Collections.Generic;

namespace WinTop
{
    public class IntPtrEnumerable : IEnumerable<IntPtr>
    {
        private IntPtrEnumerator _enumerator;

        public IntPtrEnumerable()
        {
            _enumerator = new IntPtrEnumerator(this);
        }

        public Queue<IntPtr> Queue { get; }  = new Queue<IntPtr>();

        public IEnumerator<IntPtr> GetEnumerator() => _enumerator;

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public void Add(IntPtr ip) => Queue.Enqueue(ip);
    }
}
