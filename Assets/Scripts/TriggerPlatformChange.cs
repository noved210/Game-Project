using UnityEngine;
using System.Collections;

public class TriggerPlatformChange : MonoBehaviour {
    public float triggerTime = 10;
    public GameObject platform1;
    public GameObject platform2;
    public GameObject platform3;


    protected float startTime;
    private bool uniqInstance = false;

    void OnTriggerEnter(Collider other)
    {
        //Debug.log("hellotesting123");
        if (other.gameObject.tag == "Player" && uniqInstance == false)
        {
            startTime = Time.time;
            uniqInstance = true;
            platform1.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
            platform2.transform.Translate(new Vector3(0.0f, -5.0f, 0.0f));
            platform3.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
        }
    }
    void Update()
    {
        if ((Time.time - startTime) > triggerTime && uniqInstance== true)
        {
            uniqInstance = false;
            platform1.transform.Translate(new Vector3(0.0f, -5.0f, 0.0f));
            platform2.transform.Translate(new Vector3(0.0f, 5.0f, 0.0f));
            platform3.transform.Translate(new Vector3(0.0f, -5.0f, 0.0f));
        }
        else
        {
            //Debug.log((Time.time - startTime));
        }
    }
}
