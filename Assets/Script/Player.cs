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

    public Animator attackAnim;
    [HideInInspector]
    public Animator playerAnim;

    public float dmg;
    public float defaultDmg;
    public float onFireDmg;
    public float moveXSpd;

    private BoxCollider2D boxCollider;

    [Tooltip("???? ???̰? ???? ?ִ°?")]
    public bool isFireAtk;

    public float[] posY;

    public int currentPosIndex = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        playerAnim = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        pengiSkill.icon.fillAmount = 1;
        dmg = defaultDmg;
    }
    private void Update()
    {
        InputKey();
        if (isFireAtk == true)
        {
            dmg = onFireDmg;
        }
        else
        {
            dmg = defaultDmg;
        }

        if(Mathf.Abs(transform.position.x) >= 8.5f)
        {

        }
    }

    private void InputKey()
    {
        #region Move
        if (Input.GetKeyDown(KeyCode.S) && !(currentPosIndex == 2))
        {
            currentPosIndex += 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            print("?Ʒ?");
        }
        else if (Input.GetKeyDown(KeyCode.W) && !(currentPosIndex == 0))
        {
            currentPosIndex -= 1;
            transform.DOMoveY(posY[currentPosIndex], 0.5f);
            print("??");
        }
        float x = Input.GetAxisRaw("Horizontal") * moveXSpd;
        transform.position = new Vector3(transform.position.x + x, transform.position.y, 0);
        #endregion
        if (Input.GetKeyDown(KeyCode.J))
        {
            print("??");
            if (pengiSkill.skillData.coolDown == false)
            {
                //attackAnim.SetInteger("AttackNum", 1);
                pengiSkill.skillData.coolDown = true;
                pengiSkill.icon.fillAmount = 0;
                BasicAttack();
            }
            StartCoroutine(CWaitBasicAnim());
        }
    }

    private void BasicAttack()
    {
        //if (detectedEnemy == null) return;
        print(pengiSkill.skillData.coolDown);

        playerAnim.SetInteger("AtkNum" ,1);

        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position + boxCollider.offset, boxCollider.size, 0, Vector3.forward);

        //Gizmos.DrawLine(transform.position + (Vector3)boxCollider.offset, );

        for (int i = 0; i < rays.Length; i++)
        {
            print(rays[i]);
            if (rays[i].collider.GetComponent<Enemy>() == null)
            {
                continue;
            }
            Enemy enemy = rays[i].collider.GetComponent<Enemy>();
            if (enemy == null) print(enemy);
            enemy.Hp -= (int)dmg;

            EffectManager.Instance.DmgTextEffect(dmg, rays[i].collider.transform.position);
        }
        playerAnim.SetInteger("AtkNum", 0);
    }

    private IEnumerator CWaitBasicAnim()
    {
        yield return new WaitForSeconds(0.02f);
        //attackAnim.SetInteger("AttackNum", 0);
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
