﻿using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DestroyOnCollision : MonoBehaviour {

	public GameObject asteroidExplostion;

	public GameObject playerExplostion;

	void Start () {
		var collisions = this.OnTriggerEnterAsObservable()
			.Where(c => c.gameObject.tag != "boundary");
		
		collisions.Subscribe(c => {
			Destroy(c.gameObject);
			Destroy(gameObject);
			Instantiate(asteroidExplostion, transform.position, transform.rotation);
		});

		collisions
			.Where(c => c.gameObject.tag == "Player")
			.Subscribe(c => {
				Instantiate(playerExplostion, c.transform.position, c.transform.rotation);
			});
	}
}
