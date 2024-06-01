using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    bool move = false;
    Vector3 mousePos;
    Vector3 startPos;

    public GameObject form;
    bool finish;

    private void OnMouseDown()
    {
        if (Input.GetMouseButtonDown(0))
        {
            move = true;

            // Получение позиции мыши в мировых координатах
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            startPos = this.transform.position - mousePos;
        }
    }

    private void OnMouseUp()
    {
        if (Input.GetMouseButtonUp(0))
        {
            move = false;

            if (Mathf.Abs(this.transform.localPosition.x - form.transform.localPosition.x) <= 0.5f &&
                Mathf.Abs(this.transform.localPosition.y - form.transform.localPosition.y) <= 0.5f)
            {
                this.transform.position = new Vector2(form.transform.position.x, form.transform.position.y); 
                finish = true;
            }
        }
    }

    private void Update()
    {
        if (move == true && finish == false)
        {
            // Обновление позиции мыши
            mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Обновление позиции объекта
            this.transform.position = new Vector3(mousePos.x + startPos.x, mousePos.y + startPos.y, this.transform.position.z);
        }
    }
}
