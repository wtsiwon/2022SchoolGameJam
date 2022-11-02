using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skill : MonoBehaviour
{
    public SkillData skillData;

    public Image icon;

    public float fireDuration;

    private void Start()
    {
        icon.fillAmount = 1;
    }

    private void Update()
    {
        if(skillData.coolDown == true)
        {
            icon.fillAmount += 1 / skillData.coolTime * Time.deltaTime;
            if(icon.fillAmount >= 1)
            {
                icon.fillAmount = 1;
                skillData.coolDown = false;
            }
        }
    }


}
