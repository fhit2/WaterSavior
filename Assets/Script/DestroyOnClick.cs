using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnClick : MonoBehaviour
{
    [SerializeField] private Transform mainObject; // Referensi ke objek utama
    [SerializeField] private float animationDuration = 0.5f; // Durasi animasi masuk


    private void OnMouseDown()
    {
        // Mulai animasi menuju objek utama tanpa mempengaruhi posisi mainObject
        StartCoroutine(MoveAndScaleToMainObject());
    }

    private IEnumerator MoveAndScaleToMainObject()
    {
        Vector3 startPosition = transform.position; // Posisi awal objek yang diklik
        Vector3 targetPosition = mainObject.position; // Posisi tujuan (objek utama)
        Vector3 startScale = transform.localScale;
        Vector3 endScale = Vector3.zero; // Mengecil hingga 0

        float elapsedTime = 0;

        // Kunci posisi mainObject agar tidak bergerak sama sekali
        Vector3 lockedMainObjectPosition = mainObject.position;

        while (elapsedTime < animationDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / animationDuration;

            // Interpolasi hanya posisi dan skala objek yang diklik
            transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            transform.localScale = Vector3.Lerp(startScale, endScale, t);

            // Kunci posisi mainObject sepenuhnya (tanpa diulang dalam loop)
            mainObject.position = lockedMainObjectPosition;

            yield return null;
        }

        // Tambahkan skor dari ScoreManager
        ScoreManager.Instance.AddScore();

        QuestSystem questSystem = FindObjectOfType<QuestSystem>();
        if (questSystem != null)
        {
            questSystem.CollectItem();
        }

        // Setelah animasi selesai, hancurkan objek yang diklik
        Destroy(gameObject);

        // Cek apakah semua objek telah diambil
        questSystem.CheckIfAllObjectsCollected();
    }


}
