using UnityEngine;
using UniRx;
using System;

public class MoveOnInput : RxBehaviour
{
	public float speed;
	
	void Start ()
	{
		var sub1 = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
                GetComponent<Rigidbody>().velocity = new Vector3(
						Input.GetAxis("Horizontal"),
						0.0f,
						Input.GetAxis("Vertical"))
					* speed;
			});

		AddSubscriptions(sub1);
	}
}
