using UnityEngine;
using System.Collections;

public class HealthObject : MonoBehaviour {

	public int ourHealth = 100;

	GuiManager manager;


	// Use this for initialization
	void Start () 
	{
		//Set up to report score.
		GameObject gm = GameObject.Find("GraphicsManager");
		if(gm != null)
			manager = gm.GetComponent<GuiManager>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		int damage = (int)collision.relativeVelocity.magnitude;
		ourHealth -= damage;
		manager.Score += damage;
		
		if(ourHealth <= 0)
		{
			//add stuff later
			Destroy(this.gameObject);
		}
	}
}
