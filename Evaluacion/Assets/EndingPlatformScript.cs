using UnityEngine;
using System.Collections;

public class EndingPlatformScript : MonoBehaviour {
    private bool playerArrived;
    public bool deadPlatform;

    // Use this for initialization
    void Start () {
        playerArrived = false;
	}
	
	// Update is called once per frame
	void Update () { 
        
 
	}
    void OnTriggerEnter(Collider other)
    {
        playerArrived = true;
        if (deadPlatform)
            ControllerSphere.dead = true;
        else
            ControllerSphere.dead = false;
        Application.LoadLevel("EscenaPuntuacion");
    }
    public bool playerTouchedPlatform()
    {
        return playerArrived;
    }
}
