using Microsoft.Xna.Framework;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;

namespace MoveTo
{
    abstract class GameObject
    {        
        protected GameTime _gameTime;

        public void Update(GameTime gameTime)
        {
            _gameTime = gameTime;
            Update();
            UpdateCoroutines();
        }

        protected virtual void Update() { }

        private List<Coroutine> _coroutines = new List<Coroutine>();

        private void UpdateCoroutines()
        {
            var coroutinesToUpd = _coroutines.ToList();
            coroutinesToUpd.ForEach((c) => c.Step());
        }      

        protected void StartCoroutine(IEnumerator coroutine, bool limitToOneInstance = false, [CallerMemberName] string name = null)
        {
            if (limitToOneInstance)
                if (_coroutines.Where(c => c.Name == name).Any())
                    return;

            _coroutines.Add(new Coroutine(name, coroutine)
                .Done((c) => _coroutines.Remove(c)));
        }
    }
}
