using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    [SerializeField] private int dollHasDone;

    private void Start()
    {
        dollHasDone = PlayerPrefs.GetInt("DollHasDone", 0);
        SpawnDollForSave();
    }

    private void SpawnDollForSave()
    {
        for (int i = 0; i < dollHasDone; i++)
        {
            GameObject doll = Instantiate(GameController.Instance.dollsHasDone[i], GameController.Instance.spawnPointForDoll.position, Quaternion.identity);
        }
    }
}
