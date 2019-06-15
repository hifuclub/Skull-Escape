using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBall02 : MonoBehaviour {
    private float vRos;
    private float posX, posZ;
    public float speed = 0.5f;
    private int moveCount = 0;
    public int num;
    //private int lsLate;
    private bool isTg = false;
    private bool isInitialiseFireBall = false;
    public GameObject mht;
    private bool isIN;
    int i;
    
    // Use this for initialization
    void Start () {
        moveCount = 0;
        posX = this.transform.position.x;
        posZ = this.transform.position.y;
        vRos = this.transform.position.z;
        speed = 1;
    }
	
	// Update is called once per frame
	void FixedUpdate() {



        moveCount++;

        this.transform.position = new Vector3(posX - (Mathf.Sin(vRos) * moveCount * speed), 7.81f, posZ - (Mathf.Cos(vRos) * moveCount) * speed);
        //Debug.Log(posX);
        //Debug.Log(-Mathf.Sin(vRos) * moveCount * speed);
        if (moveCount > 10 * 60)
        {
            closeFB();
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        if ((!other.tag.Equals("mhmForPlayer")))
        {
            if ((!other.tag.Equals("mhm01")) && (!other.tag.Equals("Untagged")) && (!isTg))
            {
                isTg = true;
                Debug.Log(other.tag);

                if (other.tag == Tags.player)
                {
                    PlayerMove.heathPoint -= 30;
                    PlayerMove.heathCD = 0;
                    PlayerMove.isHurt = true;
                }


                Destroy(this.gameObject);
            }
        }

    }

     void closeFB()
    {
        //Debug.Log("close=====================");
        Destroy(this.gameObject);
        
    }
    //public void initialiseFireBall(Vector3 ls)//初始化
    //{
    //    if (!isIN)
    //    {
    //posX = ls.x;
    //        posZ = ls.y;
    //        vRos = ls.z;
    //        isIN = true;
    //    }
    //    Debug.Log(i++);

    //}
}
