using UnityEngine;

namespace MarwanZaky
{
    public class CameraFollow : MonoBehaviour
    {
        public Transform target; // Takip edilecek hedef (karakter)
        public float smoothSpeed = 0.125f; // Yumuþak geçiþ hýzý
        public Vector3 offset = new Vector3(0f, 2f, -5f); // Kamera ile hedef arasýndaki mesafe ve yükseklik ayarý

        private float rotationSmoothTime = 0.1f; // Yumuþak dönüþ zamaný
        private Vector3 velocity = Vector3.zero; // Dönüþ hýzý için kullanýlacak deðiþken

        void LateUpdate()
        {
            if (target != null)
            {
                // Kamera hedefin (karakterin) üstünde ve arkasýnda kalacak þekilde pozisyonunu ayarla
                Vector3 desiredPosition = target.position + offset.y * target.up - offset.z * target.forward;
                transform.position = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, smoothSpeed);

                // Kamera dönüþünü hedefin (karakterin) dönüþüne göre ayarla
                Quaternion targetRotation = Quaternion.Euler(30f, target.eulerAngles.y, 0f);
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSmoothTime);
            }
        }
    }
}