using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahoutPos : MonoBehaviour {
    public static Vector3 mhtPos;
    public Vector3 mhtPosshow;
    // Use this for initialization
    void Start () {
        mhtPos = this.transform.position;
        mhtPosshow = mhtPos;

    }
	
}
