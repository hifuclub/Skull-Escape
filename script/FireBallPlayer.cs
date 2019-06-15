using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBallPlayer : MonoBehaviour {
    private float vRos;
    private float posX, posZ;
    public float speed = 1.5f;
    private int moveCount = 0;
    public int num;
    //private int lsLate;
    private bool isTg = false;
    private bool isInitialiseFireBall = false;
    public GameObject mht;
    private bool isIN;
    int i;
    bool isTr;
    public Quaternion nowRotationQuaternion;

    // Use this for initialization
    void Start () {
        moveCount = 0;
        posX = this.transform.position.x;
        posZ = this.transform.position.y;
        vRos = this.transform.position.z;
        this.transform.position = new Vector3(posX, 7.81f, posZ);
        nowRotationQuaternion = this.transform.rotation;
        //this.transform.rotation = Quaternion.Euler(0, vRos, 0);


    }

    // Update is called once per frame
    void FixedUpdate() {



        moveCount++;

        this.transform.position -= this.transform.forward * speed;

        //Debug.Log(posX);
        //Debug.Log(-Mathf.Sin(vRos) * moveCount * speed);
        if (moveCount > 10 * 60)
        {
            closeFB();
        }



    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("mhm01") && (!isTr))
        {
            isTr = true;
            Destroy(this.gameObject.GetComponent<BoxCollider>());
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
