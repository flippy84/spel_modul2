﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace GameEngine
{
    class ResourceManager
    {
        static ResourceManager instance;
        Dictionary<string, object> resources;

        static ResourceManager()
        {
            instance = new ResourceManager();
        }

        static ResourceManager GetInstance()
        {
            return instance;
        }

        private ResourceManager()
        {
            resources = new Dictionary<string, object>();
        }

        public T GetResource<T>(string name)
        {
            object resource;
            instance.resources.TryGetValue(name, out resource);
            return (T)resource;
        }

        public void AddResource(string name, object resource)
        {
            instance.resources.Add(name, resource);
        }
    }
}