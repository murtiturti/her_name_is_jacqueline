using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightFire : MonoBehaviour
{
    [SerializeField]
    private GameObject fireVFX;
    // Start is called before the first frame update

    public void Light()
    {
        fireVFX.SetActive(true);
    }
    
}
