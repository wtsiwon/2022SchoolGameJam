using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SkillManager : MonoBehaviour
{
    public static SkillManager Instance;

    public List<Skill> skillList = new List<Skill>();

    public List<Sprite> gonggiSprite = new List<Sprite>();

    public float tuhoMoveSpd;
    public float tuhoDmg;

    public float gangForce;

    public float fireDuration;

    public Vector3 gonggiSpawnPos;
    public Vector3 gonggiBoomPos;
    public float gonggiDmg;

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
        else if (Input.GetKeyDown(KeyCode.O))
        {
            StartCoroutine(UseGonggi());
        }
    }


    private void UseTuho()
    {
        Skill skill = skillList[(int)ESkillType.Tuho];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            #region ��ȣ ��ų
            GameObject obj = Instantiate(skill.skillData.skillObj);
            obj.transform.position
                = new Vector3(Player.Instance.transform.position.x,
                Player.Instance.posY[Player.Instance.currentPosIndex], 0);
            obj.GetComponent<Rigidbody2D>().velocity = Vector3.right * tuhoMoveSpd;
            Destroy(obj, 8);
            #endregion
            print(skill.skillData.coolDown + "��ȣ");
        }
    }

    private void UseFire()
    {
        Skill skill = skillList[(int)ESkillType.Fire];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            #region ��ҳ��� ��ų
            Player.Instance.isFireAtk = true;
            StartCoroutine(FireDuration(fireDuration));
            #endregion
            print(skill.skillData.coolDown + "��� ����");
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
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            #region �������� ��ų
            GameObject obj = Instantiate(skill.skillData.skillObj);
            obj.transform.position
                = new Vector3(Player.Instance.transform.position.x,
                Player.Instance.posY[Player.Instance.currentPosIndex], 0);
            Destroy(obj, 5);
            #endregion
            print(skill.skillData.coolDown + "����");
        }
    }

    private IEnumerator UseGonggi()
    {
        Skill skill = skillList[(int)ESkillType.Gonggi];
        if (skill.skillData.coolDown == false)
        {
            skill.skillData.coolDown = true;
            skill.icon.fillAmount = 0;
            #region ������� ��ų
            for (int i = 0; i < gonggiSprite.Count; i++)
            {
                GameObject obj = Instantiate(skill.skillData.skillObj);
                obj.transform.position = gonggiSpawnPos;
                obj.GetComponent<SpriteRenderer>().sprite = gonggiSprite[i];
                print(obj);

                yield return new WaitForSeconds(1f);
            }

            //for (int i = 0; i < rays.Length; i++)
            //{
            //    print(rays[i]);
            //    if (rays[i].collider.GetComponent<Enemy>() == null)
            //    {
            //        continue;
            //    }
            //    Enemy enemy = rays[i].collider.GetComponent<Enemy>();

            //    if (enemy == null) print(enemy);
            //    enemy.Hp -= (int)gonggiDmg;

            //    EffectManager.Instance.DmgTextEffect(gonggiDmg, rays[i].collider.transform.position);
            //}
            #endregion
        }
    }
}

