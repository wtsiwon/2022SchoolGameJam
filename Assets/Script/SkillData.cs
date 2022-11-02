using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkillData", menuName = "data/SkillData",order = int.MinValue)]
public class SkillData : ScriptableObject
{
    public ESkillType skillType;
    public Sprite skillIconSprite;
    public float coolTime;
    public GameObject skillObj;
    public bool coolDown;
}
