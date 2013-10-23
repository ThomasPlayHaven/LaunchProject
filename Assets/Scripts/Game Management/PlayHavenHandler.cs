using UnityEngine;
using System;
using System.Collections;
using PlayHaven;

public class PlayHavenHandler : MonoBehaviour 
{

	//public event RewardTriggerHandler OnRewardGiven;

	//public delegate void RewardTriggerHandler(EventArgs e,PlayHaven.Reward reward);

	public void Awake()
	{
		//Creates the reward event
		PlayHavenManager.instance.OnRewardGiven += OnPlayHavenRewardGiven; 
		PlayHavenManager.instance.OnPurchasePresented += OnPlayHavenPurchase;
		//PlayHavenManager.instance.OptOutStatus = true;
	}

	public void OnDestroy()
	{
		//Destroys the reward event
		PlayHavenManager.instance.OnRewardGiven -= OnPlayHavenRewardGiven; 
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
		Debug.Log("Buy Product ProductID: " + product_id + " With a quantity of: " + quantity);
		try
		{
			PlayHaven.PurchaseResolution ourResolution = PlayHaven.PurchaseResolution.Buy;

			PlayHaven.Purchase ourPurchase = new PlayHaven.Purchase();

			ourPurchase.productIdentifier = product_id;
			//ourPurchase.resolution = ourResolution;

			PlayHavenManager.instance.ProductPurchaseTrackingRequest(ourPurchase,ourResolution);
		}
		catch (Exception ex)
		{
			Debug.Log("An Exception was caught with: " + ex.Message);
		}
		Debug.Log("Buy Finished");
	}
}
