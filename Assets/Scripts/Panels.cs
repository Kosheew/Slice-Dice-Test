using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Game
{
    public class Panels : MonoBehaviour, IService
    {
        [SerializeField] private GameObject _panelWin;
        [SerializeField] private GameObject _panelLoose;

        [SerializeField] private Button _restartButton;
        [SerializeField] private Button _nextButton;

        private int _currentScene;

        public void Init()
        {
            _panelWin.SetActive(false);
            _panelLoose.SetActive(false);
            _currentScene = SceneManager.GetActiveScene().buildIndex;

            _restartButton.onClick.AddListener(() =>
            {
                Restatr();
            });

            _nextButton.onClick.AddListener(() =>
            {
                Next();
            });
        }

        public void GameWin()
        {
            _panelWin.SetActive(true);
        }

        public void GameLoose()
        {
            _panelLoose.SetActive(true);
        }

        private void Restatr()
        {
            _currentScene = SceneManager.GetActiveScene().buildIndex;

            SceneManager.LoadScene(_currentScene);
        }

        private void Next()
        {
            int scenes = SceneManager.sceneCountInBuildSettings;

            _currentScene = SceneManager.GetActiveScene().buildIndex;  
            _currentScene++;

            if (_currentScene >= scenes) _currentScene--;

            SceneManager.LoadScene(_currentScene);
        }
    }
}