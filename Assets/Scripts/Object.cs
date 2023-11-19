using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Object : MonoBehaviour
{
    public float speed;

    public Transform target;

    public bool canMove;

    public GameObject vfx;

    public Enum Pos;

    private void Start()
    {
        canMove = false;
    }

    private void Update()
    {
        if (!canMove) return;

        transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision!= null && !(collision.tag == gameObject.tag))
        {
            GameObject vfxEx = Instantiate(vfx, transform.position, Quaternion.identity) as GameObject;
            Destroy(vfxEx, 1f);
            GameManager.Instance.levels[GameManager.Instance.GetCurrentIndex()].gameObjects.Remove(gameObject);
            GameManager.Instance.CheckLevelUp();
            gameObject.SetActive(false);
        }
    }
}
