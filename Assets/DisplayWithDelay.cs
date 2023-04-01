using Cysharp.Threading.Tasks;
using UnityEngine;

namespace Display
{
    public class DisplayWithDelay: MonoBehaviour
    {
        [SerializeField] private float delay;
        private bool _entered;
        

        public async void HideAndShow()
        {
            if(_entered) return;
            _entered = true;
            gameObject.SetActive(false);
            await UniTask.Delay((int)(1000 * delay));
            gameObject.SetActive(true);
            _entered = false;
        }
    }
}