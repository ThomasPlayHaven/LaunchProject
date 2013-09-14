using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {

	public GameObject ourLauncher;
	public PlayerObject ourPlayer;

		// Use this for initialization
	void Start () 
	{
		ourLauncher = GameObject.Find("LaunchContainer");
		ourPlayer = ourLauncher.GetComponent<PlayerObject>();
	}

	void OnGUI()
	{


		if (GUI.RepeatButton(new Rect(10, 10, 100, 30), "Up"))
		{
			
			ourPlayer.Pitch =0.5f;
			ourPlayer.updateRotation();
			//ourLauncher.Pitch += 1;
		}
		if (GUI.RepeatButton(new Rect(140, 10, 100, 30), "Left"))
		{
			
			ourPlayer.Yaw =-0.5f;
			ourPlayer.updateRotation();
			//ourLauncher.Pitch += 1;
		}
		if (GUI.RepeatButton(new Rect(10, 50, 100, 30), "Down"))
		{
			ourPlayer.Pitch =-0.5f;
			ourPlayer.updateRotation();
		}
		if (GUI.RepeatButton(new Rect(140, 50, 100, 30), "Right"))
		{
			ourPlayer.Yaw =0.5f;
			ourPlayer.updateRotation();
		}

		if (GUI.Button(new Rect(10, 90, 100, 30), "Fire"))
		{
			GameObject ourThrowableObject = GameObject.Find("Sphere");
			ourThrowableObject.transform.position = ourLauncher.transform.position + ourPlayer.LaunchVector * 2;
			//Vector3 supertest = new Vector3(0,1000,0);
			ourThrowableObject.rigidbody.velocity = Vector3.zero;
			ourThrowableObject.rigidbody.AddForce(ourPlayer.LaunchVector * 1000);
			//PlayerObject ourThrownObject = ourLauncher.GetComponent<PlayerObject>();
		}
	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(ourLauncher.transform.position, ourPlayer.LaunchVector);
	}
}
