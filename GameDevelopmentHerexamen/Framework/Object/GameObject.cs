using GameDevelopmentHerexamen.Framework.Object.Component;
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
    public class GameObject : IGameObject {
        public UDim2 Position { get; set; } = new UDim2(0, 0, 0, 0);
        public UDim2 Size { get; set; } = new UDim2(1, 0, 1, 0);
        public Vector2 Anchor { get; set; } = Vector2.Zero;
        public int ZIndex { get; set; } = 0;
        public bool IsActive { get; set; } = true;
        public bool IsVisible { get; set; } = true;

        public List<IComponent> Components { get; set; } = [];
        public IGameObject Parent { get; set; }
        public List<GameObject> Children { get; } = [];

        public Vector2 AbsolutePosition { get; private set; }
        public Vector2 AbsoluteSize { get; private set; }
        public Rectangle Bounds { get; private set; }

        public static bool DrawDebugBounds = false;

        public GameObject() { }
        public GameObject(List<GameObject> children) {
            AddChildren(children);
        }

        public void AddChild(GameObject child) {
            child.Parent = this;
            Children.Add(child);
        }

        public void AddChildren(List<GameObject> children) {
            foreach (GameObject child in children) {
                AddChild(child);
            }
        }

        public void AddComponent(IComponent component) {
            Components.Add(component);
        }

        public void AddComponents(List<IComponent> components) {
            Components.AddRange(components);
        }

        public T GetComponent<T>() where T : IComponent {
            IEnumerable<T> components = Components.OfType<T>();
            
            if (components.Count() == 1) {
                return components.First();
            }

            return default;
        }

        public virtual void Update(GameTime gameTime) {
            if (!IsActive) return;

            Vector2 parentSize = Parent is GameObject 
                ? (Parent as GameObject).AbsoluteSize 
                : new Vector2(SceneManager.Instance.GraphicsDevice.Viewport.Width, SceneManager.Instance.GraphicsDevice.Viewport.Height);
            AbsoluteSize = Size.Resolve(parentSize);
            AbsolutePosition = Position.Resolve(parentSize) - Anchor * AbsoluteSize;
            Bounds = new Rectangle(
                (int)AbsolutePosition.X, (int)AbsolutePosition.Y,
                (int)AbsoluteSize.X, (int)AbsoluteSize.Y
            );

            foreach (IComponent component in Components) {
                component.Update(this, gameTime);
            }

            foreach (GameObject child in Children) {
                child.Update(gameTime);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            if (!IsVisible) return;

            if (DrawDebugBounds && AssetManager.BlankTexture != null) {
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(Bounds.X, Bounds.Y, Bounds.Width, 1), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(Bounds.X, Bounds.Bottom, Bounds.Width, 1), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(Bounds.X, Bounds.Y, 1, Bounds.Height), Color.Red);
                spriteBatch.Draw(AssetManager.BlankTexture, new Rectangle(Bounds.Right, Bounds.Y, 1, Bounds.Height), Color.Red);
            }

            foreach (IComponent component in Components) {
                component.Draw(this, spriteBatch);
            }

            foreach (GameObject child in Children.OrderBy(c => c.ZIndex)) {
                child.Draw(spriteBatch);
            }
        }

        public virtual void HandleInput(InputState inputState) {
            foreach (IComponent component in Components) {
                component.HandleInput(this, inputState);
            }

            foreach (GameObject child in Children) {
                child.HandleInput(inputState);
            }
        }
    }
}
