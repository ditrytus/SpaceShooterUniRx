using UnityEngine;
using UniRx;

public class BoundMovement : MonoBehaviour
{
	public Boundary boundary;

	void Start ()
	{
		Observable.EveryFixedUpdate()
			.Subscribe(_ =>
			{
				transform.position = new Vector3(
					Mathf.Clamp(transform.position.x, boundary.xRange.min, boundary.xRange.max),
					Mathf.Clamp(transform.position.y, boundary.yRange.min, boundary.yRange.max),
					Mathf.Clamp(transform.position.z, boundary.zRange.min, boundary.zRange.max)
				);
			});
	}
}
