namespace ByteBrewSDK
{
    using System.IO;
    using UnityEditor;
    using UnityEngine;

    public static class ByteBrewSettingsManager
    {
        private static string assetPath = "Assets/ByteBrewSDK/Resources/ByteBrewSettings.asset";

        public static ByteBrewSettings EnsureByteBrewSettings()
        {
            // Try to load the ByteBrewSettings ScriptableObject
            ByteBrewSettings settings = AssetDatabase.LoadAssetAtPath<ByteBrewSettings>(assetPath);

            if (settings == null)
            {
                // Ensure the directory exists
                string directory = Path.GetDirectoryName(assetPath);
                if (!Directory.Exists(directory))
                {
                    Directory.CreateDirectory(directory);
                    AssetDatabase.Refresh();
                }

                // Create a new instance of ByteBrewSettings if it wasn't found
                settings = ScriptableObject.CreateInstance<ByteBrewSettings>();
            
                // Save the new ScriptableObject to the specified path
                AssetDatabase.CreateAsset(settings, assetPath);
                AssetDatabase.SaveAssets();
                AssetDatabase.Refresh();

                Debug.Log("ByteBrewSettings asset created at: " + assetPath);
            }

            return settings;
        }
    }
}