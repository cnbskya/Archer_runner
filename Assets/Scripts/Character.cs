using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 
public class Character : MonoBehaviour
{
	[Header("GameObjects")]
	public GameObject character;
	public GameObject slideBow;
	public GameObject bowSkinnedMesh;
	Rigidbody rb;
	public Animator animator;
	public ParticleSystem blood;

	[Header("Variables")]
	public float speed;
	public bool isCharacterForward;
	public bool isBalance;
	public bool isArena;

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
		// ************ OBSTACLE TRİGGERS ************
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
		// ************ GAMEPLAY TRİGGERS ************

		if (other.gameObject.CompareTag("Ground")) // Ground ile tetiklenmişse
		{
			InGround();
		}
		else if (other.gameObject.CompareTag("GroundBalance"))
		{
			InBalanceGround();
		}
		else if (other.gameObject.CompareTag("Arena"))
		{
			InArena();
		}
	}
	// GROUNDDAN AYRILINCA 
	private void OnTriggerExit(Collider other)
	{
		if (other.gameObject.CompareTag("Ground"))
		{
			if (isBalance == false && isArena)
			{
				OutArena();
			}
			// EĞER ARENAYLA ÇALIŞMAYACAK
			else if (isBalance == false && !isArena)
			{
				OutGround();
			}
		}
		else if (other.gameObject.CompareTag("GroundBalance"))
		{
			OutBalanceGround();
			//OutGround();
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

	public void OutGround()
	{
		FindObjectOfType<CharacterIKSystem>().IKBowWeightIncrease();
		bowSkinnedMesh.SetActive(false);
		animator.SetBool("isHanging", true);
		isCharacterForward = false;
		slideBow.SetActive(true);
		slideBow.transform.SetParent(null);
		gameObject.transform.SetParent(slideBow.transform);
		slideBow.GetComponent<Rigidbody>().useGravity = true;
	}

	public void InGround()
	{
		FindObjectOfType<CharacterIKSystem>().IKBowWeightDecrease();
		bowSkinnedMesh.SetActive(true);
		animator.SetBool("isHanging", false);
		isCharacterForward = true;
		slideBow.SetActive(false);
		gameObject.transform.SetParent(null);
		slideBow.transform.SetParent(gameObject.transform);
		slideBow.GetComponent<Rigidbody>().useGravity = false;
	}
	public void InArena()
	{
		isArena = true;
	}
	public void OutArena()
	{
		isArena = false;
	}
	public void InBalanceGround()
	{
		isBalance = true;
		StartCoroutine(BreakTheBalance());
		animator.SetBool("isBalance", true);
		speed = 2.5f;
		FindObjectOfType<CharacterIKSystem>().IKBalanceWeightIncrease();
	}


	public void OutBalanceGround()
	{

		// BALANCEDEN DÜŞME KISMI BURASI OLACAK YAPILACAK - KARAKTERİN HIZI SIFIRLANCAK VE KAMERA TAKİP ETMEYECEK KARAKTER IK WEİGHT DEĞERLERİ SIFIRLANCAK YİNE
		FindObjectOfType<CharacterIKSystem>().IKBowWeightIncrease();
		if (isBalance)
		{
			speed = 0;
			rb.useGravity = true;
			GameManager.instance.isGameOn = false;
			animator.SetBool("isFalling", true);
		}
		
	}

	private IEnumerator BreakTheBalance() // İSSLİDE == TRUE İSE DENGEDE KALMA İŞLEMİ BAŞLIYOR HER TETİKLENDİĞİNDE RANDOM OLARAK SOL VEYA SAĞA DOĞRU TRANSFORM ALIYOR 
	{
		float elapsedTime = 0f;
		float TempoSalita = 4f;
		float LeftOrRight = Random.Range(0, 2);
		yield return null;
		while (elapsedTime < TempoSalita && isBalance == true)
		{
			if (LeftOrRight == 0)
			{
				transform.position = Vector3.Lerp(transform.position,
				new Vector3(transform.position.x - 0.005f, transform.position.y, transform.position.z), (elapsedTime / TempoSalita));
			}
			else
			{
				transform.position = Vector3.Lerp(transform.position,
				new Vector3(transform.position.x + 0.005f, transform.position.y, transform.position.z), (elapsedTime / TempoSalita));
			}
			elapsedTime += Time.deltaTime;

			yield return null;
		}
	}
}
