using System;
using UnityEngine;

namespace JueguitosPro.Views
{
    [RequireComponent(typeof(RectTransform))]
    public class ViewBase : MonoBehaviour
    {
        public RectTransform RectTransform
        {
            get
            {
                if (_rectTransform == null)
                {
                    _rectTransform = GetComponent<RectTransform>();
                }

                return _rectTransform;
            }
        }

        private RectTransform _rectTransform;

        public void SetActive(bool active)
        {
            if (this != null && gameObject != null)
            {
                gameObject.SetActive(active);
            }
        }

        public virtual void Destroy()
        {
            if (this != null && gameObject != null)
            {
                GameObject.Destroy(gameObject);
            }
        }
        
        public virtual void Open(Action opened = null)
        {
            if (gameObject.activeInHierarchy)
            {
                return;
            }
            
            SetActive(true);
            
            opened?.Invoke();
        }
    }
}
