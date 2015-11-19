using UnityEngine;
using System.Collections;

public class PlayerDeathBySpikes : MonoBehaviour {
    //If the player comes into contact with the spikes, he/she will automatically die
    //we can change the effect later if this is too harsh to just losing dmg
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Application.LoadLevel("Demo Scene");
        }
    }
}
