using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private GameObject startButton;
    [SerializeField] private Image[] selection;
    [SerializeField] private GameObject soundUI, muteUI;

    public void ShowButton()
    {
        startButton.SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void ChangeDifficulty(int difficulty)
    {
        foreach (var item in selection)
        {
            item.enabled = false;
        }
        selection[difficulty].enabled = true;
        PlayerPrefs.SetInt("difficulty", difficulty);
    }

    public void SetSound(bool state)
    {
        soundUI.SetActive(state);
        muteUI.SetActive(!state);

        int temp = state ? 1 : 0;
        //FindGameObjectWithTag because its multiscene object
        GameObject.FindGameObjectWithTag("Music").GetComponent<AudioSource>().volume = temp;
        PlayerPrefs.SetInt("sound", temp);
    }

    private void Init()
    {
        ChangeDifficulty(PlayerPrefs.GetInt("difficulty",0));
        SetSound(Convert.ToBoolean(PlayerPrefs.GetInt("sound", 1)));

        Application.targetFrameRate = 300;
    }

    private void Awake()
    {
        _default = this;

        Init();
    }

    #region Singleton
    private static MenuManager _default;
    public static MenuManager Default => _default;
    #endregion
}
