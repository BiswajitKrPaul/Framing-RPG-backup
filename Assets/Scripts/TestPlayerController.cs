using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestPlayerController : MonoBehaviour {
    private Rigidbody2D _rigidbody;
    private Animator _animator;

    private void Awake() {
        _rigidbody = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    private void Update() {
        var x = Input.GetAxisRaw("Horizontal");
        var y = Input.GetAxisRaw("Vertical");
        if (x == 0 && y == 0) return;
        _animator.SetFloat("x", x);
        _animator.SetFloat("y", y);
    }
}