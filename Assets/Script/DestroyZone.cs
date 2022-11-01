using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]
public class DestroyZone : MonoBehaviour
{
    public bool isEndZone;

    private BoxCollider2D col2D;
    private void OnTriggerExit2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(isEndZone == true && collision.CompareTag("Enemy"))
        {
            //게임 오버
        }
    }

    private void Start()
    {
        col2D = GetComponent<BoxCollider2D>();

    }


}
