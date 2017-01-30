using UnityEngine;
using UniRx;
using System;

public class TiltOnMove : MonoBehaviour
{
	public float tilt;

	private IDisposable updateSubscription;

	void Start ()
	{
        updateSubscription = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
			});
	}

	void OnDestroy()
	{
		updateSubscription.Dispose();
	}
}
