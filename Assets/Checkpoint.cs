using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Checkpoint : MonoBehaviour
{
    // при столконовении объекта DroneExample c объектом, содержащим этот скрипт, удаляет его
    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.name == "DroneExample")
        {
            Debug.Log("Its a hit!");
            Destroy(this.gameObject);
            Rules.score++;
        }
    }
}