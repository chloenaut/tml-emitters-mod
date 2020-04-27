﻿using System;
using Microsoft.Xna.Framework;
using Terraria;
using HamstarHelpers.Classes.UI.Theme;
using HamstarHelpers.Helpers.Debug;
using HamstarHelpers.Services.Timers;


namespace Emitters.Libraries.Classes.UI {
	/// <summary>
	/// Implements a UI slider bar element.
	/// </summary>
	public partial class UISlider : UIThemedElement {
		/// @private
		public override void Update( GameTime gameTime ) {
			if( !this.NumericInput.IsMouseHovering ) {
				this.UpdateMouseInteractivity();
			}

			if( UISlider.SelectedSlider != null ) {
				this.NumericInput.Enable( false );
			} else {
				this.NumericInput.Enable( this.IsClickable );
			}
		}


		////

		private void UpdateMouseInteractivity() {
			if( !this.IsClickable ) {
				return;
			}
			if( !Main.mouseLeft ) {
				return;
			}
			if( UISlider.SelectedSlider != null ) {
				return;
			}

			Rectangle rect = this.GetInnerRectangle();
			if( !rect.Contains( Main.mouseX, Main.mouseY ) ) {
				return;
			}
			if( this.LeftArrowElem.GetOuterDimensions().ToRectangle().Contains(Main.mouseX, Main.mouseY) ) {
				return;
			}
			if( this.RightArrowElem.GetOuterDimensions().ToRectangle().Contains(Main.mouseX, Main.mouseY) ) {
				return;
			}

			UISlider.SelectedSlider = this;

			Timers.RunUntil( () => {
				if( !this.UpdateSliderMouseDrag(rect) ) {
					UISlider.SelectedSlider = null;
					return false;
				}
				return true;
			}, true );
		}


		private bool UpdateSliderMouseDrag( Rectangle sliderArea ) {
			if( !this.IsClickable ) {
				return false;
			}
			if( !Main.mouseLeft ) {
				return false;
			}

			if( UISlider.SelectedSlider == this ) {
				float value = UISlider.GetInputValue(
					sliderArea,
					new Point( Main.mouseX, Main.mouseY ),
					this.Range.Min,
					this.Range.Max,
					this.Ticks,
					this.IsInt
				);
				this.SetValue( value );
			}

			return true;
		}
	}
}
