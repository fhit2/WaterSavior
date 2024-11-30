using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingTrash : MonoBehaviour
{
    public float verticalStrength = 1f; // Kekuatan gerakan vertikal (naik-turun)
    public float verticalSpeed = 0.7f; // Kecepatan gerakan vertikal
    public float horizontalStrength = 3f; // Kekuatan gerakan horizontal (kanan-kiri)
    public float horizontalSpeed = 10f; // Kecepatan gerakan horizontal
    public float randomOffset = 10f; // Offset acak untuk variasi antar objek
    public float rotationSpeed = 0f; // Kecepatan rotasi untuk efek alami

    private Vector3 startPosition;
    private float randomSeed; // Nilai acak untuk variasi gerakan antar objek

    void Start()
    {
        // Simpan posisi awal objek
        startPosition = transform.position;

        // Berikan nilai acak untuk setiap objek, untuk membuat variasi gerakan
        randomSeed = Random.Range(0f, 100f);
    }

    void Update()
    {
        // Gerakan naik-turun (sumbu Y) dengan sedikit variasi
        float newY = startPosition.y + Mathf.Sin((Time.time + randomSeed) * verticalSpeed) * verticalStrength;

        // Gerakan horizontal (sumbu X) menggunakan Perlin Noise untuk keacakan halus
        float newX = startPosition.x + (Mathf.PerlinNoise((Time.time + randomSeed) * horizontalSpeed, 0) - 0.5f) * horizontalStrength;

        // Terapkan posisi baru dengan gerakan random pada X dan Y
        transform.position = new Vector3(newX, newY, startPosition.z);

        // Tambahkan rotasi acak untuk memberikan kesan lebih hidup
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);
    }
}
