using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mahoum : MonoBehaviour {
    GameObject mhm;
    public static float i;
    public float iShow;
    public static bool isStart;
	// Use this for initialization
	void Start () {
        mhm = this.gameObject;
        
	}
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            //if (i++ <= 15)
            //{
            //    mhm.transform.localScale = new Vector3(i / 180 * 0.1f, 0.0002f, i / 180 * 0.1f);

            //}

            mhm.transform.Rotate(0, 1, 0);
            iShow = i;
        }
        else
        {
            i = 0;
            isStart = false;
            this.gameObject.SetActive(false);
        }

    }
}
