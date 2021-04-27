using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	float xPos;
	float zPos;
	public float enemyCount;
	void Start()
	{
	}
	public IEnumerator EnemyDrop()
	{
		while (enemyCount < FindObjectOfType<Character>().arrowCount / 3)
		{
			xPos = Random.Range(-5, 5);
			zPos = Random.Range(-10, 0);
			Instantiate(enemyPrefab, new Vector3(xPos, -7.3f, gameObject.transform.position.z + zPos), Quaternion.identity);
			enemyCount += 1;
			yield return new WaitForSeconds(0.2f);
		}
	}
}
