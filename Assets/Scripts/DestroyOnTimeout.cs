using UnityEngine;
using UniRx;
using System;

public class DestroyOnTimeout : RxBehaviour {
	public float timeout;

	void Start () {
		var sub1 = Observable
			.Timer(TimeSpan.FromSeconds(timeout))
			.Subscribe(_ => {
				Destroy(gameObject);
			});
		
		AddSubscriptions(sub1);
	}
}
