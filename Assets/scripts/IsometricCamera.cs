using UnityEngine;

public class IsometricCamera : MonoBehaviour
{
    [Header("Target")]
    [SerializeField] private Transform target; // ������ �� ������� ������� ������

    [Header("Settings")]
    [SerializeField] private Vector3 offset = new Vector3(0, 10, -10); // �������� ������
    [SerializeField] private float smoothSpeed = 5f; // ��������� ��������
    [SerializeField] private float rotationAngle = 45f; // ���� �������� ������ (��� ���������)

    private void LateUpdate()
    {
        if (!target) return;

        // ������������ �������� ������� � ������ ��������
        Quaternion rotation = Quaternion.Euler(rotationAngle, 0, 0);
        Vector3 desiredPosition = target.position + rotation * offset;

        // ������� �����������
        transform.position = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed * Time.deltaTime);

        // ������ ������� �� ����
        transform.LookAt(target.position);
    }
}