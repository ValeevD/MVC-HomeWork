using System;
using UnityEngine;
using UnityEngine.UI;

namespace MVCExample
{
    public class UIInfo : MonoBehaviour, IUIInfo
    {
        [SerializeField] private CanvasGroup buttonsGroup;
        [SerializeField] private Button restartButton;
        [SerializeField] private Button exitButton;
        [SerializeField] private Text scoreText;
        [SerializeField] private Text gameResultText;

        private GameController gameController;

        private void Awake()
        {
            Canvas curCanvas = GetComponent<Canvas>();
            curCanvas.renderMode = RenderMode.ScreenSpaceCamera;
            curCanvas.worldCamera = Camera.main;
            gameController = FindObjectOfType<GameController>();

            HideButtonsGroup();
        }

        public void SetLose()
        {
            SetGameResult(true);
        }


        public void SetWin()
        {
            SetGameResult();
        }

        public void SetScore(int score)
        {
            scoreText.text = "Score: " + score.ToString();
        }

        private void HideButtonsGroup()
        {
            restartButton.onClick.RemoveAllListeners();
            exitButton.onClick.RemoveAllListeners();
            SetEnableButtonsGroup(false);
        }

        private void ShowButtonsGroup()
        {
            restartButton.onClick.AddListener(gameController.RestartLevel);
            exitButton.onClick.AddListener(gameController.ExitGame);
            SetEnableButtonsGroup(true);
        }

        private void SetEnableButtonsGroup(bool _enabled)
        {
            buttonsGroup.alpha = _enabled ? 1 : 0;
            buttonsGroup.blocksRaycasts = _enabled;
            buttonsGroup.interactable = _enabled;
        }

        private void SetGameResultText(string _text)
        {
            gameResultText.text = _text;
        }

        private void SetGameResult(bool isDefeat=false)
        {
            SetGameResultText(isDefeat ? "DEFEAT": "VICTORY");
            ShowButtonsGroup();
        }

        public void Destroy()
        {
            Destroy(gameObject);
        }
    }
}
