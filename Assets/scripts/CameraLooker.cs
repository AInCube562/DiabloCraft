using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLooker : MonoBehaviour
{
    [SerializeField] private Transform target;

    public void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
    }
}
