using UnityEngine;
using UnityEngine.UI;

namespace Battle.Resolve
{
    public class ResolveBar : MonoBehaviour
    {
        private Slider _resolveBar;
        private int _resolve;

        public int Resolve => _resolve;

        private void Awake() 
        {
            _resolveBar = GetComponent<Slider>();
        }

        public void InitializeResolve(int resolve)
        {
            _resolve = resolve;
            if(_resolve > 100) _resolve = 100;
            if(_resolve < 0) _resolve = 0;
            _resolveBar.value = _resolve;
        }

        public void ChangeResolve(int value)
        {
            _resolve += value;
            if(_resolve > 100) _resolve = 100;
            if(_resolve < 0) _resolve = 0;
            _resolveBar.value = _resolve;
        }
    }
}

