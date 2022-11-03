using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class GonggiObj : MonoBehaviour
{
    private SkillManager skillManager;

    private BoxCollider2D box;
    private void Start()
    {
        box = GetComponent<BoxCollider2D>();
        skillManager = SkillManager.Instance;
        transform.DOMove(skillManager.gonggiBoomPos, 1f);
        StartCoroutine(CGonggiDamaged());

    }
    private IEnumerator CGonggiDamaged()
    {
        yield return new WaitForSeconds(1f);

        RaycastHit2D[] rays = Physics2D.BoxCastAll((Vector2)transform.position,
            box.size * 13, 0, Vector3.forward);
        for (int i = 0; i < rays.Length; i++)
        {
            Enemy enemy = rays[i].collider.GetComponent<Enemy>();
            print(enemy);
            if (enemy == null) continue;

            enemy.Hp -= (int)skillManager.gonggiDmg;
            EffectManager.Instance.DmgTextEffect(skillManager.gonggiDmg, enemy.transform.position);
        }
        GameManager.Instance.cam.transform.DOShakePosition(0.1f, 0.5f).OnComplete(() 
            => GameManager.Instance.cam.transform.DOMove(new Vector3(0,0,-10),0.1f));
        Destroy(gameObject);
    }
}
