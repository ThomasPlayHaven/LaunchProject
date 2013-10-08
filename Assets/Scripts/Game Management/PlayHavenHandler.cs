using UnityEngine;
using System.Collections;
using PlayHaven;

public class PlayHavenHandler : MonoBehaviour 
{

	//public event RewardTriggerHandler OnRewardGiven;

	//public delegate void RewardTriggerHandler(EventArgs e,PlayHaven.Reward reward);

	public void Awake()
	{
		//Creates the reward event
		//PlayHavenManager.instance.OnRewardGiven += OnPlayHavenRewardGiven; 
		PlayHavenManager.instance.OnPurchasePresented += OnPlayHavenPurchase;
	}

	public void OnDestroy()
	{
		//Destroys the reward event
		//PlayHavenManager.instance.OnRewardGiven -= OnPlayHavenRewardGiven; 
		PlayHavenManager.instance.OnPurchasePresented -= OnPlayHavenPurchase;
	}

	public void callContent(string placementName)
	{
		PlayHaven.PlayHavenManager.instance.ContentRequest(placementName);
	}

	public void doOpen()
	{
		PlayHaven.PlayHavenManager.instance.OpenNotification();
		Debug.Log("Finished doing an Open");
	}

	//Should handle all reward stuff
	public void OnPlayHavenRewardGiven(int id,PlayHaven.Reward reward)
	{
  		Debug.Log("Reward recieved: " + reward.name);
	}

	//Function that gets called when a playhaven purchase is made
	public void OnPlayHavenPurchase(int requestId, PlayHaven.Purchase purchase)
	{

	}

	public void BuyProduct(string product_id, int quantity)
	{
		PlayHaven.PurchaseResolution ourResolution = PlayHaven.PurchaseResolution.Buy;

		PlayHaven.Purchase ourPurchase = new PlayHaven.Purchase();

		ourPurchase.productIdentifier = product_id;
		//ourPurchase.resolution = ourResolution;

		PlayHavenManager.instance.ProductPurchaseTrackingRequest(ourPurchase,ourResolution);
	}
}
