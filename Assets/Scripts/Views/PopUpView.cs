using System;
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
            okButton.onClick.AddListener(OnOkButtonClicked);
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            okButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
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
            okButton.gameObject.SetActive(!showOkButton && !showCancelButton || showOkButton);
            cancelButton.gameObject.SetActive(showCancelButton);
        }
    }
}
