using UnityEngine;

namespace RebelHavoc
{
    public class GameManager : MonoBehaviour
    {
        private Transform player;

        public static GameManager Instance { get; private set; }
        [SerializeField] private GameObject pauseMenuCanvas;
        [SerializeField] private VirtualJoystick virtualJoystick; // Reference to the virtual joystick

        private bool isPaused = false;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        private void Start()
        {
            player = GameObject.FindGameObjectWithTag("Player").transform;

            // Unlock the cursor and make it visible
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }



        public void TogglePause()
        {
            isPaused = !isPaused;
            Time.timeScale = isPaused ? 0 : 1;
            pauseMenuCanvas.SetActive(isPaused);

            if (isPaused)
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                EnableJoystick(false); // Disable joystick when paused
            }
            else
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                EnableJoystick(true); // Enable joystick when resuming
            }
        }

        public void EnableJoystick(bool enable)
        {
            if (virtualJoystick != null)
            {
                virtualJoystick.gameObject.SetActive(enable);
            }
        }

        public void RepositionJoystick(Vector2 newPosition)
        {
            if (virtualJoystick != null)
            {
                RectTransform joystickRect = virtualJoystick.GetComponent<RectTransform>();
                joystickRect.anchoredPosition = newPosition;
            }
        }
        public void SaveGame()
        {
            SaveGameManager.Instance().SaveGame(player);
        }

        public void LoadGame()
        {
            PlayerData data = SaveGameManager.Instance().LoadGame();
            if (data == null) { return; }
            var position = JsonUtility.FromJson<Vector3>(data.position);
            player.position = position;
        }
    }
}
