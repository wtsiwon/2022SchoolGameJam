using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverScene : MonoBehaviour
{
    public Button restartBtn;


    private void Start()
    {
        restartBtn.onClick.AddListener(() =>
        {
            GoTitle();
        });
    }

    private void GoTitle()
    {
        SceneManager.LoadScene("Title");
    }

}
