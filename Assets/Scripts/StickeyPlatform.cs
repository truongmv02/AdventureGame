using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickeyPlatform : MonoBehaviour
{

    Transform parentObject = null;
    private void OnTriggerEnter2D(Collider2D other)
    {
        parentObject = other.transform.parent;
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        other.transform.SetParent(parentObject);
    }
}
