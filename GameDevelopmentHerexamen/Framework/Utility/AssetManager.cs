using GameDevelopmentHerexamen.Framework.Scene;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Utility {
    public class AssetManager {
        public static AssetManager Instance { get; } = new AssetManager();
        public static Texture2D BlankTexture { get; private set; }

        private ContentManager contentManager;
        private Dictionary<Type, Dictionary<string, object>> assets = [];

        private AssetManager() { }

        public void Initialize(ContentManager contentManager) {
            this.contentManager = contentManager;

            Texture2D blankTexture = new Texture2D(SceneManager.Instance.GraphicsDevice, 1, 1);
            blankTexture.SetData([Color.White]);
            BlankTexture = blankTexture;
        }

        public T Load<T>(string assetName) {
            Type type = typeof(T);

            if (!assets.TryGetValue(type, out Dictionary<string, object> savedAssets)) {
                savedAssets = [];
                assets[type] = savedAssets;
            }

            if (savedAssets.TryGetValue(assetName, out object savedAsset)) {
                return (T) savedAsset;
            }

            T newAsset = contentManager.Load<T>(assetName);
            savedAssets[assetName] = newAsset;
            return newAsset;
        }

        public void UnloadAll() {
            assets.Clear();
            contentManager.Unload();
        }
    }
}
