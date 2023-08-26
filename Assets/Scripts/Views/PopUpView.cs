using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class PopUpView : ViewBase
    {
        [SerializeField] private TextMeshProUGUI popUpText;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        public event Action onOkButtonClicked;
        public event Action onCancelButtonClicked;

        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
        }

        private void OnOkButtonClicked()
        {
            onOkButtonClicked?.Invoke();
        }

        private void OnCancelButtonClicked()
        {
            onCancelButtonClicked?.Invoke();
        }

        public void SetPopUpMessage(string popUpMessage)
        {
            popUpText.SetText(popUpMessage);
        }

        public void InitButtons(bool showOkButton, bool showCancelButton)
        {
            okButton.gameObject.SetActive(showOkButton);
            cancelButton.gameObject.SetActive(showCancelButton);
        }
    }
}
