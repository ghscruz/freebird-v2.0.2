using System.Collections;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform target = null;
    public float speed;
    private Vector3 destination;
    [Range(0f, 1f)]
    public float smoothTime;
    public Rigidbody rb;
    private Animator anim;

    public BirdSide side;

    

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }

    private void OnEnable()
    {   
        if(side == BirdSide.right)
            anim.Play("right2left");
        else
            anim.Play("left2right");
    }

     private void Update()
    {
        transform.rotation = target.rotation;
    }

}

public enum BirdSide { right , left };
