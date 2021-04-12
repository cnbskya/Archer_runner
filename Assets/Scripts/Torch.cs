using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Torch : MonoBehaviour
{
	public ParticleSystem fireParticle;
	public GameObject pointLight;
	public float deneme;
	public bool isMax;

	private void Awake()
	{
		pointLight = transform.GetChild(3).gameObject;
	}
	void Start()
	{
		gameObject.transform.GetChild(2).transform.gameObject.SetActive(true);
		pointLight.transform.gameObject.SetActive(true);
	}

	private void Update()
	{
		if (pointLight.GetComponent<Light>().intensity < 3f && isMax)
		{
			pointLight.GetComponent<Light>().intensity += 0.01f;
		}
		else isMax = false;

		if (pointLight.GetComponent<Light>().intensity >= 2f && isMax == false)
		{
			pointLight.GetComponent<Light>().intensity -= 0.01f;
		}
		else isMax = true;

	}
}