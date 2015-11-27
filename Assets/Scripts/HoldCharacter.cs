using UnityEngine;
using System.Collections;

public class HoldCharacter : MonoBehaviour
{
    //When the player comes into contact with the platform trigger, it becomes a child, so it will
    //move with the platform
    void OnTriggerEnter(Collider col)
    {
        col.transform.parent = gameObject.transform;
    }
    //When the player stops contacting the platform trigger, we remove the parent-child link
    void OnTriggerExit(Collider col)
    {
        col.transform.parent = null;
    }
}
