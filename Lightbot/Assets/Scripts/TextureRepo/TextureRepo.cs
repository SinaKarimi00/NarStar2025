using System;
using System.Collections.Generic;
using UnityEngine;

namespace DefaultNamespace.TextureRepo
{
    [CreateAssetMenu(fileName = "TextureRepo", menuName = "Game/TextureRepo")]
    public class TextureRepo : ScriptableObject
    {
        [SerializeField] private List<Texture> textures;
        [SerializeField] private List<SpriteHumble> sprites;

        public Material GetMaterial(int id)
        {
            foreach (var texture in textures)
            {
                if (texture.TextureId == id)
                {
                    return texture.Material;
                }
            }

            return null;
        }

        public Sprite GetSprite(int id)
        {
            foreach (var sprite in sprites)
            {
                if (sprite.TextureId == id)
                {
                    return sprite.Sprite;
                }
            }

            return null;
        }
    }

    [Serializable]
    public class Texture
    {
        public int TextureId;
        public Material Material;
    }

    [Serializable]
    public class SpriteHumble
    {
        public int TextureId;
        public Sprite Sprite;
    }
}