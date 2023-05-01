using UnityEngine;

public class RotateBody : MonoBehaviour
{
    public float gravity = -9.81f;
    public float rotationSpeed = 5f;
    private Vector3 velocity;
    private Matrix4x4 rotationMatrix;

    void Start()
    {
        rotationMatrix = Matrix4x4.TRS(Vector3.zero, Quaternion.Euler(0f, 0f, 90f), Vector3.one);
        velocity = Vector3.zero;
    }

    void FixedUpdate()
    {
        // Приложение гравитации
        velocity += gravity * Vector3.up * Time.deltaTime;

        // Поворот тела
        transform.rotation *= Quaternion.AngleAxis(rotationSpeed, Vector3.forward);

        // Поворот вектора скорости
        velocity = rotationMatrix * velocity;

        // Движение тела
        transform.position += velocity * Time.deltaTime;
    }
}