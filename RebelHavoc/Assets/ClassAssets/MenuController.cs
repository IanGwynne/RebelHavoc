using UnityEngine;
using UnityEngine.UI;

namespace Platformer397
{
    public class MenuController : MonoBehaviour
    {
        [SerializeField] private Button play;
        [SerializeField] private Button load;
        [SerializeField] private Button options;
        [SerializeField] private Button quit;
     
        
       private void Start()
        {
             play.onClick.AddListener(() => SceneController.Instance.ChangeScene("Gameplay"));
        }
    }
}
