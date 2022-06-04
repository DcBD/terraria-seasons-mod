using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Terraria;
using Terraria.GameContent.UI.Elements;
using Terraria.UI;

namespace Seasons.UI.Helpers
{
    public class DragableUIPanel : UIPanel
    {
		private Vector2 offset;
		public bool dragging;
		internal UIPanel header;
		private bool HasHeader => header != null;

		public void WithTitle(string title)
        {
			if(!HasHeader)
            {
				header = new UIPanel();
				header.SetPadding(0);
				header.Height.Set(30, 0f);
				header.BackgroundColor.A = 255;
				header.OnMouseDown += Header_OnMouseDown;
				header.OnMouseUp += Header_OnMouseUp;
				Append(header);


				var heading = new UIText(title, 1f);
				heading.VAlign = 0.5f;
				heading.MarginLeft = 16f;
				header.Append(heading);

				var closeBtn = new UITextPanel<char>('X');
				closeBtn.SetPadding(7);
				closeBtn.Width.Set(40, 0);
				closeBtn.Left.Set(-40, 1f);
				closeBtn.BackgroundColor = Color.Red;
				//closeBtn.OnClick += (evt, elm) => OnCloseBtnClicked?.Invoke();
				header.Append(closeBtn);
			}
		}

		public void Header_OnMouseDown(UIMouseEvent evt, UIElement el)
		{
			base.MouseDown(evt);
			DragStart(evt);
		}

		public override void Recalculate()
		{
			base.Recalculate();
			if(HasHeader)
            {
				header.Width = Width;
			}
			
		}


		public void Header_OnMouseUp(UIMouseEvent evt, UIElement el)
		{
			base.MouseUp(evt);
			DragEnd(evt);
		}

		private void DragStart(UIMouseEvent evt)
		{
			offset = new Vector2(evt.MousePosition.X - Left.Pixels, evt.MousePosition.Y - Top.Pixels);
			dragging = true;
		}

		private void DragEnd(UIMouseEvent evt)
		{
			Vector2 end = evt.MousePosition;
			dragging = false;

			Left.Set(end.X - offset.X, 0f);
			Top.Set(end.Y - offset.Y, 0f);

			Recalculate();
		}

		public override void Update(GameTime gameTime)
		{
			base.Update(gameTime); // don't remove.

			// Checking ContainsPoint and then setting mouseInterface to true is very common. This causes clicks on this UIElement to not cause the player to use current items. 
			if (ContainsPoint(Main.MouseScreen))
			{
				Main.LocalPlayer.mouseInterface = true;
			}

			if (dragging)
			{
				Left.Set(Main.mouseX - offset.X, 0f); // Main.MouseScreen.X and Main.mouseX are the same.
				Top.Set(Main.mouseY - offset.Y, 0f);
				Recalculate();
			}

			// Here we check if the DragableUIPanel is outside the Parent UIElement rectangle. 
			// (In our example, the parent would be ExampleUI, a UIState. This means that we are checking that the DragableUIPanel is outside the whole screen)
			// By doing this and some simple math, we can snap the panel back on screen if the user resizes his window or otherwise changes resolution.
			var parentSpace = Parent.GetDimensions().ToRectangle();
			if (!GetDimensions().ToRectangle().Intersects(parentSpace))
			{
				Left.Pixels = Utils.Clamp(Left.Pixels, 0, parentSpace.Right - Width.Pixels);
				Top.Pixels = Utils.Clamp(Top.Pixels, 0, parentSpace.Bottom - Height.Pixels);
				// Recalculate forces the UI system to do the positioning math again.
				Recalculate();
			}
		}
	}
}
