using UnityEngine;
using System.Collections;

public class GuiManager : MonoBehaviour {


	public GameObject defaultObject;
	public GameObject ourLauncher;
	public PlayerObject ourPlayer;
	public LevelManager ourLevelManager;

	[SerializeField]
	private int _score = 0;

	public int Score
	{
		get
		{
			return _score;
		}
		set
		{
			_score = value;
		}
	}

		// Use this for initialization
	void Start () 
	{
		ourLauncher = GameObject.Find("LaunchContainer");
		ourPlayer = ourLauncher.GetComponent<PlayerObject>();
		defaultObject = GameObject.Find("LevelHandler");
		ourLevelManager = defaultObject.GetComponent<LevelManager>();
	}

	void OnGUI()
	{
		ourPlayer.Yaw = 0;
		ourPlayer.Pitch = 0;


		if (GUI.RepeatButton(new Rect(10, 10, 100, 30), "Down"))
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
		if (GUI.RepeatButton(new Rect(10, 50, 100, 30), "Up"))
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

		if(GUI.Button(new Rect(10, 130, 50, 50), "1"))
		{
			ourLevelManager.load(1);
		}
		if(GUI.Button(new Rect(70, 130, 50, 50), "2"))
		{
			ourLevelManager.load(2);
		}

		
		GUI.Box(new Rect(270,10,100,30),"");
		GUI.Label(new Rect(285,15,80,30),"Score: " + Score);

	}


	
	// Update is called once per frame
	void Update () {
	
	}

	void OnDrawGizmos()
	{
		Gizmos.color = Color.yellow;
		Gizmos.DrawRay(ourLauncher.transform.position, ourPlayer.LaunchVector *3);
	}
}
