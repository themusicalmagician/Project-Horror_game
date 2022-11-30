using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSwap : MonoBehaviour
{
    [SerializeField] GameObject p1Parent;
    [SerializeField] GameObject p1;
    [SerializeField] GameObject p2Parent;
    [SerializeField] GameObject p2;

    void Awake()
    {
        p2Parent.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            if (p1Parent.activeInHierarchy == true)
            {
                p1Parent.SetActive(false);
                p2Parent.SetActive(true);
            }
            else
            {
                p1Parent.SetActive(true);
                p2Parent.SetActive(false);
            }
        }
    }
    
}
