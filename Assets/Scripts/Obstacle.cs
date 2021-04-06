using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public float obstacleRotateSpeed;
	public Animation anim;
	public float animSpeed;

	void Start()
	{
		anim = GetComponent<Animation>();
		foreach (AnimationState state in anim)
		{
			state.speed = 0f;
		}
	}

	private void Update()
	{
		// Oyun başladığında rotate olmaya başlayacaktır.
		if (GameManager.instance.isGameOn)
		{
			transform.Rotate(Vector3.up, obstacleRotateSpeed); // Objenin rotation'u localde farklı olduğundan globaldeki y axisinde dönüyor.
			SawAnimControl();
		}
	}

	public void SawAnimControl()
	{
		//OYUN BAŞLADIĞINDA TESTERENİN DÖNME HIZI AYARLANIYOR
		foreach (AnimationState state in anim)
		{
			state.speed = animSpeed;
		}
	}

}
