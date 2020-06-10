using System;
using Microsoft.Xna.Framework;
using Terraria;
using Terraria.ModLoader;
using HamstarHelpers.Helpers.DotNET.Extensions;
using Emitters.Definitions;


namespace Emitters {
	public partial class EmittersWorld : ModWorld {
		public override void PostDrawTiles() {
			int leftTile = (int)Main.screenPosition.X >> 4;
			int topTile = (int)Main.screenPosition.Y >> 4;
			int tileWidth = Main.screenWidth >> 4;
			int tileHeight = Main.screenHeight >> 4;

			int minX = Math.Max( leftTile, 0 );
			int minY = Math.Max( topTile, 0 );
			int maxX = leftTile + tileWidth + 1;
			int maxY = topTile + tileHeight + 1;

			var scrTiles = new Rectangle( leftTile, topTile, maxX, maxY );
			maxX = Math.Min( maxX + 8, Main.maxTilesX );
			maxY = Math.Min( maxY + 8, Main.maxTilesY );

			Main.spriteBatch.Begin();

			try {
				for( ushort x = (ushort)minX; x < maxX; x++ ) {
					for( ushort y = (ushort)minY; y < maxY; y++ ) {
						bool isOnScr = scrTiles.Contains( x, y );

						if( this.Emitters.TryGetValue2D( x, y, out EmitterDefinition def) ) {
							def.Draw( Main.spriteBatch, x, y, isOnScr );
						}

						if( this.SoundEmitters.TryGetValue2D( x, y, out SoundEmitterDefinition sdef) ) {
							sdef.Draw( Main.spriteBatch, x, y, isOnScr );
						}

						if( this.Holograms.TryGetValue2D( x, y, out HologramDefinition hdef ) ) {
							hdef.Draw( Main.spriteBatch, x, y, isOnScr );
						}
					}
				}
			} finally {
				Main.spriteBatch.End();
			}
		}
	}
}