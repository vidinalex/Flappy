using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreUI;
    [SerializeField] private GameObject endGameUI;

    private int score = 0;
    private void Start()
    {
        Physics2D.gravity = new Vector2(0, 0);
    }
    public void StartGame()
    {
        Physics2D.gravity = new Vector2(0, -10f);
    }
    public void EndGame()
    {
        Time.timeScale = 0;

        endGameUI.SetActive(true);
    }
    public void IncreaceScore()
    {
        score++;
        scoreUI.text = score.ToString();
    }

    public void LoadScene(string sceneName)
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(sceneName);
    }

    private void Awake()
    {
        _default = this;
    }

    #region Singleton
    private static PlayManager _default;
    public static PlayManager Default => _default;
    #endregion
}
