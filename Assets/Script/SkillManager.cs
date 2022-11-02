using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public List<Skill> skillList = new List<Skill>();

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        
    }

    private void Update()
    {
        InputKey();
    }

    private void InputKey()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            UseTuho();
        }
        else if (Input.GetKeyDown(KeyCode.L))
        {
            UseFire();
        }
    }


    private void UseTuho()
    {
        Skill skill = skillList[(int)ESkillType.Tuho];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            print(skill.skillData.coolDown + "≈ı»£");
        }
    }

    private void UseFire()
    {
        Skill skill = skillList[(int)ESkillType.Fire];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            Player.Instance.isFireAtk = true;
            StartCoroutine(FireDuration(skill.fireDuration));
            print(skill.skillData.coolDown + "¡„∫“ ≥Ó¿Ã");
        }
    }

    private IEnumerator FireDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        Player.Instance.isFireAtk = false;
    }





}
