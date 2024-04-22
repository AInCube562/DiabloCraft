using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MobMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;
    [SerializeField][Min(0)] private float speed;

    public void Move(Vector2 direction)
    {
        _rigidbody.MovePosition(direction * speed + new Vector2(transform.position.x, transform.position.y));
    }

    void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
    }

}
