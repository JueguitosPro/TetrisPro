using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    /// <summary>
    /// Represents a view for displaying a leaderboard.
    /// </summary>
    public class LeaderboardView : ViewBase
    {
        [SerializeField] private LeaderboardEntry leaderboardEntryPrefab;
        [SerializeField] private Button backButton;
        [SerializeField] private Button allTimeTab;
        [SerializeField] private Transform scrollViewContent;

        /// <summary>
        /// Event triggered when the back button is clicked.
        /// </summary>
        public event Action onBackButtonClicked;

        /// <inheritdoc/>
        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        /// <inheritdoc/>
        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnDestroy()
        {
            onBackButtonClicked = null;
        }

        /// <summary>
        /// Sets the leaderboard data and updates the view.
        /// </summary>
        /// <param name="leaderboardData">List of leaderboard data to display.</param>
        public void SetLeaderboard(List<LeaderboardData> leaderboardData)
        {
            foreach (var data in leaderboardData)
            {
                LeaderboardEntry entry = Instantiate(leaderboardEntryPrefab, scrollViewContent);
                entry.InitLeaderboardEntry(data.Rank, data.Username, data.Score);
            }
        }

        private void OnBackButtonClicked()
        {
            onBackButtonClicked?.Invoke();
        }
    }
}
