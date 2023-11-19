using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    bool isClicked = false;

    public Enum position;

    private void OnMouseDown()
    {
        if (isClicked) return;

        foreach (GameObject gameObject in GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects)
        {
            if (gameObject.GetComponent<Object>().Pos == position)
            {
                gameObject.GetComponent<Object>().canMove = true;
            }
        }
    }
}
