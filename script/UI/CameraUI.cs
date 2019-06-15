using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraUI : MonoBehaviour {
    
    public float speed;
    public Vector3 correct;
    Vector3 re0;
    public int range;
    public static Vector3 targetPos;
    public static float nowRot;
    public static int cameraMode = 0;
    // Use this for initialization
    void Start () {
        re0 = new Vector3(0, 25, 0);
        range = 24;
        speed = 3;

        //////////////点击开始
        targetPos = new Vector3(0,-9,-1176);
        nowRot = 0;
    }
	
	// Update is called once per frame
	void Update () {
        targetPos.y = -9;
        correct = new Vector3(range * 1 * Mathf.Sin((nowRot+180) * 3.14159f / 180), 24.48f, range * Mathf.Cos((nowRot + 180) * 3.14159f / 180));
        Vector3 cPos = targetPos + correct;
        transform.position = Vector3.Lerp(transform.position, cPos, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(targetPos - transform.position + re0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed*Time.deltaTime);
	}

    //public void newCameraOption(ArrayList lsList)
    //{
    //    Vector3 targetPos = (Vector3)lsList[0];
    //    float nowRot = (float)lsList[1];
    //    this.targetPos = targetPos;
    //    this.nowRot = nowRot;
    //}
}
