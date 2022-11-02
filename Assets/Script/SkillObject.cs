using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillObject : MonoBehaviour
{
    public ESkillType skillType;
    private float dmg;

    public float Dmg
    {
        get => dmg;
        set
        {
            dmg = value;

        }
    }

    public void SetObj(ESkillType type, float dmg)
    {
        skillType = type;
        Dmg = dmg;
    }

    


}
