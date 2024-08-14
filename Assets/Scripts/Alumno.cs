using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alumno : MonoBehaviour
{
    public string names; //variable de nombre
    public bool tipo; //variable de sexo

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);

    }
}
