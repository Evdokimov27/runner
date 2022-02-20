using UnityEngine;
using System.Collections;
 
public class RotateCoin : MonoBehaviour
{
    void Update()
    {
        transform.Rotate(0, 2.0f, 0);
    }
}