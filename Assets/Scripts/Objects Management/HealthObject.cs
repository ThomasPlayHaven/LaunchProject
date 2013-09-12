using UnityEngine;
using System.Collections;

public class HealthObject : MonoBehaviour {

	public int ourHealth = 100;




	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		ourHealth -= (int)collision.relativeVelocity.magnitude;
		if(ourHealth <= 0)
		{
			//add stuff later
			Destroy(this.gameObject);
		}
	}
}
