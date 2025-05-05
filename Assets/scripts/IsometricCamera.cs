using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // Объект за которым следует камера

    [Header("Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10); // Смещение камеры
    [SerializeField] private float smoothSpeed = 5f; // Плавность слежения
    [SerializeField] private float rotationAngle = 45f; // Угол поворота камеры (для изометрии)

    private void LateUpdate()
    {
        if (!target) return;

        // Рассчитываем желаемую позицию с учетом поворота
        Quaternion rotation = Quaternion.Euler(rotationAngle, 0, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // Плавное перемещение
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // Всегда смотрим на цель
        transform.LookAt(target.position);
    }
}