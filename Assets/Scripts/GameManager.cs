using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] private GameObject _gameOverCanvas;
    [SerializeField] private GameObject _gameOverText;

    private void Awake() {
        if (instance == null) {
            instance = this;
        }

        Time.timeScale = 1f;
    }

    public void GameOver() {
        _gameOverCanvas.SetActive(true);
        _gameOverText.SetActive(true);

        Time.timeScale = 0f;
    }

    public void RestartGame() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        _gameOverCanvas.SetActive(false);
        _gameOverText.SetActive(false);
    }
}
