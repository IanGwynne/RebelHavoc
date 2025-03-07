using Unity.Cinemachine;
using UnityEngine;

namespace RebelHavoc
{
    public class CameraManager : MonoBehaviour
    {
        [SerializeField] private CinemachineCamera freeLookCam;
        [SerializeField] private Transform player;

        private void Awake()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            if (player != null) { return; }
            player = GameObject.FindGameObjectWithTag("Player").transform;
        }

        private void OnEnable()
        {
            freeLookCam.Target.TrackingTarget = player;
        }
    }
}