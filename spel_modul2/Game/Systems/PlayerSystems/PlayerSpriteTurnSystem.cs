﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using GameEngine.Managers;
using GameEngine.Components;
using System.Diagnostics;
using GameEngine.Systems;
using Game.Components;

namespace Game.Systems
{
    class PlayerSpriteTurnSystem : ISystem
    {
        public void Update(GameTime gameTime)
        {
            ComponentManager cm = ComponentManager.GetInstance();
            foreach(var entity in cm.GetComponentsOfType<ArmComponent>())
            {
                ArmComponent armComp = (ArmComponent)entity.Value;
                MoveComponent moveComp = cm.GetComponentForEntity<MoveComponent>(armComp.playerID);
                AnimationGroupComponent armAnimation = cm.GetComponentForEntity<AnimationGroupComponent>(entity.Key);
                if (!cm.HasEntityComponent<AnimationGroupComponent>(armComp.playerID))
                    return;
                AnimationGroupComponent playerAnimation = cm.GetComponentForEntity<AnimationGroupComponent>(armComp.playerID);
                int animation = GetAnimationRow(moveComp.Direction);
                
                armAnimation.ActiveAnimation = animation;
                playerAnimation.ActiveAnimation = animation;

                if (cm.HasEntityComponent<InventoryComponent>(armComp.playerID))
                {
                    InventoryComponent invenComp = cm.GetComponentForEntity<InventoryComponent>(armComp.playerID);
                    ChangeEquipmentDirection(cm, ref invenComp, 0, animation);
                    ChangeEquipmentDirection(cm, ref invenComp, 1, animation);
                    ChangeEquipmentDirection(cm, ref invenComp, 2, animation);
                }
            }
        }

        void ChangeEquipmentDirection(ComponentManager cm, ref InventoryComponent invenComp, int pos, int anim)
        {
            if (invenComp.WeaponBodyHead[pos] != 0 && cm.HasEntityComponent<AnimationGroupComponent>(invenComp.WeaponBodyHead[pos]))
            {
                AnimationGroupComponent animGroupComp = cm.GetComponentForEntity<AnimationGroupComponent>(invenComp.WeaponBodyHead[pos]);
                animGroupComp.ActiveAnimation = anim;
            }
        }

        int GetAnimationRow(Point direction)
        {
            if (direction.X > 0 && direction.Y == 0)
                return 3;
            else if (direction.X == 0 && direction.Y > 0)
                return 0;
            else if (direction.X < 0 && direction.Y == 0)
                return 1;
            else
                return 2;
        }
    }
}
