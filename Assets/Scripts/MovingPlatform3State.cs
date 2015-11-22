using UnityEngine;
using System.Collections;

public class MovingPlatform3State : MonoBehaviour
{
    //the platform that moves between states
    public Transform movingPlatform;
    //states
    public Transform position1;
    public Transform position2;
    public Transform position3;
    public Vector3 newPosition;
    //states defined by String, enum might be a safer option later
    public string currentState;
    //speed
    public float smooth;
    //how often to change states
    public float resetTime;

    // Use this for initialization
    void Start()
    {
        ChangeTarget();
    }

    // Update is called once per frame, to move the platform back and fourth
    void FixedUpdate()
    {
        movingPlatform.position = Vector3.Lerp(movingPlatform.position, newPosition, smooth * Time.deltaTime);
    }
    //ChangeTarget method checks what current state is and updates current state after the 
    //reset time is reached
    void ChangeTarget()
    {
        //Debug.log(currentState);
        if (currentState == "Moving To Position 1")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        else if (currentState == "Moving To Position 2")
        {
            currentState = "Moving To Position 3";
            newPosition = position3.position;
        }
        else if (currentState == "Moving To Position 3")
        {
            currentState = "Moving To Position 1";
            newPosition = position1.position;
        }
        else if (currentState == "")
        {
            currentState = "Moving To Position 2";
            newPosition = position2.position;
        }
        Invoke("ChangeTarget", resetTime);
    }
}
