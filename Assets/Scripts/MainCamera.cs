using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainCamera : MonoBehaviour
{
	public GameObject target;
	public ParticleSystem wind;
	public float smoothSpeed;
	public Vector3 DefaultOffset;
	void LateUpdate()
	{
		if (!FindObjectOfType<Character>().isArena && GameManager.instance.isGameOn)
		{
			DefaultOffset = new Vector3(0, 4, -4);
			CameraRePosition(DefaultOffset);
		}
		else if (FindObjectOfType<Character>().isArena && GameManager.instance.isGameOn)
		{
			DefaultOffset = new Vector3(0, 2.5f, -2);
			CameraRePosition(DefaultOffset);
		}

	}

	public void CameraRePosition(Vector3 DefaultOffset)
	{
		Vector3 desiredPosition = target.transform.position + DefaultOffset;
		transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);
	}
}
