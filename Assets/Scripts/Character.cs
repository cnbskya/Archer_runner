using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
	public GameObject slideBow;
	public GameObject bowSkinnedMesh;
	Rigidbody rb;
    public Animator animator;
	public ParticleSystem blood;
    public float speed;
	public float rayDistance;
	public bool isCharacterForward;

	private void Start()
	{
		rb = gameObject.GetComponent<Rigidbody>();
		animator.enabled = false;
	}
	void Update()
    {
		if (GameManager.instance.isGameOn)
		{
			animator.enabled = true;
			GoForward();
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		// ************ OBSTACLE *****************
		if (other.gameObject.CompareTag("GroundObstacle"))
		{
			animator.SetBool("groundReact", true);
			//animator.SetBool
		}
		else if (other.gameObject.CompareTag("AirObstacle"))
		{
			animator.SetBool("airReact", true);
		}
		else if (other.gameObject.CompareTag("Saw") || other.gameObject.CompareTag("Axe"))
		{
			animator.SetBool("isDead", true);
			blood.Play();
			GameManager.instance.OnGameFinish();
		}
	}

	
	// GROUNDA GİRİNCE
	private void OnTriggerStay(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			FindObjectOfType<CharacterIKSystem>().IKWeightDecrease();
			bowSkinnedMesh.SetActive(true);
			animator.SetBool("isHanging", false);
			isCharacterForward = true;
			slideBow.SetActive(false);
			gameObject.transform.SetParent(null);
			slideBow.transform.SetParent(gameObject.transform);
			slideBow.GetComponent<Rigidbody>().useGravity = true;
		}
	}

	// GROUNDDAN AYRILINCA 
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			FindObjectOfType<CharacterIKSystem>().IKWeightIncrease();
			bowSkinnedMesh.SetActive(false);
			animator.SetBool("isHanging", true);
			isCharacterForward = false;
			slideBow.SetActive(true);
			slideBow.transform.SetParent(null);
			gameObject.transform.SetParent(slideBow.transform);
			slideBow.GetComponent<Rigidbody>().useGravity = true;
		}
	}
	public void GoForward()
	{
		if (isCharacterForward)
		{
			gameObject.transform.position += Vector3.forward * speed * Time.deltaTime; // Change Forward positions
			animator.SetBool("isRunning", true); // Running animation start.
		}
		else
		{
			slideBow.transform.position += Vector3.forward * speed * Time.deltaTime;
		}
    }
}
