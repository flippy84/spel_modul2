﻿using GameEngine.Components;
using GameEngine.Managers;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Systems
{
    // This is for debugging attacks
    public class RenderAttackingCollisionBoxSystem : ISystem, IRenderSystem
    {
        public void Render(RenderHelper rh)
        {
            GraphicsDevice gd = rh.graphicsDevice;
            ComponentManager cm = ComponentManager.GetInstance();
            Viewport viewport = Extensions.GetCurrentViewport(gd);
            foreach (var Entity in cm.GetComponentsOfType<AttackComponent>())
            {
                AttackComponent attackComponent = (AttackComponent)Entity.Value;
                if (attackComponent.AttackCooldown > 0.0f)
                {
                    MoveComponent moveComponent = cm.GetComponentForEntity<MoveComponent>(Entity.Key);
                    PositionComponent positionComponent = cm.GetComponentForEntity<PositionComponent>(Entity.Key);
                    if (attackComponent.Type == WeaponType.Sword)
                    {
                        CollisionComponent collisionComponent = cm.GetComponentForEntity<CollisionComponent>(Entity.Key);
                        int range = collisionComponent.CollisionBox.Size.X;
                        Point hitOffset = new Point((collisionComponent.CollisionBox.Width / 2), (collisionComponent.CollisionBox.Height / 2));
                        Rectangle hitArea = new Rectangle(positionComponent.Position.ToPoint() - hitOffset + moveComponent.Direction * new Point(range, range), collisionComponent.CollisionBox.Size).WorldToScreen(ref viewport);
                        if(attackComponent.IsAttacking)
                            rh.DrawFilledRectangle(hitArea, Color.Red, RenderLayer.Foreground1);
                        else
                            rh.DrawFilledRectangle(hitArea, Color.Red, RenderLayer.Foreground1);
                    }
                }
            }
        }

        public void Update(GameTime gameTime)
        {
        }
    }
}
