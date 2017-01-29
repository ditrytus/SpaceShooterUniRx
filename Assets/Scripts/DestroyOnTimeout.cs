using UnityEngine;
using UniRx;
using System;

public class DestroyOnTimeout : MonoBehaviour {
	public float timeout;

	void Start () {
		Observable
			.Timer(TimeSpan.FromSeconds(timeout))
			.Subscribe(_ => {
				Destroy(gameObject);
			});
	}
}
