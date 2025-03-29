using UnityEngine;

namespace Platformer397
{
    public class MiniMapCam : MonoBehaviour
    {
        [SerializeField] private Transform player;
        private void Start()
        {
           if (player != null) {return;}
           player = GameObject.FindWithTag("Player").transform;
        }

        
        private void FixedUpdate()
        {
            transform.position = new Vector3(player.position.x,transform.position.y,player.position.z);
        }
    }
}
