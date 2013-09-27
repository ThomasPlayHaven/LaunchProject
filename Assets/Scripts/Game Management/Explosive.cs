using UnityEngine;
using System.Collections;

public class Explosive : MonoBehaviour 
{
	
	[SerializeField]
	private float radius = 15f;
	[SerializeField]
	private float damage = 5f;
	[SerializeField]
	private float force = 10f;
	[SerializeField]
	private bool primed = true;
	[SerializeField]
	private float upDistance = 0.2f;
	[SerializeField]
	private ForceMode forceMode = ForceMode.Impulse;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Explode()
	{
		Debug.Log("Exploding");
		Collider[] victims = Physics.OverlapSphere(this.gameObject.transform.position, radius);
		
		foreach(Collider c in victims)
		{
			Debug.Log("Potential victim - " + c.gameObject.name);
			//apply force to all objects that are not this object, and have rigidbodies.
			if(c.gameObject != this.gameObject && c.rigidbody != null)
			{
				Debug.Log("Hitting victim");
				c.rigidbody.AddExplosionForce(force, this.transform.position, Vector3.Distance(this.transform.position, c.transform.position), upDistance, forceMode);
			}
		}
	}
	
	void OnCollisionEnter(Collision col)
	{
		//Only explode on objects that can be hurt, and if we're primed
		if(primed && col.collider.GetComponent<HealthObject>() != null)
		{
			primed = false;
			Explode();
		}
	}
	
	void OnGUI()
	{
		if(GUI.Button(new Rect(0, 200, 100, 50), "PRIME"))
			primed = true;
	}
}
