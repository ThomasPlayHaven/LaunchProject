using UnityEngine;
using System.Collections;

public class TitleGuiManager : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI()
	{
		GUI.Box(new Rect(Screen.width /2 - 100,10,200,30),"Game Title Goes Here");

		if (GUI.Button(new Rect(Screen.width / 2 - 25, Screen.height / 2, 50, 50), "Play"))
		{
			Application.LoadLevel("GameScene");
		}
	}
}
