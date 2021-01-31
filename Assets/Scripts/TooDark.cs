using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TooDark : MonoBehaviour
{
    
    
    #region Karanlık

    public AudioSource karanlıkSes;

    #endregion
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        karanlıkSes.PlayDelayed(3f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
