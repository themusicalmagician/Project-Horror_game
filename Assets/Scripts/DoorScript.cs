using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{

    public GameObject PlayerManager;
    public GameObject Enemy;

    // Update is called once per frame
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag.Equals("Player"))
        {
            PlayerManager.transform.position = new Vector3(-12.8f, 7.8f, 0);
            Enemy.SetActive(false);
        }

    }
}
