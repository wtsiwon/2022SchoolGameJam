using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public int maxHp;

    public TextMeshProUGUI dmgText;

    private Rigidbody2D rb;

    public Slider hpbar;

    [SerializeField]
    protected int hp;

    public float moveSpd;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = Vector3.left * moveSpd;
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
                hpbar.value = maxHp - hp;

            }
        }
    }

    private void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
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
