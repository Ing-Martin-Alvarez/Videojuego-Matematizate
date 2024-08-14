using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]

public class personajes
{
    public string usuario1;
    public string nombre1;
    public string clave1;
    public bool sexo1;

    public personajes(string usuario, string nombre, string clave, bool sexo)
    {
        usuario1 = usuario;
        nombre1 = nombre;
        clave1 = clave;
        sexo1 = sexo;
    }

    public personajes()
    {

    }
}
