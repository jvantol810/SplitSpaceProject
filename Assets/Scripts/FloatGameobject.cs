using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatGameobject : MonoBehaviour
{
    // User Inputs
    public float amplitude = 0.5f;
    public float frequency = 1f;

    // Position Storage Variables
    Vector2 posOffset = new Vector2();
    Vector2 tempPos = new Vector2();
    Vector2 m_velocity = new Vector2();
    // Use this for initialization
    void Start()
    {
        // Store the starting position & rotation of the object
        posOffset = transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        // Float up/down with a Sin()
        tempPos = posOffset;
        tempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude;
        //Vector2 tempVector = new Vector2(transform.position.x, Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * amplitude);
        //tempPos.y = Vector2.SmoothDamp((Vector2)transform.position, tempVector, ref m_velocity, 1f).y;

        transform.position = tempPos;
    }
}
