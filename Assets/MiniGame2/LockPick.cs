using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockPick : MonoBehaviour
{
    public Camera cam;
    public Transform innerLock;
    public Transform pickPosition;

    public float maxAngle = 90;
    public float lockSpeed = 10;

    [Min(1)]
    [Range(1, 25)]
    public float lockRange = 10;

    private float eulerAngle;
    private float unlockAngle;
    private Vector2 unlockRange;

    private float keyPressTime = 0;

    private bool movePick = true;

    void Start()
    {
        // Инициализация новой позиции и диапазона для взлома
        newLock();
    }

    void Update()
    {
        // Установка позиции замка в pickPosition
        transform.localPosition = pickPosition.position;

        if (movePick)
        {
            // Вычисление направления от текущей позиции к позиции мыши
            Vector3 dir = Input.mousePosition - cam.WorldToScreenPoint(transform.position);
            dir.z = 0;  // Убедимся, что z-компонента равна 0
            eulerAngle = Vector3.Angle(dir, Vector3.up);

            // Проверка, нужно ли инвертировать угол
            Vector3 cross = Vector3.Cross(Vector3.up, dir);
            if (cross.z < 0)
            {
                eulerAngle = -eulerAngle;
            }

            // Ограничение угла заданным диапазоном
            eulerAngle = Mathf.Clamp(eulerAngle, -maxAngle, maxAngle);

            // Создание и применение вращения
            Quaternion rotateTo = Quaternion.AngleAxis(eulerAngle, Vector3.forward);
            transform.rotation = rotateTo;
        }

        // Обработка нажатий клавиши D
        if (Input.GetKeyDown(KeyCode.D))
        {
            movePick = false;
            keyPressTime = 1;
        }
        if (Input.GetKeyUp(KeyCode.D))
        {
            movePick = true;
            keyPressTime = 0;
        }

        keyPressTime = Mathf.Clamp(keyPressTime, 0, 1);

        // Вычисление процента правильного угла
        float percentage = Mathf.Round(100 - Mathf.Abs(((eulerAngle - unlockAngle) / 100) * 100));
        float lockRotation = ((percentage / 100) * maxAngle) * keyPressTime;
        float maxRotation = (percentage / 100) * maxAngle;

        // Интерполяция вращения замка
        float lockLerp = Mathf.Lerp(innerLock.eulerAngles.z, lockRotation, Time.deltaTime * lockSpeed);
        innerLock.eulerAngles = new Vector3(0, 0, lockLerp);

        // Проверка на успешное взлом
        if (lockLerp >= maxRotation - 1)
        {
            if (eulerAngle < unlockRange.y && eulerAngle > unlockRange.x)
            {
                Debug.Log("Unlocked!");

                movePick = true;
                keyPressTime = 0;
            }
            else
            {
                float randomRotation = Random.insideUnitCircle.x;
                transform.eulerAngles += new Vector3(0, 0, Random.Range(-randomRotation, randomRotation));
            }
        }
    }

    void newLock()
    {
        unlockAngle = Random.Range(-maxAngle + lockRange, maxAngle - lockRange);
        unlockRange = new Vector2(unlockAngle - lockRange, unlockAngle + lockRange);
    }
}
