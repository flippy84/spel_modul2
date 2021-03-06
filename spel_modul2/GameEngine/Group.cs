﻿using GameEngine.Components;
using GameEngine.Managers;
using System;
using System.Collections;
using System.Collections.Generic;

/* Use a group if you need a collection of components for an entity often.
 * The group keeps track and updates itself when new entities are added or removed.
 * For best performance instantiate the groups type parameters from least used to most used eg.
 * new Group<PlayerComponent, PositionComponent> in this way dictionary lookups are reduced when the group
 * handles events internally. 
 */

namespace GameEngine
{
    public class Group<T1, T2> : IEnumerable<EntityTuple<T1, T2>>
    {
        ComponentManager cm = ComponentManager.GetInstance();
        Dictionary<int, EntityTuple<T1, T2>> entities;
        Type t1, t2;

        public Group()
        {
            cm.OnComponentAdded += ComponentAdded;
            cm.OnComponentRemoved += ComponentRemoved;
            cm.OnEntityRemoved += EntityRemoved;

            entities = new Dictionary<int, EntityTuple<T1, T2>>();
            t1 = typeof(T1);
            t2 = typeof(T2);
        }

        private void EntityRemoved(int entity)
        {
            entities.Remove(entity);
        }

        private void ComponentRemoved(int entity, IComponent component)
        {
            Type t = component.GetType();
            if (t == t1 || t == t2)
                entities.Remove(entity);
        }

        private void ComponentAdded(int entity, IComponent component)
        {
            IComponent v1, v2;
            Dictionary<Type, IComponent> components;
            Type t;

            if (entities.ContainsKey(entity))
                return;
            t = component.GetType();
            components = cm.GetComponentsForEntity(entity);
            if (components.TryGetValue(t1, out v1) &&
                components.TryGetValue(t2, out v2))
                entities.Add(entity, EntityTuple.Create(entity, (T1)v1, (T2)v2));
        }

        public IEnumerator<EntityTuple<T1, T2>> GetEnumerator()
        {
            foreach (var entity in entities)
            {
                yield return entity.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var entity in entities)
            {
                yield return entity.Value;
            }
        }
    }

    public class Group<T1, T2, T3> : IEnumerable<EntityTuple<T1, T2, T3>>
    {
        ComponentManager cm = ComponentManager.GetInstance();
        Dictionary<int, EntityTuple<T1, T2, T3>> entities;
        Type t1, t2, t3;

        public Group()
        {
            cm.OnComponentAdded += ComponentAdded;
            cm.OnComponentRemoved += ComponentRemoved;
            cm.OnEntityRemoved += EntityRemoved;

            entities = new Dictionary<int, EntityTuple<T1, T2, T3>>();
            t1 = typeof(T1);
            t2 = typeof(T2);
            t3 = typeof(T3);
        }

        private void EntityRemoved(int entity)
        {
            entities.Remove(entity);
        }

        private void ComponentRemoved(int entity, IComponent component)
        {
            Type t = component.GetType();
            if (t == t1 || t == t2 || t == t3)
                entities.Remove(entity);
        }

        private void ComponentAdded(int entity, IComponent component)
        {
            IComponent v1, v2, v3;
            Dictionary<Type, IComponent> components;
            Type t;

            if (entities.ContainsKey(entity))
                return;
            t = component.GetType();
            components = cm.GetComponentsForEntity(entity);
            if (components.TryGetValue(t1, out v1) &&
                components.TryGetValue(t2, out v2) &&
                components.TryGetValue(t3, out v3))
                entities.Add(entity, EntityTuple.Create(entity, (T1)v1, (T2)v2, (T3)v3));
        }

        public IEnumerator<EntityTuple<T1, T2, T3>> GetEnumerator()
        {
            foreach (var entity in entities)
            {
                yield return entity.Value;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var entity in entities)
            {
                yield return entity.Value;
            }
        }
    }
}
