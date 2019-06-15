using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MahoumPlayer01 : MonoBehaviour
{
    Transform player;
    Transform mhmTransform;
    public GameObject de;
    int deTime;
    Vector3 mhm01;
    bool isTr;
    int i;
    public int mhmLife = 15 * 60;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        mhmTransform = this.gameObject.transform;

        mhm01.y = 0;
        mhm01.x = player.position.x;
        mhm01.z = player.position.z;

        this.gameObject.transform.position = mhm01;
        i = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (i++ > mhmLife)
        {
            Destroy(this.gameObject);
        }

        if (isTr)
        {
            de.SetActive(true);
            if (deTime++ > 180)
            {
                Destroy(this.gameObject);
            }
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag.Equals("mhm01")&&(!isTr))
        {
            isTr = true;
            Destroy(this.gameObject.GetComponent<BoxCollider>());
        }
    }


}
