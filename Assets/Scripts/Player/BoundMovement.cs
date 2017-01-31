using UnityEngine;
using UniRx;
using System;

public class BoundMovement : RxBehaviour
{
	public Boundary boundary;

	void Start ()
	{
		var sub1 = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x, boundary.xRange.min, boundary.xRange.max),
					Mathf.Clamp(transform.position.y, boundary.yRange.min, boundary.yRange.max),
					Mathf.Clamp(transform.position.z, boundary.zRange.min, boundary.zRange.max)
				);
			});
		
		AddSubscriptions(sub1);
	}
}
