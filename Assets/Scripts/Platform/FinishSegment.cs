using System;
using UnityEngine;

public class FinishSegment : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.TryGetComponent(out Ball ball))
        {
            Debug.LogWarning("Level is complete!");
        }
    }
}
