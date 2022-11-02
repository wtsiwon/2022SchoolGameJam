using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

[RequireComponent(typeof(BoxCollider2D))]
public class DestroyZone : MonoBehaviour
{
    public bool isEndZone;

    private BoxCollider2D col2D;

    
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
        if (collision.CompareTag("Enemy"))
        {
            GameManager.Instance.Hp -= 1;
            GameManager.Instance.cam.transform.DOShakePosition(0.2f,0.5f);
        }
    }

    private void Start()
    {
        col2D = GetComponent<BoxCollider2D>();
        GameManager.Instance.cam.transform.DOShakePosition(0.2f);

    }


}
