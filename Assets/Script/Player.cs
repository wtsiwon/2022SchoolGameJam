using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [HideInInspector]
    public Enemy detectedEnemy;

    public float dmg;
    public float attackSpd;
    public float moveXSpd;

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
        #region Move
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
        float x = Input.GetAxisRaw("Horizontal") * moveXSpd;
        transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
        #endregion
        if (Input.GetKeyDown(KeyCode.J))
        {
            BasicAttack();
        }
    }

    private void BasicAttack()
    {
        print("attack");
        if (detectedEnemy == null) return;
        detectedEnemy.Hp -= (int)dmg;
        EffectManager.Instance.DmgTextEffect(dmg, detectedEnemy.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            detectedEnemy = collision.GetComponent<Enemy>();
            print(detectedEnemy);
        }
    }

}
