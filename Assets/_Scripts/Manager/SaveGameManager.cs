using UnityEngine;

public class SaveGameManager : Singleton<SaveGameManager>
{
    [SerializeField] private int dollHasDone;

    public bool newGame = false;

    private void Start()
    {
        newGame = PlayerPrefs.GetInt("NewGame", 0) == 1;
        if (newGame)
        {
            PlayerPrefs.DeleteAll();
        }
        {
            dollHasDone = PlayerPrefs.GetInt("DollHasDone", 0);
            SpawnDollForSave();
            TeleItemToSavePos();
        }
    }

    private void SpawnDollForSave()
    {
        int spawnCount = Mathf.Min(dollHasDone, GameController.Instance.dollsToCheck.Count);

        for (int i = 0; i < spawnCount; i++)
        {

            GameObject dollPrefab = GameController.Instance.dollsToCheck[0];

            GameObject dollClone = Instantiate(dollPrefab, GameController.Instance.trash, Quaternion.identity);
            Doll dollScript = dollClone.GetComponent<Doll>();
            string idKey = dollScript.dollID.ToString();


            dollScript.dollTestStatus.isTypeCorrect = PlayerPrefs.GetInt(idKey + "_isTypeCorrect", 0) == 1;
            dollScript.dollTestStatus.isTestCorrect = PlayerPrefs.GetInt(idKey + "_isTestCorrect", 0) == 1;
            GameController.Instance.dollsHasDone.Add(dollClone);

            
            GameController.Instance.dollsToCheck.RemoveAt(0);
        }
    }

    private void TeleItemToSavePos()
    {
        Vector3 playerSavePos = new Vector3(PlayerPrefs.GetFloat("PlayerPosX", 0), PlayerPrefs.GetFloat("PlayerPosY", 0), PlayerPrefs.GetFloat("PlayerPosZ", 0));
        if (playerSavePos == Vector3.zero)
        {

        }
        else
        {
            CharacterController cc = ResetItemManager.Instance.player.GetComponent<CharacterController>();

            cc.enabled = false;
            ResetItemManager.Instance.player.transform.position = playerSavePos;
            cc.enabled = true;
        }

        Vector3 tempSavePos = new Vector3(PlayerPrefs.GetFloat("TempurationPosX", 0), PlayerPrefs.GetFloat("TempurationPosY", 0), PlayerPrefs.GetFloat("TempurationPosZ", 0));

        if (tempSavePos != Vector3.zero)
        {
            ResetItemManager.Instance.tempuration.transform.position = tempSavePos;
        }

        Vector3 scissorSavePos = new Vector3(PlayerPrefs.GetFloat("ScissorPosX", 0), PlayerPrefs.GetFloat("ScissorPosY", 0), PlayerPrefs.GetFloat("ScissorPosZ", 0));

        if (scissorSavePos != Vector3.zero)
        {
            ResetItemManager.Instance.scissor.transform.position = scissorSavePos;
        }


        Vector3 flashSavePos = new Vector3(PlayerPrefs.GetFloat("FlashlightPosX", 0), PlayerPrefs.GetFloat("FlashlightPosY", 0), PlayerPrefs.GetFloat("FlashlightPosZ", 0));

        if (flashSavePos != Vector3.zero)
        {
            ResetItemManager.Instance.flashlight.transform.position = flashSavePos;
        }
    }
}
