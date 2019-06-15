using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class TextAlpha : MonoBehaviour {
    public Text t;
    Color color01;
    float alpha;
    float i = 0;
    public float speed;//变化速度
    public float lowest;//保底透明度
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        color01 = t.color;
        alpha = -Mathf.Cos(i/100)*0.5f+0.5f;
        i += speed;
        if(i > 10000)
        {
            i=0;
        }
        float abs = Mathf.Abs(alpha);
        if (abs < lowest) abs = lowest;
        color01.a = abs;
        t.color = color01;

    }
    public void myDestroy()
    {
        Destroy(this.gameObject);
    }
}
