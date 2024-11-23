using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmoothFloat : MonoBehaviour
{
    public float floatStrength = 0.5f; // Kekuatan mengapung
    public float floatSpeed = 1f;      // Kecepatan mengapung

    private Vector3 startPosition;
    private float horizontalOffset;    // Offset horizontal unik untuk tiap objek
    private float verticalOffset;      // Offset vertikal unik untuk tiap objek

    void Start()
    {
        startPosition = transform.position;
        // Memberikan offset unik menggunakan nilai random
        horizontalOffset = Random.Range(0f, 100f);
        verticalOffset = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Gerakan naik turun (sama untuk semua, tetapi dengan offset vertikal untuk variasi kecil)
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed + verticalOffset) * floatStrength;

        // Gerakan horizontal kecil dengan offset unik
        float offsetX = Mathf.Cos(Time.time * floatSpeed + horizontalOffset) * 0.01f;
        float offsetZ = Mathf.Sin(Time.time * floatSpeed + horizontalOffset) * 0.01f;

        // Terapkan posisi baru
        transform.position = new Vector3(
            transform.position.x + offsetX,
            newY,
            transform.position.z + offsetZ
        );
    }
}
