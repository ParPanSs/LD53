using UnityEngine;

public class RotateBody : MonoBehaviour
{
    [SerializeField] private GameObject ground;
    // Переменная, хранящая максимальное значение угла поворота
    public float maxRotationAngle = 90.0f;

// Переменная, хранящая время, которое тело проводит в воздухе
    private float airTime = 0.0f;

// Переменная, хранящая, падает тело или нет
    private bool isFalling = true;

// Переменная, хранящая скорость вращения
    private float rotationSpeed = 10.0f;

// Переменная, хранящая, находится ли тело на земле
    private bool isOnGround = false;

// Переменная, хранящая высоту, на которую тело поднялось от земли
    private float heightAboveGround = 0.0f;

// Переменная, хранящая позицию земли
    private float groundPosition = 0.2f;

    void Update() 
    {
        // Проверка, находится ли тело на земле
        if (transform.position.y <= groundPosition) 
        {
            isOnGround = true;
            heightAboveGround = 0.0f;
        } 
        else 
        {
            isOnGround = false;
            heightAboveGround = transform.position.y - groundPosition;
        }

        // Если тело в воздухе
        if (!isOnGround && isFalling) 
        {
            airTime += Time.deltaTime;

            // Рассчитываем угол поворота, основываясь на времени, которое тело провело в воздухе
            float t = airTime / 2.0f; // Делим на 2, чтобы угол поворота не превышал 90 градусов
            float rotationAngle = Mathf.Lerp(0.0f, maxRotationAngle, t);

            // Применяем поворот к телу
            Quaternion rotation = Quaternion.Euler(0.0f, 0.0f, -rotationAngle);
            transform.rotation = rotation;

            // Если тело достигло земли
            if (transform.position.y <= ground.transform.position.y) 
            {
                // Устанавливаем тело в правильное положение и завершаем падение
                Vector3 position = transform.position;
                position.y = groundPosition;
                transform.position = position;
                transform.rotation *= Quaternion.Euler(0.0f, 0.0f, -90.0f);
                isFalling = false;
            }
        }
    }
}