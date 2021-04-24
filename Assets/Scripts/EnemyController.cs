using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Animator anim;
    public Transform character;
    NavMeshAgent agent;
    void Start()
    {
        anim = transform.GetChild(0).GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        EnemyRandomSpeed();
     }

    // Update is called once per frame
    void Update()
    {
        bool isArena = FindObjectOfType<Character>().isArena;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

        float distance = Vector3.Distance(character.position, transform.position);
		if (distance <= lookRadius && isArena)
		{
            Debug.Log("Aradaki mesafe sağlandı ve karakter arenaya girdi, animasyon başladı");
            StartCoroutine(ToDoEnemy(distance));
		}
    }
    void FaceTarget()
	{
        Vector3 direction = (character.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 15f);
	}
	void OnDrawGizmosSelected()
	{
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
	}
    void EnemyRandomSpeed()
	{
        GetComponent<NavMeshAgent>().speed = Random.Range(1f, 3f); // 1,2
        if(GetComponent<NavMeshAgent>().speed < 2f)
		{
            transform.GetChild(0).GetComponent<Animator>().speed = 1;
		}
		else if (GetComponent<NavMeshAgent>().speed >= 2f && GetComponent<NavMeshAgent>().speed <= 3f)
		{
            transform.GetChild(0).GetComponent<Animator>().speed = 1.2f;
        }
    }
    
    IEnumerator ToDoEnemy(float distance)
	{
        yield return new WaitForSeconds(FindObjectOfType<Character>().shootDelay);
        agent.SetDestination(character.position);
        anim.SetBool("isWalking", true);

        if (distance <= agent.stoppingDistance)
        {
            // SALDIRMA İŞLEMİ BURADA YAPILABİLİR
            FaceTarget();
        }
    }
}
