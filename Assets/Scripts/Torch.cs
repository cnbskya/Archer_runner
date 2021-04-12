using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torch : MonoBehaviour
{
	public ParticleSystem fireParticle;
	public GameObject pointLight;
	void Start()
	{
		gameObject.transform.GetChild(2).transform.gameObject.SetActive(true);
		gameObject.transform.GetChild(3).transform.gameObject.SetActive(true);
	}
}
