using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public bool isGameStart;

    public GameObject[] hpObj;

    private void Awake()
    {
        Instance = this;
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }



}