using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mahotukai : MonoBehaviour
{
    private Transform player;
    CharacterController cc;
    public Vector3 nowRotation;
    private GameObject mht;
    public float speed;
    public int v = 1;
    public float h = 0;
    public Vector3 movement;
    public float range;
    public Vector3 showls;//临时查看数据值用
    public int mhtFSM = 0;//角色状态机
    Animator anim;//动画状态机
    private int fireRange; //魔法师转换到开火状态所需要的和玩家的距离上限
    public MahoutPos MahoutPos;
    public bool isfireMht;
    private int lstime;
    private int lstime2;
    public GameObject fbPool;
    public GameObject fball;
    public float x, z, r;
    private Vector3 initialPos;
    float iniRange;
    int hp;
    public GameObject deathPar;
    public GameObject call;

    public int count01, count02;
    //public GameObject mhtFireObj;
    //public Vector3 mhtFirePos;
    // Use this for initialization
    void Start()
    {
        mht = this.gameObject;
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        cc = this.GetComponent<CharacterController>();/////InChildren
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        mhtFSM = 0;
        anim = this.GetComponent<Animator>();
        fireRange = 80;//魔法师转换到开火状态所需要的和玩家的距离上限默认
        initialPos = this.transform.position;//初始坐标记录
        hp = 4;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        showls = this.transform.position;

        //mhtFirePos = mhtFireObj.transform.position;//取得开火位置
        range = Vector3.Distance(this.transform.position, player.position);
        movement = new Vector3(0, 0, 0);
        Quaternion targetRotation = Quaternion.LookRotation(transform.position - player.position);


        //状态机判断部分
        if (mhtFSM == 0 && range < 90)
        {
            mhtFSM = 1;//移动状态
            anim.SetBool("move", true);
            lstime2 = 0;
        }
        if ((mhtFSM == 1 || mhtFSM == 5) && range <= fireRange - 20)
        {
            mhtFSM = 2;//瞄准状态(禁止移动)
            anim.SetBool("move", false);
            lstime = 200;//重新填装

        }


        //状态机
        if (mhtFSM == 1 || mhtFSM == 5)//移动状态
        {
            movement = new Vector3(-Mathf.Sin(nowRotation.y * 3.14159f / 180) * speed * v * Time.deltaTime, 0, -Mathf.Cos(nowRotation.y * 3.14159f / 180) * speed * v * Time.deltaTime);
            nowRotation = mht.transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);

            if (mhtFSM == 1 && range > 120)
            {
                mhtFSM = 4;
                lstime2 = 4;
            }
            if (lstime2++ > 60 * 7)
            {
                lstime2 = 4;
                mhtFSM = 4;

            }

        }
        if (mhtFSM == 2) //瞄准状态(禁止移动)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            //Debug.Log("wait" + lstime);
            if (lstime++ > 60 * 3)
            {
                lstime = 0;
                fire();
                if (range > fireRange + 30)
                {
                    anim.SetBool("move", true);
                    mhtFSM = 3;
                    lstime2 = 0;
                }
            }


        }

        if (mhtFSM == 3)//追击状态
        {
            movement = new Vector3(-Mathf.Sin(nowRotation.y * 3.14159f / 180) * speed * v * Time.deltaTime, 0, -Mathf.Cos(nowRotation.y * 3.14159f / 180) * speed * v * Time.deltaTime);
            nowRotation = mht.transform.rotation.eulerAngles;
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed * Time.deltaTime);
            if (range < fireRange)
            {
                anim.SetBool("move", false);
                mhtFSM = 2;
                lstime = 200;//重新填装
            }
            if (lstime2++ > 60 * 4)
            {
                mhtFSM = 4;

            }


        }

        if (mhtFSM == 4) //返回初始位置
        {
            iniRange = Vector3.Distance(this.transform.position, initialPos);
            Quaternion originRotation = Quaternion.LookRotation(transform.position - initialPos);
            Vector3 lsRot2 = originRotation.eulerAngles;
            lsRot2.y += 0;
            lsRot2.x = 0;
            lsRot2.z = 0;
            originRotation = Quaternion.Euler(lsRot2);
            Vector3 iniRotation = originRotation.eulerAngles;
            ////同上数据处理

            transform.rotation = Quaternion.Slerp(transform.rotation, originRotation, speed * Time.deltaTime);
            //Debug.Log("wait" + lstime);
            movement = new Vector3(-Mathf.Sin(iniRotation.y * 3.14159f / 180) * speed * Time.deltaTime, 0, -Mathf.Cos(iniRotation.y * 3.14159f / 180) * speed * Time.deltaTime);

            if (iniRange < 10)
            {
                anim.SetBool("move", false);
                mhtFSM = 0;
            }
            if (range < fireRange)
            {
                mhtFSM = 1;
            }
        }



        if (!cc.isGrounded)
        {//判断人物是否在地面上 

            h += -9.8f * Time.deltaTime;//不在地面上 
        }



        movement.y = h;
        //charater controller.Move(movement）;
        cc.Move(movement);//总移动语句
        x = this.transform.position.x;
        z = this.transform.position.z;
        nowRotation = mht.transform.rotation.eulerAngles;
        r = nowRotation.y * 3.14159f / 180;

        if (hp <= 0)
        {
            death();
        }

    }



    void death()
    {
        Instantiate(deathPar, this.transform.position, new Quaternion(0, 0, 0, 0));
        Destroy(this.gameObject);
    }

    //public void fire()
    //{
    //    Debug.Log("fire" + count01++);
    //    nowRotation = mht.transform.rotation.eulerAngles;
    //    FireballPool.initialiseFireBall(this.transform.position.x, this.transform.position.z, nowRotation.y * 3.14159f / 180);
    //    fbPool.SendMessage("fire");
    //}
    public void fire()
    {
        {
            //Debug.Log("fire" + count01++);
            Vector3 ls = new Vector3(x, z, r);
            Instantiate(fball, ls, new Quaternion(0, 0, 0, 0));
            //lsObj.SendMessage("initialiseFireBall", ls);
        }
    }
    void hasDamage()//被打
    {
        mhtFSM = 5;
        anim.SetBool("move", true);
        lstime2 = 0;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("mhmForPlayer"))
        {
            call.SetActive(true);
            hp -= 1;
            hasDamage();
        }
        if (other.tag.Equals("call") && mhtFSM != 2)
        {
            hasDamage();
        }

    }





}
