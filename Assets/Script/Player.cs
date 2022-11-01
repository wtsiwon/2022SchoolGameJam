using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    public float[] posY;

    public int currentPosIndex = 1;

    public GameObject[] skillObjs;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.S) && !(currentPosIndex == 2))
        {
            currentPosIndex += 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            //transform.position = new Vector3(transform.position.x, posY[currentPosIndex], 0);
        }
        else if (Input.GetKeyDown(KeyCode.W) && !(currentPosIndex == 0))
        {
            currentPosIndex -= 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            //transform.position = new Vector3(transform.position.x, posY[currentPosIndex], 0);
        }
    }
}
