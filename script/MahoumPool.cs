using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahoumPool : MonoBehaviour {
    private ArrayList mhmDictionary01 = new ArrayList();
    private int i;
    public GameObject mhm01;
    public static int mhmPoolUse01;
    private int inMhmPoolUse01;
    private GameObject playerOBJ;
    public static int outMakeMhm;
    // Use this for initialization
    void Start () {
		for(i = 0; i < 5; i++)
        {
            GameObject lsObj = GameObject.Instantiate(mhm01);
            lsObj.transform.parent = this.transform;
            lsObj.SetActive(false);
            mhmDictionary01.Add(lsObj);
        }
        playerOBJ = GameObject.FindGameObjectWithTag("mhm01");
        inMhmPoolUse01 = 0;
	}
	
	// Update is called once per frame
	void Update () {
        mhmPoolUse01 = inMhmPoolUse01;
        if (outMakeMhm ==1)
        {
            makeMahom01();
            outMakeMhm = 0;
        }
	}


    public bool makeMahom01()
    {
        if (inMhmPoolUse01 < 5)
        {
            int i;
            i = 2;
            GameObject lsObj = (GameObject)mhmDictionary01[i];
            inMhmPoolUse01++;
            lsObj.transform.position = playerOBJ.transform.position;
            lsObj.SetActive(true);
            if (inMhmPoolUse01 > 5)//检测机制
            {
                Debug.Log("-----mahoum01生成数量超过上限");
            }
            return true;
        }

        if (inMhmPoolUse01 > 5)//检测机制
        {
            Debug.Log("-----mahoum01生成数量超过上限");
        }
        return false;
    }


}
