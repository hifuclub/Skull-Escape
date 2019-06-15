using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall01 : MonoBehaviour {
    public static float vRos;
    public static float posX, posZ;
    public float speed = 0.5f;
    private static int moveCount = 0;
    public int num;
    //private int lsLate;
    private static bool isTg = false;
    static bool isInitialiseFireBall = false;
    public GameObject fbPool;
    public static bool isIN;
    
    // Use this for initialization
    void Start () {
        isInitialiseFireBall = false;
        //fbPool = GameObject.Find("fireballDictionary");
    }
	
	// Update is called once per frame
	void FixedUpdate() {

        if (isInitialiseFireBall)
        {
            moveCount++;

            this.transform.position = new Vector3(posX - (Mathf.Sin(vRos) * moveCount * speed), this.transform.position.y, posZ - (Mathf.Cos(vRos) * moveCount) * speed);
            //Debug.Log(posX);
            //Debug.Log(-Mathf.Sin(vRos) * moveCount * speed);
            if (moveCount > 10 * 60)
            {
                reclaim();
            }
        }
        if (isIN)
        {
            isIN = false;
            initialiseFireBall();
        }


    }
    public void initialiseFireBall()//按照魔法师位置初始化坐标
    {
        if (!isInitialiseFireBall)
        {

            posX = FireballPool.x;
            posZ = FireballPool.z;
            vRos = FireballPool.r;
            isInitialiseFireBall = true;
            moveCount = 0;
        }

    }

    public void ReceiveFireBall(string n)//入池时得到序号
    {
        num = int.Parse(n);
    }
    void reclaim()
    {
        posX = 0;
        posZ = 0;
        isInitialiseFireBall = false;
        moveCount = 0;
        fbPool.SendMessage("ReclaimFireBall", num.ToString());
        //Debug.Log("0000000000");
        closeFB();
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((!other.tag.Equals("mhm01"))&& isInitialiseFireBall && !isTg)
        {
            isTg = true;
            isInitialiseFireBall = false;
            Debug.Log(other.tag);
            reclaim();
            closeFB();
        }
    }
    public void isInTrue()
    {
        isIN = true;
    }
     void closeFB()
    {
        this.gameObject.SetActive(false);
    }
    public void SetActive(bool b)
    {
        this.gameObject.SetActive(b);
    }
}
