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
					Mathf.Clamp(transform.position.x, boundary.xMin, boundary.xMax),
					Mathf.Clamp(transform.position.y, boundary.yMin, boundary.yMax),
					Mathf.Clamp(transform.position.z, boundary.zMin, boundary.zMax)
				);
			});
	}
}
