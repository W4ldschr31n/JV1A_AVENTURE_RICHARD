using UnityEngine;
using System.Collections;

public class CameraFollow : MonoBehaviour
{
	public float smoothTime = 1f;
	public Transform target;
	private Vector3 velocity = Vector3.zero;

	void Update()
	{
		if (target)
		{
			Vector3 from = transform.position;
			Vector3 to = target.position;
			to.z = transform.position.z;

			transform.position = Vector3.SmoothDamp(from, to, ref velocity, smoothTime);
		}
	}
}