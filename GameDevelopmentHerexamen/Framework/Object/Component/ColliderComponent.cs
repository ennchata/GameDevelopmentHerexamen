using GameDevelopmentHerexamen.Framework.Scene;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Framework.Object.Component {
    public class ColliderComponent : IComponent {
        public int Order { get; set; } = 0;
        public Dictionary<GameObject, bool> Collisions { get; private set; } = [];

        public static List<GameObject> Colliders = [];

        public delegate void CollisionEventHandler(GameObject other, bool isColliding);
        public event CollisionEventHandler CollisionEvent;
        private Dictionary<GameObject, bool> previousCollisions = [];

        public ColliderComponent(
                Action<GameObject, bool> anyHandler = null,
                Action<GameObject> collisionEnterHandler = null,
                Action<GameObject> collisionLeaveHandler = null) {
            CollisionEvent += (other, isColliding) => {
                anyHandler?.Invoke(other, isColliding);

                if (isColliding) {
                    collisionEnterHandler?.Invoke(other);
                } else {
                    collisionLeaveHandler?.Invoke(other);
                }
            };
        }

        public void Update(GameObject owner, GameTime gameTime) {
            foreach (GameObject collider in Colliders) {
                if (collider == owner) {
                    continue;
                }

                ColliderComponent colliderComponent = collider.GetComponent<ColliderComponent>();

                bool isColliding;
                if (colliderComponent.Collisions.TryGetValue(owner, out bool isCollidingCalculated)) {
                    isColliding = isCollidingCalculated;
                } else {
                    isColliding = owner.Bounds.Intersects(collider.Bounds);
                }

                Collisions[collider] = isColliding;

                if (previousCollisions.TryGetValue(collider, out bool wasColliding) && isColliding != wasColliding) {
                    CollisionEvent.Invoke(collider, isColliding);
                }
            }

            previousCollisions = new Dictionary<GameObject, bool>(Collisions);
        }

        public static void CollectColliders() {
            Colliders.Clear();

            foreach (GameObject child in SceneManager.Instance.CurrentScene.Children) {
                Traverse(child);
            }
        }

        private static void Traverse(GameObject gameObject) {
            if (!gameObject.IsActive) {
                return;
            }

            ColliderComponent gameObjectCollider = gameObject.GetComponent<ColliderComponent>();
            if (gameObjectCollider != null) {
                gameObjectCollider.Collisions.Clear();
                Colliders.Add(gameObject);
            }

            foreach (GameObject child in gameObject.Children) {
                Traverse(child);
            }
        }
    }
}
