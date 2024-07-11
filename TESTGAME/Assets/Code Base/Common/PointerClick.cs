using UnityEngine;
using UnityEngine.EventSystems;

namespace Common
{
    public class PointerClick : MonoBehaviour, IPointerDownHandler
    {
        private bool click;
        public bool IsClick => click;

        public void OnPointerDown(PointerEventData eventData)
        {
             click = !click;
        }
    }
}
