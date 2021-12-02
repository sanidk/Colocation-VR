using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRAnimatorController : MonoBehaviour
{
    private AudioSource footstepSound;
    private Animator animator;
    public Vector3 previousPos;

    public float velocity;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        footstepSound = GetComponent<AudioSource>();
    }


    // Update is called once per frame
    void Update()
    {
        velocity = ((transform.TransformPoint(Vector3.zero) - previousPos).magnitude) / Time.deltaTime;
        previousPos = transform.TransformPoint(Vector3.zero);

        animator.SetBool("isMoving", velocity > 0.3f);

        if (velocity > 0.3f)
        {
            footstepSound.Play();
        }
        else
        {
            footstepSound.Stop();
        }

        Debug.Log("Velocity: " + velocity);
    }
}