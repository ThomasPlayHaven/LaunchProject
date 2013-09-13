using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {

	void OnGUI()
	{
		GameObject ourLauncher = GameObject.Find("Launcher");
		PlayerObject ourPlayer = ourLauncher.GetComponent<PlayerObject>();

		if (GUI.Button(new Rect(10, 10, 100, 30), "Up"))
		{
			
			ourPlayer.Pitch =10;
			ourPlayer.updateRotation();
			//ourLauncher.Pitch += 1;
		}
		if (GUI.Button(new Rect(10, 50, 100, 30), "Down"))
		{
			ourPlayer.Pitch =-10;
			ourPlayer.updateRotation();
		}

		if (GUI.Button(new Rect(10, 90, 100, 30), "Fire"))
		{
			GameObject ourThrowableObject = GameObject.Find("Sphere");
			Vector3 supertest = new Vector3(0,1000,0);
			ourThrowableObject.rigidbody.AddForce(supertest + ourPlayer.LaunchVector);
			//PlayerObject ourThrownObject = ourLauncher.GetComponent<PlayerObject>();
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
