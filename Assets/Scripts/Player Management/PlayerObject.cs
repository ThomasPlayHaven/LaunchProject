using UnityEngine;
using System.Collections;

public class PlayerObject : MonoBehaviour {

	[SerializeField]
	private float pitch;
	public float Pitch
	{
		get { return pitch;}
		set { pitch = value;}
	}

	[SerializeField]
	private float yaw;
	public float Yaw
	{
		get{ return yaw;}
		set{ yaw = value;}
	}

	private float roll;
	public float Roll
	{
		get{ return roll;}
		set{ roll = value;}
	}

	[SerializeField]
	private Vector3 launchVector;
	public Vector3 LaunchVector
	{
		get{ return launchVector;}
		set{ launchVector = value;}
	}

	private GameObject ourLauncher; 
	//ourPlayer = ourLauncher.GetComponent<PlayerObject>();


	// Use this for initialization
	void Start () 
	{
		yaw = this.gameObject.transform.eulerAngles.x;
		pitch = this.gameObject.transform.eulerAngles.z;
		roll = this.gameObject.transform.eulerAngles.y;
		ourLauncher = GameObject.Find("Launcher");
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		launchVector = ourLauncher.transform.up;
	}

	public void updateRotation()
	{
		this.gameObject.transform.Rotate(Yaw,Roll,Pitch);
	}


}
