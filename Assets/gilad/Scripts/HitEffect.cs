using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public static LinkedList<GameObject> Hits { get; set; }

    [SerializeField] private GameObject effect;
    
    // Start is called before the first frame update
    
    void Deactivate()
    {
        Hits.AddFirst(gameObject);
        gameObject.SetActive(false);
    }
}
