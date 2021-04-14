using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotater : MonoBehaviour
{
    public GameObject player;

    private Vector3 _angles;


    // Start is called before the first frame update
    void Start()
    {
        _angles = new Vector3(0.0f, 1.0f, 0.0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 d = player.transform.position - transform.position;

        d.Normalize();

        float angle = Mathf.Rad2Deg * Mathf.Acos(Vector3.Dot(Vector3.forward, d));

        _angles.y = angle;
        transform.eulerAngles = _angles;
    }
}
