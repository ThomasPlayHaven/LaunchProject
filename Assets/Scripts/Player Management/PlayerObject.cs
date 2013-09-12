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


	// Use this for initialization
	void Start () 
	{
		yaw = this.gameObject.transform.eulerAngles.x;
		pitch = this.gameObject.transform.eulerAngles.z;
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.gameObject.transform.Rotate(Yaw,0,Pitch);
		Yaw += 1;
		Pitch -=1;
	}


}
