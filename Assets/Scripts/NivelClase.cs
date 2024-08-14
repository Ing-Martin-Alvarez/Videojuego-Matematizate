using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class NivelClase : MonoBehaviour
{
    public Text NombreAlumnoTXT, calificacion, TiempoDeClase, NumeroArriba, NumeroAbajo, LblResultado;
    public Button R1, R2, R3, R4, BTNReiniciar, BTNSalir;
    public Image IMG, BarritaCalifacionIMG, BarritaTiempoIMG;
    public GameObject traelo, UIJuego, UIGameOver, IMGAprobado, IMGReprobado;
    public Slider BarritaCalificacion, BarritaHorario;
    private int contador, tiempo = 6, nota = 10;
    private string[] linea, responde;
    private string ComoSalio;
    // Start is called before the first frame update
    void Start()
    {
        traelo = GameObject.Find("Alumno"); //Busca en la escena un objeto del tipo GameObject que tenga el nombre de "Alumno"
        NombreAlumnoTXT.text = traelo.GetComponent<Alumno>().names;
        linea = File.ReadAllLines(Application.streamingAssetsPath + "/preguntas.txt");
        responde = File.ReadAllLines(Application.streamingAssetsPath + "/respuestas.txt");
        MuestraCalificacion(nota);
        MuestraTiempoClase(tiempo);
        CambiaPregunta();

        if (traelo.GetComponent<Alumno>().tipo == false)
        {
            IMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Boy_Game"); //A la variable IMG accede a su componente de tipo imagen  y luego al sprite
        }
        else
        {
            IMG.GetComponent<Image>().sprite = Resources.Load<Sprite>("Sprites/Girl_Game_");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MuestraCalificacion(int CalificacionActual)
    {
        calificacion.text = CalificacionActual.ToString(); //Muestra la claificacion en el panel

        BarritaCalificacion.value = CalificacionActual; //Se le asigna a la barra el valor de CalificacionActual

        if(CalificacionActual < 6) //Si CalificacionActual es menor a 6 pinta la linea de color red
        {
            BarritaCalifacionIMG.color = Color.red;
        }
        else if (CalificacionActual < 8) //Sino pintala de amarillo
        {
            BarritaCalifacionIMG.color = Color.yellow;
        }
    }

    public void MuestraTiempoClase(int TiempoRestante)
    {
        TiempoDeClase.text = TiempoRestante.ToString(); //Asigna al cuadro de texto del panel el valor de la hora inicial

        BarritaHorario.value = TiempoRestante; //asigna a la barra el valor de TiempoRestante

        if (TiempoRestante < 3)
        {
            BarritaTiempoIMG.color = Color.red;
        }
        else if(TiempoRestante < 5)
        {
            BarritaTiempoIMG.color = Color.yellow;
        }
    }

    /*public void MuestraPregunta()
    {
        string line;
        StreamReader LeePregunta = new StreamReader("preguntas.txt");
        line = LeePregunta.ReadLine();
        NumeroArriba.text = line.Substring(0, 2);
        NumeroAbajo.text = line.Substring(3, 1);
        LeePregunta.Close();
    }*/
    public void CambiaPregunta()
    {
        int[] array = new int[4] { -1, -1, -1, -1 }; //Inicializar arreglo y colocar placeholder sino truena el juego
        int number; // Numero a introducir

        for (int i = 0; i < 4; i++)
        {
            number = Random.Range(0, 4); //El rango maximo debe ser uno mas de los que puede tomar si el rango es de 0 a 3 => rango es de 0 a 4
            if (!array.Contains(number)) //Si el numero no es epetido introducelo al arreglo
                array[i] = number;
            else //si el numero es repetido resta para mantenerte en la misma posicion
                i--;
        }
        int[] preguntasciclicas = new int[1] { -1,}; //Inicializar arreglo y colocar placeholder sino truena el juego
        int numero; // Numero a introducir

        for (int i = 0; i < 1; i++)
        {
            numero = Random.Range(0, 26); //El rango maximo debe ser uno mas de los que puede tomar si el rango es de 0 a 3 => rango es de 0 a 4
            if (!preguntasciclicas.Contains(numero)) //Si el numero no es epetido introducelo al arreglo
                preguntasciclicas[i] = numero;
            else //si el numero es repetido resta para mantenerte en la misma posicion
                i--;
        }
        contador = preguntasciclicas[0];
        /*for (int i = 0; i < contador; i++)
        {
            linea = LeePregunta.ReadLine();
            NumeroArriba.text = linea.Substring(0, 2);
            NumeroAbajo.text = linea.Substring(3, 1);
            responde = LeeRespuesta.ReadLine();
        } */
        //contador++;
        NumeroArriba.text = linea[preguntasciclicas[0]].Substring(0, 2);
        NumeroAbajo.text = linea[preguntasciclicas[0]].Substring(3, 1);
        R1.GetComponentInChildren<Text>().text = responde[contador + array[0]];
        R2.GetComponentInChildren<Text>().text = responde[contador + array[1]];
        R3.GetComponentInChildren<Text>().text = responde[contador + array[2]];
        R4.GetComponentInChildren<Text>().text = responde[contador + array[3]];
        //LeePregunta.Close();
        //LeeRespuesta.Close();
    }
    public void ValidaPreguntaR1()
    {
        if (responde[contador] == R1.GetComponentInChildren<Text>().text)
        {
            CambiaPregunta();
            tiempo--;
            VerificaTiempo();
        }
        else
        {
            CambiaPregunta();
            nota--;
            VerificaNota();
        }
    }
    public void ValidaPreguntaR2()
    {
        if (responde[contador] == R2.GetComponentInChildren<Text>().text)
        {
            CambiaPregunta();
            tiempo--;
            VerificaTiempo();
        }
        else
        {
            CambiaPregunta();
            nota--;
            VerificaNota();
        }
    }
    public void ValidaPreguntaR3()
    {
        if (responde[contador] == R3.GetComponentInChildren<Text>().text)
        {
            CambiaPregunta();
            tiempo--;
            VerificaTiempo();
        }
        else
        {
            CambiaPregunta();
            nota--;
            VerificaNota();
        }
    }
    public void ValidaPreguntaR4()
    {
        if (responde[contador] == R4.GetComponentInChildren<Text>().text)
        {
            CambiaPregunta();
            tiempo--;
            VerificaTiempo();
        }
        else
        {
            CambiaPregunta();
            nota--;
            VerificaNota();
        }
    }
    private void VerificaTiempo()
    {
        if (tiempo == 0)
        {
            ComoSalio = "Tu calificación final es: " + nota + "\n¡Lograste salir temprano de la clase!";
            GameOver();
        }
        else
        {
            MuestraTiempoClase(tiempo);
        }
    }
    private void VerificaNota()
    {
        if (nota == 0)
        {
            ComoSalio = "Vaya me parace que has Reprobado "+ "\nHas terminado con 0 de Calificación";
            GameOver2();
        }
        else
        {
            MuestraCalificacion(nota);
        }
    }
    public void GameOver()
    {
        UIJuego.SetActive(false);
        UIGameOver.SetActive(true); //Muestra GameOver
        IMGAprobado.SetActive(true);
        IMGReprobado.SetActive(false);
        LblResultado.text = ComoSalio;
    }
    public void GameOver2()
    {
        UIJuego.SetActive(false);
        UIGameOver.SetActive(true); //Muestra GameOver
        IMGAprobado.SetActive(false);
        IMGReprobado.SetActive(true);
        LblResultado.text = ComoSalio;
    }
    public void RegresarAClase()
    {
        UIJuego.SetActive(true); //Activa el menu de login
        UIGameOver.SetActive(false);
        nota = 10;
        tiempo = 6;
        MuestraTiempoClase(tiempo);
        MuestraCalificacion(nota);
        BarritaCalifacionIMG.color = Color.green;
        BarritaTiempoIMG.color = Color.green;
    }
    public void SalirJuego()
    {
        Application.Quit();
    }
}
