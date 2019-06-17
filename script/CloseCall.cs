using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloseCall : MonoBehaviour
{
    int i = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (i++ > 5)
        {
            i = 0;
            this.gameObject.SetActive(false);
        }
    }
}
