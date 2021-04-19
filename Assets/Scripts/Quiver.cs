using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Quiver : MonoBehaviour
{
	public static Quiver instance;
	public GameObject bonusTextPrefab;

	private void Awake()
	{
		instance = this;
	}
	private void Update()
	{
		// Oyun başladığında rotate olmaya başlayacaktır.
		if (GameManager.instance.isGameOn)
		{
			transform.Rotate(Vector3.forward, 0.6f); // Objenin rotation'u localde farklı olduğundan globaldeki y axisinde dönüyor.
		}
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag("Player"))
		{
			ShowFloatingText(other);
			Destroy(gameObject);
		}
	}

	public void ShowFloatingText(Collider other)
	{
		var go = Instantiate(bonusTextPrefab, gameObject.transform.position, other.transform.rotation);

		go.SetActive(true);
		Vector3 targetPos = go.transform.position + (Vector3.up * 1.5f);
		go.GetComponent<SpriteRenderer>().DOFade(0, 3f).SetEase(Ease.OutCubic);
		go.transform.DOMove(targetPos, 0.7f).SetEase(Ease.OutCubic).OnComplete(() =>
		{
			Destroy(go);
		});
	}
}
