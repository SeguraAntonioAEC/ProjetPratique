using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    public static GameData lastData = null;

    public static void SaveGame(DogData[] _dogData)
    {
        GameData Data = new GameData(_dogData);
        string jsonContent = JsonUtility.ToJson(Data);
        File.WriteAllText(Application.persistentDataPath + "/savedgame.json", jsonContent);
    }

    public static GameData LoadGame()
    {
        GameData gameData = null;
        string path = Application.persistentDataPath + "/SavedGame.json";

        if (File.Exists(path))
        {
            string LoadedContent = File.ReadAllText(path);
            gameData = JsonUtility.FromJson<GameData>(LoadedContent);
            lastData = gameData;
        }
        return lastData;
    }
}

[System.Serializable]
public class GameData
{
    public struct LastPosition
    {
        public float posX;
        public float posY;
        public float posZ;
    }

    public LastPosition[] dogsPosition;
    public int itemsCollected; 

    public GameData(DogData[] _dogData)
    {
        for (int i = 0; i < _dogData.Length; i++)
        {
            dogsPosition[i].posX = _dogData[i].lastSafePosition.x;
            dogsPosition[i].posY = _dogData[i].lastSafePosition.y;
            dogsPosition[i].posZ = _dogData[i].lastSafePosition.z;
        }

        itemsCollected = 0;
    }
}

public class GameDataManager : MonoBehaviour
{ 

}
