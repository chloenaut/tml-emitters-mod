﻿using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Helpers.UI;
using Emitters.Items;


namespace Emitters.Definitions {
	public partial class EmitterDefinition : BaseEmitterDefinition {
		public void Draw( SpriteBatch sb, int tileX, int tileY, bool isOnScreen ) {
			var wldPos = new Vector2( (tileX<<4)+8, (tileY<<4)+8 );

			this.AnimateEmitter( wldPos );

			if( isOnScreen && EmitterItem.CanViewEmitters(Main.LocalPlayer) ) {
				this.DrawEmitterTile( sb, tileX, tileY );
			}
		}


		////////////////

		public void DrawEmitterTile( SpriteBatch sb, int tileX, int tileY ) {
			Vector2 wldPos = new Vector2( tileX << 4, tileY << 4 );
			Vector2 scr = UIHelpers.ConvertToScreenPosition( wldPos );

			sb.Draw(
				texture: EmittersMod.Instance.EmitterTex,
				position: scr,
				sourceRectangle: null,
				color: Color.White,
				rotation: 0f,
				origin: default(Vector2),
				scale: Main.GameZoomTarget,
				effects: SpriteEffects.None,
				layerDepth: 1f
			);

			this.DrawEmitterInfo( sb, tileX, tileY );
		}

		public void DrawEmitterInfo( SpriteBatch sb, int tileX, int tileY ) {
			var tileRect = new Rectangle( tileX<<4, tileY<<4, 16, 16 );
			Vector2 scrCenter = new Vector2( Main.screenWidth, Main.screenHeight ) * 0.5f;
			Vector2 mouseWld = Main.MouseWorld - Main.screenPosition;
			mouseWld -= scrCenter;
			mouseWld /= Main.GameZoomTarget;
			mouseWld += scrCenter + Main.screenPosition;

			if( tileRect.Contains((int)mouseWld.X, (int)mouseWld.Y) ) {
				string[] fields = this.ToStringFields();
				int y = 0;

				foreach( string field in fields ) {
					Utils.DrawBorderStringFourWay(
						sb: sb,
						font: Main.fontMouseText,
						text: field,
						x: 24 + Main.MouseWorld.X - Main.screenPosition.X,
						y: y + Main.MouseWorld.Y - Main.screenPosition.Y,
						textColor: Color.White,
						borderColor: Color.Black,
						origin: default( Vector2 )
					);
					y += 16;
				}
			}
		}
	}
}
