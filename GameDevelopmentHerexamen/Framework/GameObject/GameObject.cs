using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.GameObject {
    public abstract class GameObject : IGameObject {
        public UDim2 Position { get; set; }
        public UDim2 Size { get; set; }
        public Vector2 Anchor { get; set; } = Vector2.Zero;
        public int ZIndex { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsVisible { get; set; } = true;

        protected List<GameObject> children = [];
        protected IGameObject parent;

        public static bool DrawDebugBounds = false;
        private static Texture2D debugBoundsAsset;

        public static void InitializeDebug(GraphicsDevice graphicsDevice) {
            debugBoundsAsset = new Texture2D(graphicsDevice, 1, 1);
            debugBoundsAsset.SetData([Color.White]);
        }

        public void AddChild(GameObject child) {
            child.parent = this;
            children.Add(this);
        }

        public void AddChildren(List<GameObject> children) {
            foreach (GameObject child in children) {
                AddChild(child);
            }
        }

        public virtual void Update(GameTime gameTime) {
            if (!IsActive) return;

            foreach (GameObject child in children) {
                child.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (!IsVisible) return;

            foreach (GameObject child in children.OrderByDescending(c => c.ZIndex)) {
                child.Draw(spriteBatch);
            }
        }

        public virtual void HandleInput(InputState inputState) {
            foreach (GameObject child in children) {
                child.HandleInput(inputState);
            }
        }
    }
}
