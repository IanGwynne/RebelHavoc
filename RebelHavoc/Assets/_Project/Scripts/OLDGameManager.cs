using UnityEngine;

namespace RebelHavoc
{
    public class GameMannager : Singleton<GameMannager>
    {
       private Transform player;

       private void Start()
       {
           player = GameObject.FindGameObjectWithTag("Player").transform;
       }

       public void SaveGame()
       {
           SaveGameManager.Instance().SaveGame(player);
       }

       public void LoadGame()
       {
           PlayerData data = SaveGameManager.Instance().LoadGame();
           if (data == null) {return;}
           var position = JsonUtility.FromJson<Vector3>(data.position);
           player.position = position;
       }
    }
}
