using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMove : MonoBehaviour
{
    private float x, z, r;
    private CharacterController cc;
    public float speed = 20;
    Vector3 targetDir;
    public Vector3 targetDir01;
    public Quaternion q;
    GameObject myplayer;
    public Vector3 nowRotation;
    public static float nowRotY;
    public Quaternion nowRotationQuaternion;
    public GameObject fball;

    public static float h, v, rChange;
    int isrotate = 0;
    Animator anim;
    public GameObject mahoum;
    //public GameObject mhm01;
    public int mhmCD;
    public Image mhmCDimg;
    public bool ismhm1;
    private bool isMakeMhm;

    public static float heathPoint = 100;
    public static bool isHurt;
    public static int heathCD;
    public static bool isDeath = false;

    public GameObject deathCan;
    public GameObject deathBody;
    public GameObject deathPar;
    bool isDeathPar = false;

    float iFire;

    void Awake()
    {

        cc = this.GetComponent<CharacterController>();
        myplayer = this.gameObject;
        anim = this.GetComponent<Animator>();
        mahoum.transform.localScale = new Vector3(0.09f, 0.0001f, 0.09f);
        //ismhm1 = true;
        mhmCD = 0;
        isMakeMhm = false;

    }
    void Update()
    {
        x = transform.position.x;
        z = transform.position.z;
        r = transform.rotation.y;

        mahoum.SetActive(ismhm1);
        anim.SetBool("mahou", ismhm1);
        if (ismhm1 && Mahoum.isStart == false)
        {
            Mahoum.isStart = true;////手部魔法阵

        }
        if (ismhm1)
        {
            mhmCDimg.fillAmount = 1 - iFire / (2 * 60);
            if (mhmCD++ > 20)
            {
                //ismhm1 = false;
                mhmCD = 0;
                isMakeMhm = true;
            }
            if (isMakeMhm && iFire++ > 2 * 60)//开火
            {
                
                iFire = 0;
                fire();
            }
        }
        if (!ismhm1)
        {
            mhmCDimg.fillAmount = 0;

            #region 转身机制
            if (v != 0)
            {
                if (h > 0.01 && isrotate == 0)
                {
                    targetDir01.y += 2f * rChange;
                }
                if (h < -0.01 && isrotate == 0)
                {
                    targetDir01.y += 2f * rChange;
                }
                if (h > 0.99 && isrotate == 1)
                {
                    targetDir01.y -= 2f * rChange;
                }
                if (h < -0.99 && isrotate == 1)
                {
                    targetDir01.y -= 2f * rChange;
                }
                if (h == 0)
                {
                    isrotate = 0;
                }
                else if (h == 1 || h == -1)
                {
                    isrotate = 1;
                }
            }
            transform.rotation = Quaternion.Euler(targetDir01);

            #endregion
            //if (isMakeMhm)
            //{
            //    Vector3 ls = new Vector3(this.transform.position.x, 0, this.transform.position.z);
            //    isMakeMhm = false;
            //    //Instantiate(mhm01);
            //    Mahoum.isStart = true;////手部魔法阵

            //}

            #region 移动机制
            nowRotationQuaternion = myplayer.transform.rotation;
            nowRotation = myplayer.transform.rotation.eulerAngles;
            nowRotY = nowRotation.y;
            //h = Input.GetAxis("Horizontal");
            //v = Input.GetAxis("Vertical");
            if (v != 0)
            {
                anim.SetBool("move", true);
            }
            else
            {
                anim.SetBool("move", false);
            }
            cc.SimpleMove(new Vector3(-Mathf.Sin(nowRotation.y * 3.14159f / 180), 0, -Mathf.Cos(nowRotation.y * 3.14159f / 180)) * speed * v);

            #endregion


            h = 0;
            v = 0;

            if (isHurt && !isDeath)
            {
                if (heathCD++ > 10 * 60)
                {
                    isHurt = false;
                }
            }
            if (!isHurt && heathPoint < 100 && !isDeath)
            {
                heathPoint += heathPoint * Time.deltaTime * 0.2f;
            }
            if (heathPoint > 100)
            {
                heathPoint = 100;
            }
            if (heathPoint <= 0)
            {
                isDeath = true;
                heathPoint = 0;
            }
            if (isDeath)
            {
                deathCan.SetActive(true);
                deathBody.SetActive(false);

            }
            if (isDeath && (!isDeathPar))
            {
                Instantiate(deathPar, this.transform.position, new Quaternion(0, 0, 0, 0));//死亡特效
                isDeathPar = true;
            }
        }

        #region 报废代码
        //if (Mathf.Abs(h) > 0.1 || Mathf.Abs(v) > 0.1)

        //    targetDir = new Vector3(-v, 0, h);

        //targetDir01.y = transform.rotation.y;

        //transform.position = (nowPosition + Vector3.forward * speed * v);
        #endregion



    }
    public void fire()
    {
        {
            //Debug.Log("fire" + count01++);
            Vector3 ls = new Vector3(x, z, r);
            Instantiate(fball, ls, nowRotationQuaternion);
            //lsObj.SendMessage("initialiseFireBall", ls);
        }
    }
    public void makeMhm()
    {
        ismhm1 = true;
        mhmCD = 0;
        Debug.Log("down");
    }
    public void DownFire()
    {
        ismhm1 = true;
    }
    public void UpFire()
    {
        ismhm1 = false;
        isMakeMhm = false;
        mhmCD = 0;
        iFire = 0;
    }
}