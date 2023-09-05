using System;
using UnityEngine;

namespace JueguitosPro.Views
{
    /// <summary>
    /// A base class for views.
    /// </summary>
    [RequireComponent(typeof(RectTransform))]
    public class ViewBase : MonoBehaviour
    {
        /// <summary>
        /// Gets the RectTransform component associated with this view.
        /// </summary>
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

        /// <summary>
        /// Sets the active state of the view.
        /// </summary>
        /// <param name="active">True to activate the view, false to deactivate it.</param>
        public void SetActive(bool active)
        {
            if (this != null && gameObject != null)
            {
                gameObject.SetActive(active);
            }
        }

        /// <summary>
        /// Destroys the view.
        /// </summary>
        public virtual void Destroy()
        {
            if (this != null && gameObject != null)
            {
                GameObject.Destroy(gameObject);
            }
        }

        /// <summary>
        /// Shows the view.
        /// </summary>
        /// <param name="onShow">An optional action to execute after showing the view.</param>
        public virtual void Show(Action onShow = null)
        {
            if (gameObject.activeInHierarchy)
            {
                return;
            }

            SetActive(true);

            onShow?.Invoke();
        }

        /// <summary>
        /// Hides the view.
        /// </summary>
        /// <param name="onHide">An optional action to execute after hiding the view.</param>
        public virtual void Hide(Action onHide = null)
        {
            if (!gameObject.activeInHierarchy)
            {
                return;
            }

            SetActive(false);

            onHide?.Invoke();
        }
    }
}
