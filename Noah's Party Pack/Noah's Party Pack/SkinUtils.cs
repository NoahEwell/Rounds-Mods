using UnityEngine;

public static class SkinUtils
{
    public static void SetPlayerColor(Player player, Color color)
    {
        if (player == null) return;
        SetColorOnGameObject(player.gameObject, color);
    }

    public static void SetColorOnGameObject(GameObject obj, Color color)
    {
        if (obj == null) return;

        PlayerSkinHandler skinHandler = obj.GetComponentInChildren<PlayerSkinHandler>();
        if (skinHandler == null) return;

        // Force init
        var initMethod = typeof(PlayerSkinHandler).GetMethod("Init", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance);
        initMethod?.Invoke(skinHandler, null);

        var skinParticles = skinHandler.GetComponentsInChildren<PlayerSkinParticle>();
        foreach (var particle in skinParticles)
        {
            var renderer = particle?.GetComponent<Renderer>();
            if (renderer != null)
            {
                renderer.material.color = color;
            }
        }
    }
}
