using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(fileName = "CustomColliderTile", menuName = "Tiles/Custom Collider Tile")]
public class CustomColliderTile : Tile
{
    [Header("Custom Collider Size (0–1 range)")]
    public Vector2 colliderSize = new Vector2(1f, 1f);

    public override void GetTileData(Vector3Int position, ITilemap tilemap, ref TileData tileData)
    {
        base.GetTileData(position, tilemap, ref tileData);

        // required if you want collider from sprite
        tileData.colliderType = ColliderType.Grid;
    }

    public override bool GetTileAnimationData(Vector3Int position, ITilemap tilemap, ref TileAnimationData tileAnimationData)
    {
        // optional: call base implementation
        return base.GetTileAnimationData(position, tilemap, ref tileAnimationData);
    }
}
