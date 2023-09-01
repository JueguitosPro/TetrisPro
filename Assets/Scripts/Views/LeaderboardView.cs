using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace JueguitosPro.Views
{
    public class LeaderboardView : ViewBase
    {
        [SerializeField] private LeaderboardEntry leaderboardEntryPrefab;
        [SerializeField] private Button backButton;
        [SerializeField] private Button allTimeTab;
        [SerializeField] private Transform scrollViewContent;

        public event Action onBackButtonClicked;

        public override void Show(Action onShow = null)
        {
            base.Show(onShow);
            backButton.onClick.AddListener(OnBackButtonClicked);
        }

        public override void Hide(Action onHide = null)
        {
            base.Hide(onHide);
            backButton.onClick.RemoveListener(OnBackButtonClicked);
        }

        private void OnDestroy()
        {
            onBackButtonClicked = null;
        }

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
