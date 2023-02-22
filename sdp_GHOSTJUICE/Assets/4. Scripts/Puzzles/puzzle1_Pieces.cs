using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class puzzle1_Pieces : MonoBehaviour
{
    public Vector2 targetPosition;
    // Start is called before the first frame update
    void Start()
    {
        targetPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.Lerp(transform.position, targetPosition, 0.05f);
    }
}
