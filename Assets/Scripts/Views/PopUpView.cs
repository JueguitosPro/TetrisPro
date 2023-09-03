using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    /// <summary>
    /// Represents a Pop-Up view with text and button options.
    /// </summary>
    public class PopUpView : ViewBase
    {
        [SerializeField] private TextMeshProUGUI popUpText;
        [SerializeField] private Button okButton;
        [SerializeField] private Button cancelButton;

        /// <summary>
        /// Event triggered when the OK button is clicked.
        /// </summary>
        public event Action onOkButtonClicked;

        /// <summary>
        /// Event triggered when the Cancel button is clicked.
        /// </summary>
        public event Action onCancelButtonClicked;

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            okButton.onClick.AddListener(OnOkButtonClicked);
            cancelButton.onClick.AddListener(OnCancelButtonClicked);
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            okButton.onClick.RemoveAllListeners();
            cancelButton.onClick.RemoveAllListeners();
        }

        private void OnDestroy()
        {
            onOkButtonClicked = null;
            onCancelButtonClicked = null;
        }

        private void OnOkButtonClicked()
        {
            onOkButtonClicked?.Invoke();
        }

        private void OnCancelButtonClicked()
        {
            onCancelButtonClicked?.Invoke();
        }

        /// <summary>
        /// Sets the text message displayed in the Pop-Up.
        /// </summary>
        /// <param name="popUpMessage">The message to display.</param>
        public void SetPopUpMessage(string popUpMessage)
        {
            popUpText.SetText(popUpMessage);
        }

        /// <summary>
        /// Initializes the visibility of the OK and Cancel buttons.
        /// </summary>
        /// <param name="showOkButton">True to show the OK button, false to hide it.</param>
        /// <param name="showCancelButton">True to show the Cancel button, false to hide it.</param>
        public void InitButtons(bool showOkButton, bool showCancelButton)
        {
            okButton.gameObject.SetActive(!showOkButton && !showCancelButton || showOkButton);
            cancelButton.gameObject.SetActive(showCancelButton);
        }
    }
}
