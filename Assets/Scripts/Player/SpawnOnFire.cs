using System;
using UnityEngine;
using UniRx;

public class SpawnOnFire : MonoBehaviour {

	public GameObject spawnedObject;

	public Transform spawnPoint;

	public float throttle;

	public string buttonName;

	void Start () {
		Observable.EveryUpdate()
			.Where(_ => Input.GetButton(buttonName))
			.ThrottleFirst(TimeSpan.FromSeconds(throttle))
			.Subscribe(_ => {
				Instantiate(spawnedObject, spawnPoint.position, spawnPoint.rotation);
				GetComponent<AudioSource>().Play();
			});
	}
}
