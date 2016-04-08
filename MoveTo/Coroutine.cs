using System;
using System.Collections;

namespace MoveTo
{
    class Coroutine
    {
        public string Name { get; private set; }

        private IEnumerator _generator;

        public Coroutine(string name, IEnumerator generator)
        {
            Name = name;
            _generator = generator;
        }

        public void Step()
        {
            if (!_generator.MoveNext())
                _done?.Invoke(this);
        }

        private Action<Coroutine> _done;

        public Coroutine Done(Action<Coroutine> done)
        {
            _done = done;
            return this;
        }
    }
}
