using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public GameObject character;
    public Animator animator;
    public float speed;

    void Update()
    {
		if (GameManager.instance.isGameOn)
		{
            GoForward(); 
		}
    }
	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("GroundObstacle"))
		{
			animator.SetBool("groundReact", true);
			//animator.SetBool
		}
		else if (other.gameObject.CompareTag("Saw") || other.gameObject.CompareTag("Axe"))
		{
			animator.SetBool("isDead", true);
			GameManager.instance.OnGameFinish();
		}
	}
	public void GoForward()
	{
        gameObject.transform.position += Vector3.forward * speed * Time.deltaTime; // Change Forward positions
        animator.SetBool("isRunning", true); // Running animation start.
    }

}
