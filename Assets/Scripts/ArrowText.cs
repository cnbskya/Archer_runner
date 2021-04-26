using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ArrowText : MonoBehaviour
{
    public Transform character;
    public Text scoreText;
    // Update is called once per frame
    void Update()
    {
        scoreText.text = FindObjectOfType<Character>().arrowCount.ToString();
    }
}
