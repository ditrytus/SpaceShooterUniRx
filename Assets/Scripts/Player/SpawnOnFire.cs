using System;
using UnityEngine;
using UniRx;

public class SpawnOnFire : RxBehaviour {

	public GameObject spawnedObject;

	public Transform spawnPoint;

	public float throttle;

	public string buttonName;

	void Start () {
		var sub1 = Observable.EveryUpdate()
			.Where(_ => Input.GetButton(buttonName))
			.ThrottleFirst(TimeSpan.FromSeconds(throttle))
			.Subscribe(_ => {
				Instantiate(spawnedObject, spawnPoint.position, spawnPoint.rotation);
				GetComponent<AudioSource>().Play();
			});
		
		AddSubscriptions(sub1);
	}
}
