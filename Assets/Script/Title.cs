using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Title : MonoBehaviour
{
    public Button gameStartBtn;

    private void Start()
    {
        gameStartBtn.onClick.AddListener(() =>
        {
            GoInGame();
        });
    }

    private void GoInGame()
    {
        SceneManager.LoadScene("InGame");
    }
}
