using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public List<Skill> skillList = new List<Skill>();

    public float tuhoMoveSpd;
    public float tuhoDmg;

    public float gangForce;

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
        else if (Input.GetKeyDown(KeyCode.I))
        {
            UseGangGang();
        }
    }


    private void UseTuho()
    {
        Skill skill = skillList[(int)ESkillType.Tuho];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            GameObject obj = Instantiate(skill.skillData.skillObj);
            obj.transform.position
                = new Vector3(Player.Instance.transform.position.x,
                Player.Instance.posY[Player.Instance.currentPosIndex], 0);
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.right * tuhoMoveSpd;
            Destroy(obj, 8);

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

    private void UseGangGang()
    {
        Skill skill = skillList[(int)ESkillType.GangGang];
        if(skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            GameObject obj = Instantiate(skill.skillData.skillObj);
            obj.transform.position
                = new Vector3(Player.Instance.transform.position.x, 
                Player.Instance.posY[Player.Instance.currentPosIndex], 0);
            Destroy(obj, 5);
            print(skill.skillData.coolDown + "∞≠∞≠");
        }
    }



}
