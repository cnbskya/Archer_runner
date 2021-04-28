using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemySpawner : MonoBehaviour
{
	public GameObject enemyPrefab;
	public List<GameObject> allEnemys= new List<GameObject>();
	float xPos;
	float zPos;
	public float enemyCount;
	public IEnumerator EnemyDrop()
	{
		while (enemyCount < FindObjectOfType<Character>().arrowCount / 3)
		{
			xPos = Random.Range(-5, 5);
			zPos = Random.Range(-10, 0);
			GameObject go = Instantiate(enemyPrefab, new Vector3(xPos, -7.3f, gameObject.transform.position.z + zPos), Quaternion.identity);
			allEnemys.Add(go); // All enemys added from list 
			enemyCount += 1;
			yield return new WaitForSeconds(0.2f);
		}
	}
}
 
// HER DÜŞMAN ÖLDÜĞÜNDE LİSTEYİ DOLANIP LİSTE İÇERİSİNDEKİ BÜTÜN OBJELERİN İSDEAD'İ TRUEYSA GAMEMANAGER FINISH CAGIRALACAK