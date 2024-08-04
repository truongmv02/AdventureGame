using UnityEngine;
using System.Collections;

public class CheckPointEnd : MonoBehaviour
{
    private bool isOut = false;
    private void Awake()
    {
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isOut == false && other.CompareTag("Player"))
        {
            isOut = true;
            StartCoroutine(GameManager.Instance.FinishGame());
        }
    }

}