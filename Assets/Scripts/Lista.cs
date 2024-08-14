using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.IO;

public class Lista : MonoBehaviour
{
    public List<personajes> ListaPersonajes = new List<personajes>(); //Inicializar lista para guardar personajes
    public InputField Usuarios, cve;
    public Text errores, UsuarioRepetido;
    public GameObject alumno;
    public InputField users, cves, NoAl;
    public Dropdown generito;
    public GameObject UILogin, UIRegistro;
    private string[] linea;
    private string repetido;

    void Start()
    {
        ListaPersonajes = new List<personajes>();
    }

    public void logeo()
    {
        string line, errorsito = "No se encuentra el Usuario";
        StreamReader Leelo = new StreamReader(Application.streamingAssetsPath + "/datos.txt");
        line = Leelo.ReadLine(); //Lee la primera linea del archivo de texto
        while(line != null)
        {
            Debug.Log(line);
            if(line == Usuarios.text) //compara el string de la primera linea con el string de la caja de texto 
            {
                line = Leelo.ReadLine(); //salta a la siguiente linea
                if (line == cve.text)
                {
                    alumno.GetComponent<Alumno>().names = Leelo.ReadLine(); //a mi variable alumno obten el componente del gameobject alumno de su variable publica nombre
                    line = Leelo.ReadLine();
                    if (line == "True")
                    {
                        alumno.GetComponent<Alumno>().tipo = true;
                    }
                    else
                    {
                        alumno.GetComponent<Alumno>().tipo = false;
                    }
                    SceneManager.LoadScene("NivelClase"); //Carga el nivel de la clase
                }
                else
                {
                    Debug.Log("La contraseña no coincide"); //Ver errores como desarrollador desde la consola de Unity
                    errorsito = "La contraseña no coincide"; //Imprimer en el label no coincide la contraseña
                }
            }
            line = Leelo.ReadLine();
        }
        Debug.Log("No se encontro el usuario"); //Ver errores como desarrollador desde la consola de Unity
        errores.text = errorsito; //Imprimer en el label no encontre el usuario
        Leelo.Close();
        /*for (int i = 0; i < ListaPersonajes.Count; i++)
        {
            if (ListaPersonajes[i].usuario1 == Usuarios.text)
            {
                if (ListaPersonajes[i].clave1 == cve.text)
                {
                    alumno.GetComponent<Alumno>().names = ListaPersonajes[i].nombre1; //a mi variable alumno obten el componente del gameobject alumno de su variable publica nombre
                    alumno.GetComponent<Alumno>().tipo = ListaPersonajes[i].sexo1;
                    SceneManager.LoadScene("NivelClase");
                }
                else
                {
                    Debug.Log("La contraseña no coincide"); //Ver errores como desarrollador desde la consola de Unity
                    errores.text = "La contraseña no coincide"; //Imprimer en el label no coincide la contraseña
                }
            }
            else if ((ListaPersonajes.Count - 1) == i) //Comparar con el final de la lista
            {
                Debug.Log("No se encontro el usuario"); //Ver errores como desarrollador desde la consola de Unity
                errores.text = "No se encuentra el usuario"; //Imprimer en el label no encontre el usuario
            }
        }*/
    }

    public void registro()
    {
        StreamReader comprobacion = new StreamReader(Application.streamingAssetsPath + "/datos.txt");
        string line;
        line = comprobacion.ReadLine();
        if (line == null)
        {
            comprobacion.Close();

            if (generito.value == 0)
            {
                Debug.Log("Eres Niño"); //Ver si es niño como desarrollador desde la consola de Unity
                //ListaPersonajes.Add(new personajes(users.text, NoAl.text, cves.text, false));
                StreamWriter guardar = new StreamWriter(Application.streamingAssetsPath + "/datos.txt");
                guardar.WriteLine(users.text);
                guardar.WriteLine(cves.text);
                guardar.WriteLine(NoAl.text);
                guardar.WriteLine("False");
                guardar.Close();
            }
            else
            {
                Debug.Log("Eres Niña"); //Ver si es niña como desarrollador desde la consola de Unity
                //ListaPersonajes.Add(new personajes(users.text, NoAl.text, cves.text, true));
                StreamWriter guardar = new StreamWriter(Application.streamingAssetsPath + "/datos.txt");
                guardar.WriteLine(users.text);
                guardar.WriteLine(cves.text);
                guardar.WriteLine(NoAl.text);
                guardar.WriteLine("True");
                guardar.Close();
            }
        }
        else
        {
            comprobacion.Close();

            if (generito.value == 0)
            {
                Debug.Log("Eres Niño"); //Ver si es niño como desarrollador desde la consola de Unity
                                        //ListaPersonajes.Add(new personajes(users.text, NoAl.text, cves.text, false));
                StreamWriter añade = File.AppendText(Application.streamingAssetsPath + "/datos.txt"); //añade despues de la ultima linea en el texto
                añade.WriteLine(users.text);
                añade.WriteLine(cves.text);
                añade.WriteLine(NoAl.text);
                añade.WriteLine("False");
                añade.Close();
            }
            else
            {
                Debug.Log("Eres Niña"); //Ver si es niña como desarrollador desde la consola de Unity
                                        //ListaPersonajes.Add(new personajes(users.text, NoAl.text, cves.text, true));
                StreamWriter añade = File.AppendText(Application.streamingAssetsPath + "/datos.txt"); //añade despues de la ultima linea en el texto
                añade.WriteLine(users.text);
                añade.WriteLine(cves.text);
                añade.WriteLine(NoAl.text);
                añade.WriteLine("True");
                añade.Close();
            }
        }
        LimpiaRegistro();//Limpia el menu de registro
        MenuPrincipal(); //funcion que lleva al menu principal despues de registrarse
    }

    public void InterfazRegistro()
    {
        UILogin.SetActive (false);
        UIRegistro.SetActive(true); //Activa el menu de registro
        LimpiaMenu();
    }

    public void MenuPrincipal()
    {
        UILogin.SetActive(true); //Activa el menu de login
        UIRegistro.SetActive(false);
        LimpiaRegistro();
    }
    public void LimpiaRegistro()
    {
        users.text = "";
        cves.text = "";
        NoAl.text = "";
        generito.value = 0;
    }
    public void LimpiaMenu()
    {
        Usuarios.text = "";
        cve.text = "";
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
    public void Validacion()
    {
        linea = File.ReadAllLines(Application.streamingAssetsPath + "/datos.txt");
        for(int i = 0; i < linea.Length; i++)
        {
            if (linea[i] == users.text)
            {
                repetido = linea[i];
                Debug.Log("Error este usuario ya existe, favor de ingresar uno nuevo");
            }
        }
        if ((repetido != users.text)&&(users.text != ""))
        {
            registro();
        }
        else
        {
            UsuarioRepetido.text = "Error Usuario en Blanco o Ya Existente, Favor de ingresar uno nuevo";
        }
    }
}
