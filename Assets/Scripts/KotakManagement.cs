using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KotakManagement : MonoBehaviour
{
    public int KotakValue = 1;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            ScoreManager.instance.ChangeScore(KotakValue);
        }
    }
}