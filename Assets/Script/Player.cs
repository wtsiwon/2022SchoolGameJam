using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float[] posY;

    public int currentPosIndex = 1;

    public GameObject a;

    private void Update()
    {
        
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.S) && !(currentPosIndex == 2))
        {
            
        }
        else if(Input.GetKeyDown(KeyCode.W) && !(currentPosIndex == 0))
        {

        }
        
    }
}
