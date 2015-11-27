using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "break")
        {
            Destroy(col.gameObject);
        }
    }
}
