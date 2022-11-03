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

    public int maxHp;

    [SerializeField]
    private int hp;
    public int Hp
    {
        get => hp;
        set
        {
            if (value > maxHp) hp = maxHp;
            else if (value <= 0) GameOver();
            else
            {
                hp = value;
                for (int i = 0; i < 3; i++)
                {
                    hpObj[i].gameObject.SetActive(false);
                }
                for (int i = 0; i < hp; i++)
                {
                    hpObj[i].gameObject.SetActive(true);
                }
            }
        }
    }

    public float gameTime = 180;

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

            if(gameTime < 30)
            {
                EnemySpawner.Instance.spawnDel = 2f;
                EnemySpawner.Instance.spawnInterval = 0;
            }
            else if(gameTime < 100)
            {
                EnemySpawner.Instance.spawnDel = 3.5f;
                
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
