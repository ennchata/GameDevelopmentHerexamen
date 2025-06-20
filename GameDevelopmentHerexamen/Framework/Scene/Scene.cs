using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Utility;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Scene {
    public abstract class Scene : IGameObject {
        public List<GameObject> Children { get; } = [];

        public void AddChild(GameObject child) {
            child.Parent = this;
            Children.Add(child);
        }

        public void AddChildren(List<GameObject> children) {
            foreach (GameObject child in children) {
                AddChild(child);
            }
        }

        public virtual void Draw(SpriteBatch spriteBatch) {
            foreach (GameObject child in Children.OrderBy(c => c.ZIndex)) {
                child.Draw(spriteBatch);
            }
        }

        public virtual void HandleInput(InputState inputState) {
            foreach (GameObject child in Children) {
                child.HandleInput(inputState);
            }
        }

        public virtual void Update(GameTime gameTime) {
            foreach (GameObject child in Children) {
                child.Update(gameTime);
            }
        }
    }
}
