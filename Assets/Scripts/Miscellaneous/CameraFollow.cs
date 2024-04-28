using UnityEngine;

public class CameraFollow : MonoBehaviour
{
	// Properties
	public float smoothTime = 1f;
	public Transform target;
	private Vector3 velocity = Vector3.zero;

	void Update()
	{
		if (target)
		{
			Vector3 from = transform.position;
			Vector3 to = target.position;
			// Keep original z else camera cannot display anything
			to.z = transform.position.z;

			transform.position = Vector3.SmoothDamp(from, to, ref velocity, smoothTime);
		}
	}
}