using UnityEngine;

namespace AriozoneGames.Interaction
{
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
}
