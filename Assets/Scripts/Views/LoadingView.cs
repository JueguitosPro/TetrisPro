using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class ProgressEvent
    {
        public float Progress { get; set; }
        public float Duration { get; set; }
    }
    public class LoadingView : ViewBase
    {
        [SerializeField] private Image progressBar;

        private Queue<ProgressEvent> progressEvents;
        private bool isTweening;

        private void Update()
        {
            if (progressEvents.Count > 0 && !isTweening)
            {
                ProgressEvent progressEvent = progressEvents.Dequeue();
                SetProgressBarProgress(progressEvent.Progress, progressEvent.Duration);
            }
        }

        public override void Show(Action onShow = null)
        {
            SetActive(true);
            progressEvents = new Queue<ProgressEvent>();
            onShow?.Invoke();
        }

        public override void Hide(Action onHide = null)
        {
            SetActive(false);
            onHide?.Invoke();
        }

        public void RegisterProgressEvent(float progress, float duration)
        {
            ProgressEvent progressEvent = new ProgressEvent() { Progress = progress, Duration = duration };
            progressEvents.Enqueue(progressEvent);
        }

        private void SetProgressBarProgress(float progress, float duration)
        {
            isTweening = true;
            progressBar.DOFillAmount(progress, 1 * duration).OnComplete(() => { isTweening = false;});
        }
    }
}

