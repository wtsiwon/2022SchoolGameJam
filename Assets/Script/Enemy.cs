using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using DG.Tweening;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public int maxHp;

    public TextMeshProUGUI dmgText;

    private Rigidbody2D rb;

    public Slider hpbar;

    public EEnemyType enemyType;

    [SerializeField]
    protected int hp;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        switch (enemyType)
        {
            case EEnemyType.Nomal:
                rb.velocity = Vector3.left * EnemySpawner.Instance.enemySpd;
                break;
            case EEnemyType.Middle:
                rb.velocity = Vector3.left * EnemySpawner.Instance.enemySpd / 1.5f;
                break;
            case EEnemyType.Boss:
                rb.velocity = Vector3.left * EnemySpawner.Instance.enemySpd / 2.5f;
                break;
        }

        hpbar.maxValue = maxHp;
        hpbar.value = hp;
    }
    public int Hp
    {
        get => hp;
        set
        {
            if (value > maxHp) hp = maxHp;
            else if (value <= 0) OnDie();
            else
            {
                hp = value;
                hpbar.value = hp;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        string tag = collision.tag;
        switch (tag)
        {
            case "TuhoObj":
                Hp -= (int)SkillManager.Instance.tuhoDmg;
                EffectManager.Instance.DmgTextEffect((int)SkillManager.Instance.tuhoDmg, transform.position);
                GameManager.Instance.cam.transform.DOShakePosition(0.05f, 0.5f).OnComplete(
                    () => GameManager.Instance.cam.transform.DOMove(new Vector3(0, 0, -10), 0.1f));
                break;
            case "GangGangObj":
                print(tag);
                transform.DOMoveX(transform.position.x + 3, 0.2f);
                //rb.AddForce(new Vector2(SkillManager.Instance.gangForce, SkillManager.Instance.gangForce),ForceMode2D.Force);
                break;
        }
    }

    public void OnDie()
    {
        Destroy(gameObject);
        //Á×´Â ¾Ö´Ï¸ÞÀÌ¼Ç, ÀÌÆÑÆ®
    }

    public void OnDamaged()
    {
        //¸Â´Â ÀÌÆÑÆ®?
    }

}
