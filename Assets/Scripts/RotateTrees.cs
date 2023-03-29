using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateTrees : MonoBehaviour
{
    

    private void Awake()
    {
        foreach(Transform child in transform)
        {
            float randomRotation = Random.Range(0f, 360f);
            float randomScale = Random.Range(0.5f, 1.5f);
            child.localRotation = Quaternion.Euler(0f, randomRotation, 0f);
            child.localScale = new Vector3(randomScale, randomScale, randomScale);
        }
    }
}
