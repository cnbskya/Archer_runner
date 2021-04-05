using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Quiver : MonoBehaviour
{
	private void Update()
	{
		transform.DORotate(new Vector3(-90, 0, -360), 1f, RotateMode.Fast);
	}
}
