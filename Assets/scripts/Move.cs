using UnityEngine;

public class Move : MonoBehaviour
{
    public float speed = 5f;
    public float rotationSpeed = 10f; // Если нужно поворачиваться
    
    private Vector3 velocity;
    private CharacterController controller;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        // Получаем ввод (горизонталь и вертикаль)
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical"); // Теперь учитывается!

        // Нормализуем, чтобы диагональное движение не было быстрее
        Vector2 input = new Vector2(moveX, moveZ).normalized;

        // Движение относительно камеры (вид сверху)
        Vector3 moveDirection = new Vector3(input.x, 0, input.y).normalized;

        // Двигаем персонажа
        velocity.x = moveDirection.x * speed;
        velocity.z = moveDirection.z * speed;

        // Гравитация (если нужно)
        if (!controller.isGrounded)
        {
            velocity.y += Physics.gravity.y * Time.deltaTime;
        }
        else
        {
            velocity.y = -0.5f; // Лёгкое прижатие к земле
        }

        // Применяем движение
        controller.Move(velocity * Time.deltaTime);

        // Анимация

        // Поворот (если нужно)
        if (moveDirection.magnitude > 0.1f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);
        }
    }

}