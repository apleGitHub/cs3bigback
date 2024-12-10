using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBG : MonoBehaviour
{
    public float speed = 10f;

    private void Update() {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
}
