namespace ByteBrewSDK
{
    using UnityEditor;
    using UnityEngine;

    public class AssetLoader
    {
        public static T LoadAssetByName<T>(string name) where T : Object
        {
            // Find all assets that match the name and are of type Texture2D
            string[] guids = AssetDatabase.FindAssets($"{name} t:{typeof(T).Name}");

            if (guids.Length > 0)
            {
                string    path    = AssetDatabase.GUIDToAssetPath(guids[0]); // Taking the first found texture
                T texture = AssetDatabase.LoadAssetAtPath<T>(path);
                if (texture != null)
                {
                    return texture;
                }
            }

            Debug.LogWarning("Texture not found: " + name);
            return null;
        }
    }
}