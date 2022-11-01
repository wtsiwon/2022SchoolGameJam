using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(BoxCollider2D))]
public class Enemy : MonoBehaviour
{
    public int maxHp;

    public TextMeshProUGUI dmgText;

    [SerializeField]
    protected int hp;

    public float moveSpd;

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

            }
        }
    }

    public void OnDie()
    {

    }

    public void OnDamaged()
    {

    }

}
