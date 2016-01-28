using UnityEngine;
using System.Collections;

public class GUIScript : MonoBehaviour {
  

	// Use this for initialization
	void Start () {
        CardboardOnGUI.onGUICallback += this.OnGUI;
    }
	
	// Update is called once per frame
	void Update () {
    }

    void OnGUI()
    {
     //   if (!CardboardOnGUI.OKToDraw(this)) return;
        GUI.Label(new Rect(10, 10, 250, 100), "Texto");
    }
}
