using UnityEngine;

public enum TargetType { Easy, Hard }

public class TargetFactory : MonoBehaviour
{
    //public GameObject easyTargetPrefab;
    //public GameObject hardTargetPrefab;
    /*public GameObject CreateTarget(TargetType type, Vector3 position)
    {
        GameObject prefab = null;

        switch (type)
        {
            case TargetType.Easy:
                prefab = easyTargetPrefab;
                break;
            case TargetType.Hard:
                prefab = hardTargetPrefab;
                break;
        }

        return Instantiate(prefab, position, Quaternion.identity);
    }*/
    public string easyTag = "EasyTarget";
    public string hardTag = "HardTarget";
    
    public GameObject CreateTarget(TargetType type, Vector3 position)
    {
        string selectedTag = (type == TargetType.Easy) ? easyTag : hardTag;

        GameObject obj = ObjectPooling.Instance.SpawnFromPool(selectedTag, position, Quaternion.identity);

        return obj;
    }
}
