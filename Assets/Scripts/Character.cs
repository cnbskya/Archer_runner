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

    public void GoForward()
	{
        gameObject.transform.position += Vector3.forward * speed * Time.deltaTime; // Change Forward positions
        animator.SetBool("isRunning", true); // Running animation start.
    }
}
