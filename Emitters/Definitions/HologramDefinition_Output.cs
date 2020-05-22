﻿using System;
using Microsoft.Xna.Framework;


namespace Emitters.Definitions {
	public partial class HologramDefinition {
		public void Output(
					out int type,
					out float scale,
					out Color color,
					out byte alpha,
					out int direction,
					out float rotation,
					out int offsetX,
					out int offsetY,
					out int frameStart,
					out int frameEnd,
					out int frameRateTicks,
					out bool worldLight,
					out bool isActivated ) {
			type = this.Type.Type;
			scale = this.Scale;
			color = this.Color;
			alpha = this.Alpha;
			direction = this.Direction;
			rotation = this.Rotation;
			offsetX = this.OffsetX;
			offsetY = this.OffsetY;
			frameStart = this.FrameStart;
			frameEnd = this.FrameEnd;
			frameRateTicks = this.FrameRateTicks;
			worldLight = this.WorldLighting;
			isActivated = this.IsActivated;
		}

		public void Output(
					out int type,
					out float scale,
					out byte colorR,
					out byte colorG,
					out byte colorB,
					out byte alpha,
					out int direction,
					out float rotation,
					out int offsetX,
					out int offsetY,
					out int frameStart,
					out int frameEnd,
					out int frameRateTicks,
					out bool worldLight,
					out bool isActivated ) {
			Color color;
			this.Output(
				out type,
				out scale,
				out color,
				out alpha,
				out direction,
				out rotation,
				out offsetX,
				out offsetY,
				out frameStart,
				out frameEnd,
				out frameRateTicks,
				out worldLight,
				out isActivated
			);
			colorR = color.R;
			colorG = color.G;
			colorB = color.B;
		}


		////////////////

		public string RenderType() {
			return this.Type.ToString();
		}
		public string RenderScale() {
			return (this.Scale * 100f).ToString( "N0" );
		}
		public string RenderColor() {
			return this.Color.ToString();
		}
		public string RenderAlpha() {
			return this.Alpha.ToString();
		}
		public string RenderDirection() {
			return this.Direction.ToString( "N0" );
		}
		public string RenderRotation() {
			return this.Rotation.ToString( "N2" );
		}
		public string RenderOffsetX() {
			return this.OffsetX.ToString();
		}
		public string RenderOffsetY() {
			return this.OffsetY.ToString();
		}
		public string RenderOffset() {
			return this.OffsetX.ToString()+", "+this.OffsetY.ToString();
		}
		public string RenderFrameStart() {
			return this.FrameStart.ToString();
		}
		public string RenderFrameEnd() {
			return this.FrameEnd.ToString();
		}
		public string RenderFrameRateTicks() {
			return this.FrameRateTicks.ToString();
		}
		public string RenderFrame() {
			return "#"+this.CurrentFrame+" between "+this.FrameStart+" and "+this.FrameEnd+" (rate: "+this.FrameRateTicks+")";
		}

		////////////////

		public override string ToString() {
			return "Emitter Definition:"
				+/*"\n"+*/" Type: " + this.RenderType() + ", "
				+/*"\n"+*/" Scale: " + this.RenderScale() + ", "
				+/*"\n"+*/" Color: " + this.RenderColor() + ", "
				+/*"\n"+*/" Alpha: " + this.RenderAlpha() + ", "
				+/*"\n"+*/" Direction: " + this.RenderDirection() + ", "
				+/*"\n"+*/" Rotation: " + this.RenderRotation() + ", "
				+/*"\n"+*/" Offset: " + this.RenderOffset() + ", "
				+/*"\n"+*/" Frame: " + this.RenderFrame() + ", "
				+/*"\n"+*/" WorldLight: " + this.WorldLighting + ", "
				+/*"\n"+*/" IsActivated: " + this.IsActivated;
		}
	}
}