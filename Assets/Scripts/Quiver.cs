using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Quiver : MonoBehaviour
{
	private void Update()
	{
		// Oyun başladığında rotate olmaya başlayacaktır.
		if (GameManager.instance.isGameOn)
		{
			transform.Rotate(Vector3.forward, 1f); // Objenin rotation'u localde farklı olduğundan globaldeki y axisinde dönüyor.
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy(gameObject);
		}
	}
}
