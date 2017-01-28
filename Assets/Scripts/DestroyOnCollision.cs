using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UniRx;
using UniRx.Triggers;

public class DestroyOnCollision : MonoBehaviour {
	void Start () {
		this.OnTriggerEnterAsObservable()
			.Where(c => c.gameObject.tag != "boundary")
			.Subscribe(c => {
				Destroy(c.gameObject);
				Destroy(gameObject);
			});
	}
}
