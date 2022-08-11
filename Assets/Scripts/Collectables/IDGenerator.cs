#if UNITY_EDITOR
using UnityEditor;
using UnityEngine;

public class IDGenerator : EditorWindow
{
    private Collectable[] coins;
        
    [MenuItem("Tools/ID Generator")]
    static void CreateGenerateIDs()
    {
        GetWindow<IDGenerator>();
    }
    
    private void OnGUI()
    {
        if (GUILayout.Button("Generate IDs"))
        {
            coins = FindObjectsOfType<Collectable>();
            Debug.Log($"Coins in scene: {coins.Length}");

            int newID = 0;
            foreach (Collectable collectable in coins)
            {
                var so = new SerializedObject(collectable);
                so.FindProperty("CoinID").intValue = newID;
                so.ApplyModifiedProperties();
                newID++;
            }

            EditorGUI.EndChangeCheck();
        }
    }
}
#endif //UNITY_EDITOR