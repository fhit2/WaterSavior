using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnderwaterFloat : MonoBehaviour
{
   public float verticalStrength = 1f;
public float verticalSpeed = 1.5f;
public float horizontalStrength = 0.3f;
public float driftSpeed = 0.8f;
public float rotationSpeed = 0.1f;
    private Vector3 startPosition;

    void Start()
    {
        // Simpan posisi awal objek
        startPosition = transform.position;
    }

    void Update()
    {
        // Gerakan naik-turun yang halus
        float newY = startPosition.y + Mathf.Sin(Time.time * verticalSpeed) * verticalStrength;

        // Gerakan horizontal (x dan z) menggunakan Perlin Noise
        float driftX = Mathf.PerlinNoise(Time.time * driftSpeed, 0) - 0.5f;
        float driftZ = Mathf.PerlinNoise(0, Time.time * driftSpeed) - 0.5f;

        // Terapkan posisi dengan gerakan horizontal dan vertikal
        transform.position = new Vector3(
            startPosition.x + driftX * horizontalStrength,
            newY,
            startPosition.z + driftZ * horizontalStrength
        );

        // Rotasi hanya pada sumbu Y untuk efek alami
        transform.Rotate(0, rotationSpeed * Time.deltaTime, 0);
    }
    
}
