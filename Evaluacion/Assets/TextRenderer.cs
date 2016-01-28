using UnityEngine;
using System.Collections;

public class TextRenderer : MonoBehaviour {
    public int seconds;
    public int minutes;
    public TextMesh textMesh;

	// Use this for initialization
	void Start () {
        minutes = (int)ControllerSphere.seconds / 60;
        seconds = (int)ControllerSphere.seconds % 60;
    }
	
	// Update is called once per frame
	void Update () {
        if (ControllerSphere.dead)
            textMesh.text = "Game Over";
        else
            textMesh.text = "Tiempo: " + minutes + ":" + seconds;
	}
}
