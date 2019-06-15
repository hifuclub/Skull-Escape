using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunCard : MonoBehaviour {
    public Vector3 posForTest;
    /// 302 452 602 752
    public bool isText;
    Vector3 pos;
    public static float posX;
    float xLerp;
    public float speed = 0.15f;

    // Use this for initialization
    void Start () {
        posForTest = this.gameObject.transform.position;
        pos = this.gameObject.transform.position;
        isText = false;
        posX = pos.x;
        xLerp = pos.x;
    }
	
	// Update is called once per frame
	void Update () {
        xLerp = Mathf.Lerp(xLerp, posX,speed);
        pos.x = xLerp;
        if (isText)
        {
            pos = posForTest;
        }
        this.gameObject.transform.position = pos;
    }
}
