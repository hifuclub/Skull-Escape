using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour {
    private Transform player;
    public float speed;
    public Vector3 correct = new Vector3(0.3f, 24.48f, -24.33f);
    Vector3 re0;
    public float range;
    // Use this for initialization
    void Start () {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
        re0 = new Vector3(0, 20, 0);
        range = 24;
        speed = 3;

    }
	
	// Update is called once per frame
	void Update () {
        correct = new Vector3(range * 1 * Mathf.Sin(PlayerMove.nowRotY * 3.14159f / 180), 24.48f, range * Mathf.Cos((PlayerMove.nowRotY) * 3.14159f / 180));
        Vector3 taegerPos = player.position + correct;
        transform.position = Vector3.Lerp(transform.position, taegerPos, speed * Time.deltaTime);
        Quaternion targetRotation = Quaternion.LookRotation(player.position - transform.position + re0);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, speed*Time.deltaTime);
	}
    public void rangeChange(float newRange)
    {
        range = newRange;
    }
}
