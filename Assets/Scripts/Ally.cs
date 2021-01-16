using System.Collections;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public Transform transform;
    //public Transform target;
    public float followSpeed = 5;
    public float rotateSpeed = 0.35f;
    //public Rigidbody rb;
    private Animator anim;

    public BirdSide side;

    private GameObject bird;

    private GameObject target;



    float getAnimTime(string animationName) {
        RuntimeAnimatorController ac = anim.runtimeAnimatorController;    //Get Animator controller
        for (int i = 0; i < ac.animationClips.Length; i++)                 //For all animations
        {
            if (ac.animationClips[i].name == animationName)        //If it has the same name as your clip
                return ac.animationClips[i].length;
        }

        return 1;
    }


    private IEnumerator PlayJoiningGroup()
    {
        if (side == BirdSide.right)
        {
            anim.Play("right2left");
            float time = getAnimTime("right2left");
            yield return new WaitForSeconds(time);
        }
        else
        {
            anim.Play("left2right");
            float time = getAnimTime("left2right");
            yield return new WaitForSeconds(time);
        }
    }


    void Awake ()
    {
        target = GameObject.Find("Pos01");
        bird = GameObject.Find("Bird");

        //rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
        transform = GetComponent<Transform>();
    }

    void OnEnable()
    {
        StartCoroutine("PlayJoiningGroup");
    }

    //private void Update()
    //{
    //    transform.rotation = target.rotation;
    //}

    void LateUpdate()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.transform.position, followSpeed * Time.deltaTime);
        //Vector3 direction = (bird.transform.position - transform.position).normalized;
        //transform.forward = direction;
        transform.rotation = Quaternion.Slerp(transform.rotation, target.transform.rotation, Time.deltaTime/rotateSpeed);
    }

}

public enum BirdSide { right , left };
