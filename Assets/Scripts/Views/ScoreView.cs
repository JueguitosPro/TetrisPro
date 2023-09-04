using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    /// <summary>
    /// Represents a view for displaying the player's score.
    /// </summary>
    public class ScoreView : ViewBase
    {
        [SerializeField] private GameObject highScoreText;
        [SerializeField] private TextMeshProUGUI scoreText;
        [SerializeField] private Button continueButton;

        /// <summary>
        /// Event triggered when the continue button is clicked.
        /// </summary>
        public event Action onContinueButtonClicked;

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            continueButton.onClick.AddListener(OnContinueButtonClicked);
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            continueButton.onClick.RemoveListener(OnContinueButtonClicked);
        }

        /// <summary>
        /// Sets the player's score and show/hide a text if the score is a high score.
        /// </summary>
        /// <param name="score">The player's score.</param>
        /// <param name="isHighScore">If true, shows a high score text.</param>
        public void SetScore(int score, bool isHighScore)
        {
            scoreText.SetText($"Score:\n{score}");
            highScoreText.SetActive(isHighScore);
        }

        private void OnDestroy()
        {
            onContinueButtonClicked = null;
        }

        private void OnContinueButtonClicked()
        {
            onContinueButtonClicked?.Invoke();
        }
    }
}
