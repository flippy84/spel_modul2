﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GameEngine.Components
{
    public delegate void ButtonAction();

    public class MenuButtonComponent : IComponent
    {
        public bool IsActive { get; set; }
        public bool Ishighlighted { get; set; }
        public string Name { get; set; }
        public string NormalTexturePath { get; set; }
        public string HighlightTexturePath { get; set; }
        public ButtonAction Use { get; set; }
        public Texture2D NormalTexture { get; set; }
        public Texture2D HighlightTexture { get; set; }
        public Vector2 Position { get; set; }
        public RenderLayer Layer { get; set; }

        public MenuButtonComponent(string name, ButtonAction buttonAction, string normalTexturePath, string highlightTexturePath, Vector2 position, RenderLayer layer)
        {
            IsActive = false;
            Ishighlighted = false;
            Name = name;
            Use = buttonAction;
            NormalTexturePath = normalTexturePath;
            HighlightTexturePath = highlightTexturePath;
            Position = position;
            Layer = layer;
        }

        public object Clone()
        {
            MenuButtonComponent o = (MenuButtonComponent)MemberwiseClone();
            o.Name = string.Copy(Name);
            o.NormalTexturePath = string.Copy(NormalTexturePath);
            o.HighlightTexturePath = string.Copy(HighlightTexturePath);
            return o;
        }
    }
}
