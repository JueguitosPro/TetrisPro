using System;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    /// <summary>
    /// Represents an event that tracks progress, duration, and an associated action callback.
    /// </summary>
    public class ProgressEvent
    {
        /// <summary>
        /// Gets or sets the progress value.
        /// </summary>
        public float Progress { get; set; }

        /// <summary>
        /// Gets or sets the duration of the event.
        /// </summary>
        public float Duration { get; set; }

        /// <summary>
        /// Gets or sets the action callback associated with this event.
        /// </summary>
        public Action EventCallback { get; set; }
    }
    
    /// <summary>
    /// A view class responsible for displaying a loading progress bar.
    /// </summary>
    public class LoadingView : ViewBase
    {
        [SerializeField] private Image progressBar;

        private Queue<ProgressEvent> progressEvents;
        private bool isTweening;

        private void Update()
        {
            if (progressEvents.Count > 0 && !isTweening)
            {
                SetProgressBarProgress(progressEvents.Dequeue());
            }
        }

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            SetActive(true);
            progressEvents = new Queue<ProgressEvent>();
            onShow?.Invoke();
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            SetActive(false);
            onHide?.Invoke();
        }

        /// <summary>
        /// Registers a progress event to update the loading progress.
        /// </summary>
        /// <param name="progress">The progress value (0-1).</param>
        /// <param name="duration">The duration of the progress animation.</param>
        /// <param name="eventCallback">An optional callback to execute when the progress completes.</param>
        public void RegisterProgressEvent(float progress, float duration, Action eventCallback = null)
        {
            ProgressEvent progressEvent = new ProgressEvent() { Progress = progress, Duration = duration, EventCallback = eventCallback};
            progressEvents.Enqueue(progressEvent);
        }

        private void SetProgressBarProgress(ProgressEvent progressEvent)
        {
            isTweening = true;
            progressBar.DOFillAmount(progressEvent.Progress, 1 * progressEvent.Duration).
                OnComplete(() =>
                {
                    isTweening = false;
                    progressEvent.EventCallback?.Invoke();
                });
        }
    }
}

