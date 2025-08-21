using GameDevelopmentHerexamen.Framework.Object;
using GameDevelopmentHerexamen.Framework.Object.Component;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameDevelopmentHerexamen.Implementation.Component {
    public class PhysicsComponent : IComponent {
        public static int NormalTerminalYVelocity = 480;
        public static int NormalGravity = 22;

        public int TerminalYVelocity { get; set; } = NormalTerminalYVelocity;
        public int Gravity { get; set; } = NormalGravity;

        public bool GravityAffected { get; set; } = true;
        public Vector2 Velocity { get; set; } = Vector2.Zero;

        public int Order { get; set; } = 0;

        public void Update(GameObject owner, GameTime gameTime) {
            Vector2 normalisedVelocity = Velocity * (gameTime.ElapsedGameTime.Milliseconds / 1000f);
            (int X, int Y) actualVelocity = ((int)Math.Round(normalisedVelocity.X), (int)Math.Round(normalisedVelocity.Y));
            owner.Position += actualVelocity;

            if (!GravityAffected) return;
            Velocity = new Vector2(Velocity.X, Math.Min(Velocity.Y + Gravity, TerminalYVelocity));
        }
    }
}
