using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetivoPuntaje : Objetivo
{
    public int puntos = 1;
    public float cambioVelocidad;
    public GameObject prefabTiempoNegativo;
    public GameObject prefabTiempoPositivo;

    protected override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.GetComponent<Player>();
            //player.Alerta();
            player.IncrementarPuntaje(puntos, cambioVelocidad);

            GameObject.Instantiate(prefabTiempoNegativo);
            var obetivoTiempo = prefabTiempoNegativo.GetComponent<ObjetivoTiempo>();
            Destroy(prefabTiempoPositivo);
            obetivoTiempo.ReposicionarNuevo();

            if (player.cubosRojos == 5)
            {
                Debug.Log("ENTRE EN EL IF");
                obetivoTiempo.ReposicionarEspecialEsphera();

                
            }
        }

        base.OnTriggerEnter(other);
    }
}
