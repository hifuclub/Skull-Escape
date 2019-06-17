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

    public ParticleSystem particleSystem01;
    public ParticleSystem particleSystem02;
    ParticleSystem.MinMaxCurve emission01;
    ParticleSystem.MinMaxCurve emission02;

    public GameObject last;
    public GameObject del;
    bool isDel;

    private void Awake()
    {
        
        emission01 = particleSystem01.emission.rateOverTime;
        emission02 = particleSystem02.emission.rateOverTime;
    }

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
        if (moveCount > 1.2f * 60)
        {
            closeFB();
        }
        //火球变弱
        //Debug.Log(8 * (1 - moveCount / (1.2f * 60)));
        float tempF01 = 30 * (1 - moveCount / (1.2f * 60));
        if (tempF01 < 0) tempF01 = 0;
        emission01 = tempF01;
        emission02 = tempF01;


    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("mhm01") || other.tag.Equals("building") && (!isTr))
        {
            Debug.Log(other);

            isTr = true;
            closeFB();
        }
    }



    void closeFB()
    {
        //Debug.Log("close=====================");
        //last.transform.SetParent(this.transform);
        last.SetActive(true);
        Destroy(del.gameObject);
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
