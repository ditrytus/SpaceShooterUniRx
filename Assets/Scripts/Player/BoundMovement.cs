using UnityEngine;
using UniRx;
using System;

public class BoundMovement : MonoBehaviour
{
	public Boundary boundary;

	private IDisposable updateSubscription;

	void Start ()
	{
		updateSubscription = Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x, boundary.xRange.min, boundary.xRange.max),
					Mathf.Clamp(transform.position.y, boundary.yRange.min, boundary.yRange.max),
					Mathf.Clamp(transform.position.z, boundary.zRange.min, boundary.zRange.max)
				);
			});
	}

	void OnDestroy()
	{
		updateSubscription.Dispose();
	}
}
