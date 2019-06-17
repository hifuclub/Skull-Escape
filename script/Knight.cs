using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knight : MonoBehaviour
{
    CharacterController cc;
    public float h = 0;
    Vector3 movement;
    Animator anim;
    Transform player;
    float range;
    public int speed = 10, rushSpeed;
    public int kntFSM = 0;
    private int fireRange;
    private int lstime;
    private Vector3 rushRot;
    private Vector3 initialPos;
    float iniRange;
    public Quaternion lsShowMe;
    bool isTr;//造成撞击
    int isTrCD;//撞击冷却
    int isRunCD;//追击冷却
    int hp;

    public GameObject deathPar;

    public GameObject call;
    // Use this for initialization
    void Start()
    {
        cc = this.GetComponent<CharacterController>();
        anim = this.GetComponent<Animator>();
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        fireRange = 70;//初始化攻击距离
        initialPos = this.transform.position;
        hp = 7;
    }

    // Update is called once per frame
    void Update()
    {
        range = Vector3.Distance(this.transform.position, player.position);
        movement = new Vector3(0, 0, 0);

        //////////////////////////////////////////状态机分支判断
        if (range > fireRange + 30 && kntFSM == 0 && range < 110)
        {
            kntFSM = 1;//移动状态
            anim.SetBool("move", true);
            lstime = 0;

        }
        if (range <= fireRange && (kntFSM == 1 || kntFSM == 6))
        {
            kntFSM = 2;//瞄准状态(禁止移动)
            anim.SetBool("move", false);
            lstime = 0;


        }


        //////////////////////////////////////////数值加工
        Vector3 nowRotation = this.transform.rotation.eulerAngles;
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - player.position);
        Vector3 lsRot = targetRotation.eulerAngles;
        lsRot.y += 90;
        lsRot.x = 0;
        lsRot.z = 0;
        targetRotation = Quaternion.Euler(lsRot);


        //////////////////////////////////////////状态机

        if (kntFSM == 1 || kntFSM == 6) //移动状态
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            //Debug.Log("wait" + lstime);
            movement = new Vector3(Mathf.Cos(nowRotation.y * 3.14159f / 180) * speed * Time.deltaTime, 0, -Mathf.Sin(nowRotation.y * 3.14159f / 180) * speed * Time.deltaTime);

            //回家
            if (kntFSM == 1 && range > 120)
            {
                kntFSM = 5;

            }
            if (kntFSM == 1 && lstime++ > 60 * 5)
            {
                kntFSM = 5;

            }
            if (kntFSM == 6 && isRunCD++ > 60 * 7)
            {
                kntFSM = 5;
            }

        }

        if (kntFSM == 2) //瞄准状态(禁止移动)
        {
            anim.SetBool("ready", true);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            //Debug.Log("wait" + lstime);
            if (lstime++ > 60 * 3)
            {
                anim.SetBool("ready", false);
                lstime = 0;
                kntFSM = 3;
                anim.SetBool("run", true);

                movement = new Vector3(0, 0, 0);
            }

        }
        if (kntFSM == 3)//冲刺
        {
            movement = new Vector3(Mathf.Cos(nowRotation.y * 3.14159f / 180) * rushSpeed * Time.deltaTime, 0, -Mathf.Sin(nowRotation.y * 3.14159f / 180) * rushSpeed * Time.deltaTime);
            if (lstime++ > 60 * 3.5)
            {
                lstime = 0;
                kntFSM = 4;
                anim.SetBool("run", false);
                anim.SetBool("rerest", true);

                movement = new Vector3(0, 0, 0);
            }
        }

        if (kntFSM == 4)//收武器
        {
            if (lstime++ > 60 * 3)
            {
                anim.SetBool("rerest", false);
                lstime = 0;
                kntFSM = 5;
                anim.SetBool("move", true);

                movement = new Vector3(0, 0, 0);
            }
        }
        if (kntFSM == 5) //返回初始位置
        {
            iniRange = Vector3.Distance(this.transform.position, initialPos);
            Quaternion originRotation = Quaternion.LookRotation(transform.position - initialPos);
            Vector3 lsRot2 = originRotation.eulerAngles;
            lsRot2.y += 90;
            lsRot2.x = 0;
            lsRot2.z = 0;
            originRotation = Quaternion.Euler(lsRot2);
            Vector3 iniRotation = originRotation.eulerAngles;
            ////同上数据处理

            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, speed * Time.deltaTime);
            //Debug.Log("wait" + lstime);
            movement = new Vector3(Mathf.Cos(iniRotation.y * 3.14159f / 180) * speed * Time.deltaTime, 0, -Mathf.Sin(iniRotation.y * 3.14159f / 180) * speed * Time.deltaTime);
            if (iniRange < 10)
            {
                anim.SetBool("move", false);
                kntFSM = 0;
            }
            if (range < fireRange + 20)
            {
                kntFSM = 1;
            }
        }

        if (!cc.isGrounded)
        {//判断人物是否在地面上 

            h += -9.8f * Time.deltaTime;//不在地面上 
        }

        movement.y = h;
        cc.Move(movement);//总移动语句

        if (isTr)
        {
            if (isTrCD++ > 180)
            {
                isTrCD = 0;
                isTr = false;
            }
        }

        if (hp <= 0)
        {
            death();
        }

    }

    void hasDamage()//被打
    {
        call.SetActive(true);
        kntFSM = 6;
        anim.SetBool("move", true);
        isRunCD = 0;
    }

    void death()
    {
        Instantiate(deathPar, this.transform.position, new Quaternion(0, 0, 0, 0));//死亡特效
        Destroy(this.gameObject);
    }



    private void OnTriggerEnter(Collider other)
    {
        if ((!other.tag.Equals("mhm01")) && (!other.tag.Equals("Untagged")) && (!isTr) && (!other.tag.Equals("mhmForPlayer")))
        {
            isTr = true;
            Debug.Log(other.tag);

            if (other.tag == Tags.player)
            {
                PlayerMove.heathPoint -= 40;
                PlayerMove.heathCD = 0;
                PlayerMove.isHurt = true;
            }
        }

        if (other.tag.Equals("mhmForPlayer"))
        {
            hp -= 1;
            hasDamage();
        }
        if (other.tag.Equals("call") && kntFSM != 2 && kntFSM != 3 && kntFSM != 4 && kntFSM != 6)
        {
            hasDamage();
        }
    }

}
