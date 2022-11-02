using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public static Player Instance;

    [HideInInspector]
    public Enemy detectedEnemy;

    public Skill pengiSkill;

    public float dmg;
    public float defaultDmg;
    public float onFireDmg;
    public float moveXSpd;

    [Tooltip("쥐불 놀이가 켜져 있는가")]
    public bool isFireAtk;

    public float[] posY;

    public int currentPosIndex = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        pengiSkill.icon.fillAmount = 1;
        dmg = defaultDmg;
    }
    private void Update()
    {
        InputKey();
        if(isFireAtk == true)
        {
            dmg = onFireDmg;
        }
    }

    private void InputKey()
    {
        #region Move
        if (Input.GetKeyDown(KeyCode.S) && !(currentPosIndex == 2))
        {
            currentPosIndex += 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            print("아래");
        }
        else if (Input.GetKeyDown(KeyCode.W) && !(currentPosIndex == 0))
        {
            currentPosIndex -= 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            print("위");
        }
        float x = Input.GetAxisRaw("Horizontal") * moveXSpd;
        transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
        #endregion
        if (Input.GetKeyDown(KeyCode.J) && pengiSkill.skillData.coolDown == false)
        {
            pengiSkill.skillData.coolDown = true;
            pengiSkill.icon.fillAmount = 0;
            BasicAttack();
        }
    }

    private void BasicAttack()
    {
        if (detectedEnemy == null) return;
        print(pengiSkill.skillData.coolDown);
        print("attack");
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
