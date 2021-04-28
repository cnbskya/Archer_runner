using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class Tile : MonoBehaviour
{
	[Header("PROTECT TILE VARIABLES")]
	Vector3 G = Physics.gravity;
	public bool isFallen;
	public Transform bulletGhostTF;
	public Transform bulletSpawnTF;
	public Vector3 target;
	public int iterations;
	public float iterationInterval;
	public float force;

	[Header("SPAWN OBJECTS")]
	public GameObject arrow;

	private void Start()
	{
		StartCoroutine(ArrowSpawners());
	}
	void Update()
	{
		CalculateProjectileOnTime();
	}

	public void CalculateProjectileOnTime()
	{
		bulletGhostTF.GetComponent<LineRenderer>().positionCount = iterations;
		Vector3 velocityDirection = bulletSpawnTF.forward;

		for (int i = 0; i < iterations; i++)
		{
			bulletGhostTF.GetChild(i).position = bulletSpawnTF.transform.position + velocityDirection * force * i * iterationInterval + 0.5f * G * i * iterationInterval * i * iterationInterval;
			bulletGhostTF.GetComponent<LineRenderer>().SetPosition(i, bulletGhostTF.GetChild(i).position);
		}
	}

	IEnumerator ArrowSpawners()
	{
		yield return new WaitForSeconds(1f); //İLK ÇAĞRILDIĞI ZAMAN BEKLEME
		for (int i = 1; i <= FindObjectOfType<Character>().arrowCount; FindObjectOfType<Character>().arrowCount--)
		{
			GameObject go = Instantiate(arrow, bulletGhostTF.transform.position, bulletGhostTF.transform.rotation);
			go.AddComponent<Arrow>();
			go.GetComponent<Rigidbody>().velocity = bulletGhostTF.forward * force;
			yield return new WaitForSeconds(1.2f); // HER İŞLEMDEN SONRA BEKLEME
		}
	}


	public class Arrow : MonoBehaviour
	{
		private void Update()
		{
			if (gameObject.GetComponent<Rigidbody>() != null)
			{
				transform.forward = GetComponent<Rigidbody>().velocity;
			}
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
				Destroy(gameObject.GetComponent<Rigidbody>());
				gameObject.transform.SetParent(other.transform);
				Destroy(gameObject.GetComponent<Collider>());
				gameObject.transform.localPosition = Vector3.zero;

				other.transform.gameObject.GetComponentInParent<NavMeshAgent>().speed = 0;
				other.transform.gameObject.GetComponentInParent<Animator>().SetBool("isDead", true);
				other.transform.gameObject.GetComponentInParent<EnemyController>().isDead = true;


				AllEnemyDeadControl(other);
			}
		}
		public void AllEnemyDeadControl(Collider other)
		{
			for (int i = 0; i < FindObjectOfType<RandomEnemySpawner>().allEnemys.Count; i++)
			{
				Debug.Log(FindObjectOfType<RandomEnemySpawner>().allEnemys.Count);
				if (FindObjectOfType<RandomEnemySpawner>().allEnemys[i].GetComponentInParent<EnemyController>().isDead)
				{
					FindObjectOfType<RandomEnemySpawner>().allEnemys.Remove(FindObjectOfType<RandomEnemySpawner>().allEnemys[i]);
				}
			}

			if(FindObjectOfType<RandomEnemySpawner>().allEnemys.Count == 0)
			{
				FindObjectOfType<Character>().GetComponent<Animator>().SetBool("isVictory", true);
				GameManager.instance.SuccessOnGameFinish();
				
			}
		}
	}
}



