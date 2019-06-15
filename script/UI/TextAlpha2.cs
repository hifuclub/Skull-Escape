using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAlpha2 : MonoBehaviour {
    public Text t;
    Color color01 = new Color(0,0,0,0);
    float alpha;
    float i = 0;
    float j = 0;
    public float delay = 300;
    public float speed = 1;

    public float lsShow;
    bool isStart = true;


    // Use this for initialization
    void Start () {
        i = 0;
        t.color = color01;
    }
	
	// Update is called once per frame
	void Update () {
        if (isStart)
        {
            lsShow = color01.a;
            if (j++ > delay)
            {
                color01 = t.color;

                color01.a += (i++ / 15000 * speed);
                t.color = color01;

                if (i > 190 / speed)
                {
                    isStart = false;
                }


            }
        }

    }
}
