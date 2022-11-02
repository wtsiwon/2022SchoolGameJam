using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class EffectManager : MonoBehaviour
{
    public static EffectManager Instance;

    private void Awake()
    {
        Instance = this;
    }

    public List<GameObject> effectList = new List<GameObject>();

    public void DmgTextEffect(float dmg, Vector3 pos)
    {
        GameObject dmgText = Instantiate(effectList[(int)EEffectType.DmgText], pos, 
            Quaternion.identity, GameManager.Instance.canvas.transform);

        dmgText.transform.position = pos;
        dmgText.transform.DOMoveY(pos.y + 1,0.5f);
        dmgText.GetComponent<TextMeshProUGUI>().text = $"-{(int)dmg}";

        Destroy(dmgText, 0.4f);
    }
}
