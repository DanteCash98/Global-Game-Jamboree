using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FireflyCluster : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("Firefly center collision");
        other.gameObject.SendMessage("AddLight", 10f, SendMessageOptions.RequireReceiver);

    }
}
