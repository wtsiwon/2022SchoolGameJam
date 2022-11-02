using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public Camera cam;
    public Canvas canvas;

    public bool isGameStart;

    public GameObject[] hpObj;

    public int hp;

    public float gameTime = 300f;

    public TextMeshProUGUI timeText;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        StartCoroutine(CUpdate());
    }

    private IEnumerator CUpdate()
    {
        while (true)
        {
            if(gameTime < 0.1f)
            {
                GameOver();
            }
            yield return new WaitForSeconds(0.1f);
            gameTime -= 0.1f;
            
            timeText.text = $"남은시간:{gameTime.ToString("F1")}초";
        }
    }



    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }



}
