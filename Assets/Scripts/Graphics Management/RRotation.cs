using UnityEngine;
using System.Collections;

///
//This class really should be call, title screen dropper but whatever.
///
public class RRotation : MonoBehaviour {

	[SerializeField]
	private float dropSpeed;

	public float DropSpeed
	{
		get
		{
			return dropSpeed;
		}
	}

	[SerializeField]
	private int _type = 0;

	public int Type
	{
		get
		{
		 return _type;
		}
		set
		{
		 _type = value;
		}
	}

	private float ourRan = 0f;

	// Use this for initialization
	void Start () {

		Random.seed = (int)(Random.value * 897153249572);
		calculateDropSpeed();

	
	}
	
	// Update is called once per frame
	void Update () 
	{
			
			this.transform.Rotate(ourRan,ourRan,ourRan);
			this.transform.localPosition = this.transform.localPosition + new Vector3(0,-dropSpeed,0);

			if(this.transform.localPosition.y < 100)
			{
				calculateDropSpeed();
				this.transform.localPosition = new Vector3((int)(Random.Range(6.4f,8.0f) * -10),127,(int)(Random.Range(3.0f,5.0f) * 10));
			}

	}

	void calculateDropSpeed()
	{
		if(Type == 0)
		{
			dropSpeed = (Random.Range(0.01f,0.10f));
		}
		else if(Type == 1)
		{
			dropSpeed = (Random.Range(0.05f,0.15f));
		}
		else if(Type == 2)
		{
			dropSpeed = (Random.Range(0.10f,0.20f));
		}

		ourRan = Random.value;	
	}
}
