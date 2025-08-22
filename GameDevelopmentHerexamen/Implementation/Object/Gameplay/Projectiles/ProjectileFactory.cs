using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Scene;
using GameDevelopmentHerexamen.Framework.Utility;
using GameDevelopmentHerexamen.Implementation.Component;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Object.Gameplay.Projectiles {
    public class ProjectileFactory {
        private List<Projectile> projectiles = [];
        private GameScene sceneReference;
        private Random random = new Random();

        public ProjectileFactory(GameScene sceneReference) {
            this.sceneReference = sceneReference;
        }

        public void AddFromPreset(ProjectilePreset preset, UDim2 initialPosition) {
            switch (preset) {
                case ProjectilePreset.FireballLR:
                    Add(new Fireball(true, 750, initialPosition.Y));
                    break;
                case ProjectilePreset.FireballRL:
                    Add(new Fireball(false, 750, initialPosition.Y));
                    break;
                case ProjectilePreset.TrackFireballTopLeft:
                    Add(new TrackingFireball(true, true, 150, PickPlayer()));
                    break;
                case ProjectilePreset.TrackFireballTopRight:
                    Add(new TrackingFireball(false, true, 150, PickPlayer()));
                    break;
                case ProjectilePreset.TrackFireballBottomLeft:
                    Add(new TrackingFireball(true, false, 150, PickPlayer()));
                    break;
                case ProjectilePreset.TrackFireballBottomRight:
                    Add(new TrackingFireball(false, false, 150, PickPlayer()));
                    break;
            }
        }

        private Player PickPlayer() {
            List<GameObject> players = sceneReference.Children.Where(c => c is Player).ToList();
            if (players.Count == 1) return players.First() as Player;
            return players[random.Next(players.Count + 1)] as Player;
        }

        private void Add(Projectile projectile) {
            sceneReference.AddChild(projectile);
            projectiles.Add(projectile);
        }

        private void Remove(Projectile projectile) {
            sceneReference.Children.Remove(projectile);
            projectiles.Remove(projectile);
        }

        public void Cleanup() {
            List<Projectile> forRemoval = [];

            foreach (Projectile projectile in projectiles) {
                if (projectile.AbsolutePosition.X < -projectile.AbsoluteSize.X * 2
                    || projectile.AbsolutePosition.X > SceneManager.Instance.GraphicsDevice.Viewport.Width + projectile.AbsoluteSize.X * 2) {
                    forRemoval.Add(projectile);
                } else if (projectile.AbsolutePosition.Y < -projectile.AbsoluteSize.Y * 2
                    || projectile.AbsolutePosition.Y > SceneManager.Instance.GraphicsDevice.Viewport.Height + projectile.AbsoluteSize.Y * 2) {
                    forRemoval.Add(projectile);
                }
            }

            foreach (Projectile projectile in forRemoval) {
                Remove(projectile);
            }
        }
    }
}
