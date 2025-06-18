using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object {
    public abstract class GameObject : IGameObject {
        public UDim2 Position { get; set; }
        public UDim2 Size { get; set; }
        public Vector2 Anchor { get; set; } = Vector2.Zero;
        public int ZIndex { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsVisible { get; set; } = true;

        public IGameObject Parent { get; set; }
        public List<GameObject> Children { get; } = [];

        public Vector2 AbsolutePosition { get; private set; }
        public Vector2 AbsoluteSize { get; private set; }
        public Rectangle Bounds { get; private set; }

        public static bool DrawDebugBounds = false;
        private static Texture2D debugBoundsAsset;

        public static void InitializeDebug(GraphicsDevice graphicsDevice) {
            debugBoundsAsset = new Texture2D(graphicsDevice, 1, 1);
            debugBoundsAsset.SetData([Color.White]);
        }

        public void AddChild(GameObject child) {
            child.Parent = this;
            Children.Add(this);
        }

        public void AddChildren(List<GameObject> children) {
            foreach (GameObject child in children) {
                AddChild(child);
            }
        }

        public virtual void Update(GameTime gameTime) {
            if (!IsActive) return;

            Vector2 parentSize = Parent is GameObject 
                ? (Parent as GameObject).AbsoluteSize 
                : new Vector2(SceneManager.Instance.GraphicsDevice.Viewport.X, SceneManager.Instance.GraphicsDevice.Viewport.Y);
            AbsoluteSize = Size.Resolve(parentSize);
            AbsolutePosition = Position.Resolve(parentSize) - Anchor * AbsoluteSize;
            Bounds = new Rectangle(
                (int)AbsolutePosition.X, (int)AbsolutePosition.Y,
                (int)AbsoluteSize.X, (int)AbsoluteSize.Y
            );

            foreach (GameObject child in Children) {
                child.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (!IsVisible) return;

            if (DrawDebugBounds && debugBoundsAsset != null) {
                spriteBatch.Draw(debugBoundsAsset, Bounds, new Color(Color.White, 0.2f));
                spriteBatch.Draw(debugBoundsAsset, new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, 1), Color.Red);
                spriteBatch.Draw(debugBoundsAsset, new Rectangle(Bounds.X, Bounds.Bottom, Bounds.Width, 1), Color.Red);
                spriteBatch.Draw(debugBoundsAsset, new Rectangle(Bounds.X, Bounds.Y, 1, Bounds.Height), Color.Red);
                spriteBatch.Draw(debugBoundsAsset, new Rectangle(Bounds.Right, Bounds.Y, 1, Bounds.Height), Color.Red);
            }

            foreach (GameObject child in Children.OrderByDescending(c => c.ZIndex)) {
                child.Draw(spriteBatch);
            }
        }

        public virtual void HandleInput(InputState inputState) {
            foreach (GameObject child in Children) {
                child.HandleInput(inputState);
            }
        }
    }
}
