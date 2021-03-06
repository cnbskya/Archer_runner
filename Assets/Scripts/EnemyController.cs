using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;
    public Animator anim;
    public GameObject character;
    public Collider mainCollider;
    public Collider[] allColliders;
    public ParticleSystem energyParticle;
    public bool isDead;
    NavMeshAgent agent;
    void Start()
    {
        anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        EnemyRandomSpeed();
        energyParticle.Play();
    }

    // Update is called once per frame
    void Update()
    {
        bool isArena = FindObjectOfType<Character>().isArena;
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);

		if (isArena)
		{
            character = GameObject.Find("Character");
            float distance = Vector3.Distance(character.transform.position, transform.position);
            if (distance <= lookRadius)
            {
                StartCoroutine(ToDoEnemy(distance));
            }
        }
        
    }
	void FaceTarget()
	{
        Vector3 direction = (character.transform.position - transform.position).normalized;
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
        GetComponent<NavMeshAgent>().speed = Random.Range(1f, 2.2f); // 1f,2.2f
        if(GetComponent<NavMeshAgent>().speed < 2f)
		{
            GetComponent<Animator>().speed = 1;
		}
		else if (GetComponent<NavMeshAgent>().speed >= 2f && GetComponent<NavMeshAgent>().speed <= 2.2f)
		{
            GetComponent<Animator>().speed = 1.2f;
        }
    }
    
    IEnumerator ToDoEnemy(float distance)
	{
        yield return new WaitForSeconds(FindObjectOfType<Character>().shootDelay);
        agent.SetDestination(character.transform.position);

        if (distance > 5f)
        {
            anim.SetBool("isWalking", true);
            FaceTarget();
        }
		else if (distance <= 5f) // ***************************************** BURANIN DÜZELTİLMESİ GEREKİYOR ***************************************** 
        {
            anim.SetBool("isSword", true);
        }
    }
    public void GetCharacterDead() // SWORD ANİM EVENT İLE ÇAĞIRILDI
	{
        FindObjectOfType<Character>().InArenaDead();
	}
}
