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
		for (int i = 0; i < iterations; i++)
		{
            GameObject go = Instantiate(arrow, bulletGhostTF.transform.position, FindObjectOfType<Character>().transform.rotation);
            go.GetComponent<Rigidbody>().velocity = bulletSpawnTF.transform.position * force;
            yield return new WaitForSeconds(5f); // HER İŞLEMDEN SONRA BEKLEME
        } 
    }
    
}



