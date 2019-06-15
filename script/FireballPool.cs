using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireballPool : MonoBehaviour {
    public GameObject fb01;

    private ArrayList fbDictionary01 = new ArrayList();
    private int i;
    public static float x, z, r;
    private static bool isFire;
    private bool[] objCount = new bool[10];
    public static bool isReclaimFireBall;
    // Use this for initialization
    void Start () {
        for (i = 0; i < 10; i++)//装弹入池
        {
            GameObject lsObj = GameObject.Instantiate(fb01);
            fbDictionary01.Add(lsObj);
            lsObj.SendMessage("ReceiveFireBall", i.ToString());
            lsObj.transform.parent = this.transform;
            lsObj.SetActive(false);
            objCount[i] = false;


        }
        

    }
	
	// Update is called once per frame
	void Update () {

    }
    public void ReclaimFireBall(string n)
    {
        int reclaimFireBall = int.Parse(n);
        objCount[reclaimFireBall] = false;
        //Debug.Log(reclaimFireBall);
    }

    public static void initialiseFireBall(float getx,float getz, float getr)//初始化
    {
        x = getx;
        z = getz;
        r = getr;
        
    }
    public void fire()
    {
        for (i = 0; i < 10; i++)
        {
            if (!objCount[i])
            {
                objCount[i] = true;
                GameObject lsObj = (GameObject)fbDictionary01[i];
                lsObj.SetActive(true);
                //lsObj.isIN
                break;
            }
        }
    }

    
}
