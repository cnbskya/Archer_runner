using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
        //ArrowSpawners();
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
		for (int i = 0; i < FindObjectOfType<Character>().arrowCount; i++)
		{
            GameObject go = Instantiate(arrow, bulletGhostTF.transform.position, bulletGhostTF.transform.rotation);
            go.AddComponent<Arrow>();
            go.GetComponent<Rigidbody>().velocity = bulletGhostTF.forward * force;
            FindObjectOfType<Character>().arrowCount--;
            yield return new WaitForSeconds(1f); // HER İŞLEMDEN SONRA BEKLEME
        } 
    }


    public class Arrow: MonoBehaviour
	{
		private void Update()
		{
            transform.forward = GetComponent<Rigidbody>().velocity; 
		}

		private void OnTriggerEnter(Collider other)
		{
			if (other.gameObject.CompareTag("Enemy"))
			{
                gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
                gameObject.transform.SetParent(other.transform);
                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ 
                    | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezeRotationZ;
            }
		}
	}

}



