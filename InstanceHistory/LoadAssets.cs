using MelonLoader;
using UnityEngine;
using System.IO;


namespace InstanceHistory
{
    class LoadAssets
    {
        public static Sprite instanceHistoryIcon, UpArrow, DownArrow;
        public static void loadAssets()
        {
            instanceHistoryIcon = LoadEmbeddedImages("instanceHistoryIcon.png");
            UpArrow = LoadEmbeddedImages("UpArrow.png");
            DownArrow = LoadEmbeddedImages("DownArrow.png");
        }

        private static Sprite LoadEmbeddedImages(string imageName)
        {
            try
            {
                //Load image into Texture
                using var assetStream = System.Reflection.Assembly.GetExecutingAssembly().GetManifestResourceStream("InstanceHistory.Images." + imageName);
                using var tempStream = new MemoryStream((int)assetStream.Length);
                assetStream.CopyTo(tempStream);
                var Texture2 = new Texture2D(2, 2);
                ImageConversion.LoadImage(Texture2, tempStream.ToArray());
                Texture2.wrapMode = TextureWrapMode.Clamp;
                Texture2.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                //Texture to Sprite
                var rec = new Rect(0.0f, 0.0f, Texture2.width, Texture2.height);
                var piv = new Vector2(.5f, 5f);
                var border = Vector4.zero;
                var s = Sprite.CreateSprite_Injected(Texture2, ref rec, ref piv, 100.0f, 0, SpriteMeshType.Tight, ref border, false);
                s.hideFlags |= HideFlags.DontUnloadUnusedAsset;
                return s;
            }
            catch (System.Exception ex) { MelonLogger.Error("Failed to load image from asset bundle: " + imageName + "\n" + ex.ToString()); return null; }
        }
    }

    public static class StringExt
    {
        public static string Truncate(this string value, int maxLength)
        {
            if (string.IsNullOrEmpty(value)) return value;
            return value.Length <= maxLength ? value : value.Substring(0, maxLength);
        }
    }
}
