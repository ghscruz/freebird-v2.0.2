using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    public bool invert;
    public Vector3 offset;
    public Transform initialPosition;
    private Vector3 currentPosition;

    void OnEnable()
    {
        HandleEffect.BirdCall += createPosition;
    }

    void OnDisable()
    {
        HandleEffect.BirdCall -= createPosition;
    }

    void Awake()
    {
        currentPosition = initialPosition.position;
    }

    private void Start()
    {
        createPosition();
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            createPosition();
        }
    }

    public void createPosition()
    {
        if(invert)
        {
            InvertPosition();
            currentPosition += offset;
            return;
        }

        GameObject newFollower = createObject();
        newFollower.transform.position = currentPosition;

        invert = !invert;
    }

    public void InvertPosition()
    {
        GameObject newFollower = createObject();
        Vector3 pos = currentPosition;
        pos.x *= -1;
        newFollower.transform.position = pos;
        invert = !invert;
    }

    public GameObject createObject()
    {
        GameObject newFollower = new GameObject();
        newFollower.transform.SetParent(gameObject.transform);
        return newFollower;
    }
}
