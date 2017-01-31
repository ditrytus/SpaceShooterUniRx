using UnityEngine;
using UniRx;
using System;

public class TiltOnMove : RxBehaviour
{
	public float tilt;

	void Start ()
	{
        var sub1 = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
				GetComponent<Rigidbody>().rotation = Quaternion.Euler(0.0f, 0.0f, GetComponent<Rigidbody>().velocity.x * -tilt);
			});

		AddSubscriptions(sub1);
	}
}
