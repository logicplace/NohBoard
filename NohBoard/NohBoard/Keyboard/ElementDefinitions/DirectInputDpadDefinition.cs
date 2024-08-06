/*
Copyright (C) 2016 by Eric Bataille <e.c.p.bataille@gmail.com>

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 2 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

namespace ThoNohT.NohBoard.Keyboard.ElementDefinitions
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.Linq;
    using System.Runtime.Serialization;
    using ClipperLib;
    using Extra;
    using ThoNohT.NohBoard.Keyboard.Styles;

    public enum DrawMode
    {
        Single,
        FourWay,
        Diagonals
    }

    /// <summary>
    /// Represents a button on a DirectInput device
    /// </summary>
    [DataContract(Name = "DirectInputDPad", Namespace = "")]
    public class DirectInputDpadDefinition : DirectInputElementDefinition {
        #region Properties

        /// <summary>
        /// The text  that should be shown if shift is pressed.
        /// </summary>
        [DataMember]
        public string ShiftText { get; private set; }

        /// <summary>
        /// Indicates whether the <see cref="ShiftText"/> should be shown when caps lock is pressed or not.
        /// </summary>
        /// <remarks>This is typically enabled for letters, but disabled for numbers.</remarks>
        [DataMember]
        public bool ChangeOnCaps { get; private set; }

        /// <summary>
        /// Indicates the number from 0 to 3 of the DirectInput joystick
        /// </summary>
        [DataMember]
        public int DpadNumber { get; private set; }

		/// <summary>
		/// When set to Single, the current direction(s) will be display as an arrow/image in a single square.
		/// When set to FourWay, diagonal directions will be represented by the horizontal and vertical square/image adjacent to them.
		/// When set to Diagonals, diagonal directions will be drawn with their own square/image.
		/// </summary>
		[DataMember]
        public DrawMode DrawMode { get; private set; }

        /// <summary>
        /// The center of the button.
        /// </summary>
        public TPoint Center {
            get {
                var x = this.Boundaries.Sum(p => p.X) / this.Boundaries.Count;
                var y = this.Boundaries.Sum(p => p.Y) / this.Boundaries.Count;

                return new TPoint(x, y);
            }
        }

        /// <summary>
        /// The top left of the button
        /// </summary>
        private TPoint TopLeft { get; set; }

        /// <summary>
        /// The top left of the button
        /// </summary>
        private TPoint TopRight { get; set; }

        /// <summary>
        /// The top left of the button
        /// </summary>
        private TPoint BottomLeft { get; set; }

        /// <summary>
        /// The top left of the button
        /// </summary>
        private TPoint BottomRight { get; set; }

        /// <summary>
        /// The width of the button.
        /// </summary>
        private int Width { get; set; }

        /// <summary>
        /// The height of the button.
        /// </summary>
        private int Height { get; set; }

        private bool PropertiesInitialized;

        #endregion Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputDpadDefinition" /> class.
        /// </summary>
        /// <param name="id">The identifier of the key.</param>
        /// <param name="normalText">The normal text.</param>
        /// <param name="shiftText">The shift text.</param>
        /// <param name="changeOnCaps">Whether to change to shift text on caps lock.</param>
        /// <param name="textPosition">The new text position.
        /// If not provided, the new position will be recalculated from the bounding box of the key.</param>
        /// <param name="manipulation">The current manipulation.</param>
        public DirectInputDpadDefinition(
            int id,
            List<TPoint> boundaries,
            string normalText,
            string shiftText,
            Guid deviceId,
            int dpadNumber,
            bool changeOnCaps,
			DrawMode drawMode,
            TPoint textPosition = null,
            ElementManipulation manipulation = null) : base(id, boundaries, normalText, deviceId, textPosition, manipulation) {

            this.DpadNumber = dpadNumber;
            this.DrawMode = drawMode;

            if (!PropertiesInitialized) {
                InitializeSubProperties();
            }
        }

        /// <summary>
        /// Adds a boundary on the edge that is highlighted.
        /// </summary>
        /// <param name="location">To location to add the point at.</param>
        /// <returns>The new version of this key definition with the boundary added.</returns>
        public override DirectInputElementDefinition AddBoundary(TPoint location) {
            if (this.RelevantManipulation == null) return this;
            if (this.RelevantManipulation.Type != ElementManipulationType.MoveEdge)
                throw new Exception("Attempting to add a boundary to something other than an edge.");

            var newBoundaries = this.Boundaries.ToList();
            newBoundaries.Insert(this.RelevantManipulation.Index + 1, location);

            return new DirectInputDpadDefinition(
                this.Id,
                newBoundaries,
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Returns a clone of this element definition.
        /// </summary>
        /// <returns>The cloned element definition.</returns>
        public override ElementDefinition Clone() {
            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.Select(x => x.Clone()).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                this.TextPosition,
                this.CurrentManipulation);
        }

        private void InitializeSubProperties() {
            var minx = this.Boundaries.Min(p => p.X);
            var maxx = this.Boundaries.Max(p => p.X);
            var miny = this.Boundaries.Min(p => p.Y);
            var maxy = this.Boundaries.Max(p => p.Y);

            TopLeft = new TPoint(minx, miny);
            TopRight = new TPoint(maxx, miny);
            BottomLeft = new TPoint(minx, maxy);
            BottomRight = new TPoint(maxx, maxy);
            Width = maxx - minx;
            Height = maxy - miny;

            PropertiesInitialized = true;
        }

        /// <summary>
        /// Checks whether the definition has changes relative to the specified other definition.
        /// </summary>
        /// <param name="other">The definition to compare against.</param>
        /// <returns>True if the definition has changes, false otherwise.</returns>
        public override bool IsChanged(ElementDefinition other) {
            if (!(other is DirectInputDpadDefinition kkd)) return true;

            if (this.Text != kkd.Text) return true;
            if (this.ShiftText != kkd.ShiftText) return true;
            if (this.ChangeOnCaps != kkd.ChangeOnCaps) return true;
            if (this.TextPosition.IsChanged(kkd.TextPosition)) return true;
            if (!this.DeviceId.Equals(kkd.DeviceId)) return true;
            if (this.DpadNumber != kkd.DpadNumber) return true;

            if (this.Boundaries.Count != kkd.Boundaries.Count) return true;

            // Boundary order change is also a change. So loop through them all.
            for (var i = 0; i < this.Boundaries.Count; i++) {
                if (this.Boundaries[i].IsChanged(kkd.Boundaries[i])) return true;
            }

            return false;
        }

        /// <summary>
        /// Removes the highlighted boundary.
        /// </summary>
        /// <returns>The new version of this key definition with the boundary removed.</returns>
        public override DirectInputElementDefinition ModifyMouse(List<TPoint> boundaries = null, string text = null, TPoint textPosition = null) {
            throw new Exception("Cannot modify  the mouse properties of a joystick button.");
        }

        /// <summary>
        /// Removes the highlighted boundary.
        /// </summary>
        /// <returns>The new version of this key definition with the boundary removed.</returns>
        public override DirectInputElementDefinition RemoveBoundary() {
            if (this.RelevantManipulation == null) return this;
            if (this.RelevantManipulation.Type != ElementManipulationType.MoveBoundary)
                throw new Exception("Attempting to remove something other than a boundary.");

            if (this.Boundaries.Count < 4)
                throw new Exception("Cannot have less than 3 boundary in an element.");

            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.Where((b, i) => i != this.RelevantManipulation.Index).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                this.TextPosition,
                this.RelevantManipulation);
        }

        /// <summary>
        /// Translates the element, moving it the specified distance.
        /// </summary>
        /// <param name="dx">The distance along the x-axis.</param>
        /// <param name="dy">The distance along the y-axis.</param>
        /// <returns>A new <see cref="ElementDefinition"/> that is translated.</returns>
        public override ElementDefinition Translate(int dx, int dy) {
            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.Select(b => b.Translate(dx, dy)).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                this.TextPosition.Translate(dx, dy),
                this.CurrentManipulation);
        }

        /// <summary>
        /// Updates the key definition to occupy a region of itself plus the specified other keys.
        /// </summary>
        /// <param name="keys">The keys to union with.</param>
        /// <returns>A new key definition with the updated region.</returns>
        public override DirectInputElementDefinition UnionWith(List<DirectInputElementDefinition> keys) {
            return this.UnionWith(keys.ConvertAll(x => (DirectInputDpadDefinition)x));
        }

        /// <summary>
        /// Updates the key definition to occupy a region of itself plus the specified other keys.
        /// </summary>
        /// <param name="keys">The keys to union with.</param>
        /// <returns>A new key definition with the updated region.</returns>
        private DirectInputDpadDefinition UnionWith(IList<DirectInputDpadDefinition> keys) {
            var newBoundaries = this.Boundaries.Select(b => new TPoint(b.X, b.Y)).ToList();

            if (keys.Any()) {
                var cl = new Clipper();
                cl.AddPath(this.GetPath(), PolyType.ptSubject, true);
                cl.AddPaths(keys.Select(x => x.GetPath()).ToList(), PolyType.ptClip, true);
                var union = new List<List<IntPoint>>();
                cl.Execute(ClipType.ctUnion, union);

                if (union.Count > 1)
                    throw new ArgumentException("Cannot union two non-overlapping keys.");

                newBoundaries = union.Single().ConvertAll<TPoint>(x => x);
            }

            return new DirectInputDpadDefinition(
                this.Id,
                newBoundaries,
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode);
        }

        /// <summary>
        /// Moves a boundary point by the specified distance.
        /// </summary>
        /// <param name="index">The index of the boundary point in <see cref="KeyDefinition.Boundaries"/>.</param>
        /// <param name="diff">The distance to move the boundary point.</param>
        /// <returns>A new key definition with the moved boundary.</returns>
        protected override DirectInputElementDefinition MoveBoundary(int index, Size diff) {
            if (index < 0 || index >= this.Boundaries.Count)
                throw new Exception("Attempting to move a non-existent boundary.");

            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.Select((b, i) => i != index ? b : b + diff).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Renders the button in the specified surface.
        /// </summary>
        /// <param name="g">The GDI+ surface to render on.</param>
        /// <param name="pressed">A value indicating whether to render the key in its pressed state or not.</param>
        /// <param name="shift">A value indicating whether shift is pressed during the render.</param>
        /// <param name="capsLock">A value indicating whether caps lock is pressed during the render.</param>
        public void Render(Graphics g, Dictionary<Guid, int[]> directInputDpad, bool shift, bool capsLock) {

            var style = GlobalSettings.CurrentStyle.TryGetElementStyle<DirectInputDpadStyle>(this.Id)
                            ?? GlobalSettings.CurrentStyle.DefaultDirectInputDpadStyle;
            var defaultDirectInputDpadStyle = GlobalSettings.CurrentStyle.DefaultDirectInputDpadStyle;
            var subStyle = style != null ? style?.SubStyle ?? defaultDirectInputDpadStyle.SubStyle : defaultDirectInputDpadStyle.SubStyle;
            var txtSize = g.MeasureString(this.GetText(shift, capsLock), subStyle.Font);
            var txtPoint = new TPoint(
                this.TextPosition.X - (int)(txtSize.Width / 2),
                this.TextPosition.Y - (int)(txtSize.Height / 2));

            // Draw the background
            if (style == null || (style != null && style.DrawDpadBackground)) {
                var backgroundBrush = this.GetBackgroundBrush(subStyle, true);
                g.FillPolygon(backgroundBrush, this.Boundaries.ConvertAll<Point>(x => x).ToArray());
            }

            int dpadValue = -1;
            if (directInputDpad.ContainsKey(DeviceId) && DpadNumber > 0) {
                dpadValue = directInputDpad[DeviceId][DpadNumber - 1];
            }

            var borderPen = new Pen(subStyle.Outline, subStyle.OutlineWidth);

            if (!PropertiesInitialized) {
                InitializeSubProperties();
            }

            int x1 = TopLeft.X;
            int x2 = TopLeft.X + Width / 3;
            int x3 = TopLeft.X + 2 * (Width / 3);
            int x4 = TopRight.X;

            int y1 = TopLeft.Y;
            int y2 = TopLeft.Y + Height / 3;
            int y3 = TopLeft.Y + 2 * (Height / 3);
            int y4 = BottomLeft.Y;

            int sWidth = x2 - x1;
            int sHeight = y2 - y1;

            // Draws the D-pad
            if (subStyle.ShowOutline) {
                if (this.DrawMode == DrawMode.Single) {
					g.DrawLine(borderPen, x1, y1, x4, y1);
					g.DrawLine(borderPen, x4, y1, x4, y1);
					g.DrawLine(borderPen, x4, y4, x1, y4);
					g.DrawLine(borderPen, x4, y4, x4, y1);
                }
                else {
					g.DrawLine(borderPen, x2, y1, x3, y1);
					g.DrawLine(borderPen, x3, y1, x3, y2);
					g.DrawLine(borderPen, x3, y2, x4, y2);
					g.DrawLine(borderPen, x4, y2, x4, y3);
					g.DrawLine(borderPen, x4, y3, x3, y3);
					g.DrawLine(borderPen, x3, y3, x3, y4);
					g.DrawLine(borderPen, x3, y4, x2, y4);
					g.DrawLine(borderPen, x2, y4, x2, y3);
					g.DrawLine(borderPen, x2, y3, x1, y3);
					g.DrawLine(borderPen, x1, y3, x1, y2);
					g.DrawLine(borderPen, x1, y2, x2, y2);
					g.DrawLine(borderPen, x2, y2, x2, y1);
				}
            }

            // Draws the up fill if needed
            // The procedure is rather different depending on whether or not we also draw the diagonals
            switch (this.DrawMode) {
                case DrawMode.Diagonals:
                    if (dpadValue == 0) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 0, new Rectangle(new Point(x2, y1), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x2, y1), new PointF(x3, y1), new PointF(x3, y2), new PointF(x2, y2) });
                    }
                    if (dpadValue == 4500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 4500, new Rectangle(new Point(x3, y1), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x3, y1), new PointF(x4, y1), new PointF(x4, y2), new PointF(x3, y2) });
                    }
                    if (dpadValue == 9000) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 9000, new Rectangle(new Point(x3, y2), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x3, y2), new PointF(x4, y2), new PointF(x4, y3), new PointF(x3, y3) });
                    }
                    if (dpadValue == 13500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 13500, new Rectangle(new Point(x3, y3), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x3, y3), new PointF(x4, y3), new PointF(x4, y4), new PointF(x3, y4) });
                    }
                    if (dpadValue == 18000) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 18000, new Rectangle(new Point(x2, y3), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x2, y3), new PointF(x3, y3), new PointF(x3, y4), new PointF(x2, y4) });
                    }
                    if (dpadValue == 22500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 22500, new Rectangle(new Point(x1, y3), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y3), new PointF(x2, y3), new PointF(x2, y4), new PointF(x1, y4) });
                    }
                    if (dpadValue == 27000) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 27000, new Rectangle(new Point(x1, y2), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y2), new PointF(x2, y2), new PointF(x2, y3), new PointF(x1, y3) });
                    }
                    if (dpadValue == 31500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 31500, new Rectangle(new Point(x1, y1), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y1), new PointF(x2, y1), new PointF(x2, y2), new PointF(x1, y2) });
                    }
                    break;
				case DrawMode.Single:
                    if (dpadValue % 4500 == 0 && dpadValue <= 31500) {
						var foregroundBrush = GetForegroundDpadBrush(style, dpadValue, new Rectangle(new Point(x1, y1), new Size(x4 - x1, y4 - y1)));
						g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y1), new PointF(x4, y1), new PointF(x4, y4), new PointF(x1, y4) });
					}
					break;
				default:
					if (dpadValue == 31500 || dpadValue == 0 || dpadValue == 4500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 0, new Rectangle(new Point(x2, y1), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x2, y1), new PointF(x3, y1), new PointF(x3, y2), new PointF(x2, y2) });
                    }
                    if (dpadValue == 4500 || dpadValue == 9000 || dpadValue == 13500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 9000, new Rectangle(new Point(x3, y2), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x3, y2), new PointF(x4, y2), new PointF(x4, y3), new PointF(x3, y3) });
                    }
                    if (dpadValue == 13500 || dpadValue == 18000 || dpadValue == 22500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 18000, new Rectangle(new Point(x2, y3), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x2, y3), new PointF(x3, y3), new PointF(x3, y4), new PointF(x2, y4) });
                    }
                    if (dpadValue == 22500 || dpadValue == 27000 || dpadValue == 31500) {
                        var foregroundBrush = GetForegroundDpadBrush(style, 27000, new Rectangle(new Point(x1, y2), new Size(sWidth, sHeight)));
                        g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y2), new PointF(x2, y2), new PointF(x2, y3), new PointF(x1, y3) });
                    }
                    break;
            }
            if (dpadValue == -1) {
                if (this.DrawMode == DrawMode.Single) {
					var foregroundBrush = GetForegroundDpadBrush(style, -1, new Rectangle(new Point(x1, y1), new Size(x4 - x1, y4 - y1)));
					g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x1, y1), new PointF(x4, y1), new PointF(x4, y4), new PointF(x1, y4) });
				}
                else {
					var foregroundBrush = GetForegroundDpadBrush(style, -1, new Rectangle(new Point(x2, y2), new Size(sWidth, sHeight)));
					g.FillPolygon(foregroundBrush, new PointF[] { new PointF(x2, y2), new PointF(x3, y2), new PointF(x3, y3), new PointF(x2, y3) });
				}
            }

            // Draw the text
            g.DrawString(this.GetText(shift, capsLock), subStyle.Font, new SolidBrush(subStyle.Text), (Point)txtPoint);
            g.ResetClip();
        }

        // Returns the Foreground brush depending on the style
        private Brush GetForegroundDpadBrush(DirectInputDpadStyle style, int position, Rectangle boundingBox) {
            if (style != null) {
                string imageFileName = style.BackgroundNeutralImageFileName;

                if (position == 0) {
                    imageFileName = style.BackgroundTopImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 4500) {
                    imageFileName = style.BackgroundTopRightImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 9000) {
                    imageFileName = style.BackgroundRightImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 13500) {
                    imageFileName = style.BackgroundBottomRightImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 18000) {
                    imageFileName = style.BackgroundBottomImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 22500) {
                    imageFileName = style.BackgroundBottomLeftImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 27000) {
                    imageFileName = style.BackgroundLeftImageFileName ?? style.BackgroundNeutralImageFileName;
                } else if (position == 31500) {
                    imageFileName = style.BackgroundTopLeftImageFileName ?? style.BackgroundNeutralImageFileName;
                }

                return imageFileName == null || !FileHelper.StyleImageExists(imageFileName)
                    ? string.IsNullOrEmpty(style.BackgroundNeutralImageFileName) || !FileHelper.StyleImageExists(style.BackgroundNeutralImageFileName)
                    ? new SolidBrush(style.ForegroundColor) : this.BrushFromImage(boundingBox, style.BackgroundNeutralImageFileName)
                    : this.BrushFromImage(boundingBox, imageFileName);
            } else {
                return new SolidBrush(GlobalSettings.CurrentStyle.DefaultDirectInputDpadStyle.ForegroundColor);
            }
        }

        /// <summary>
        /// Creates a brush from an image.
        /// </summary>
        /// <param name="boundingBox">The bounding box to fit the brush in.</param>
        /// <param name="fileName">The filename to load the image from. This filename should be relative to the images
        /// folder of the current style.</param>
        /// <returns>The brush created from the image.</returns>
        private Brush BrushFromImage(Rectangle boundingBox, string fileName) {
            var img = ImageCache.Get(fileName);
            var gu = GraphicsUnit.Pixel;
            var imgBb = img.GetBounds(ref gu);

            // Create a texture brush from the image.
            var tex = new TextureBrush(img, imgBb);
            tex.TranslateTransform(boundingBox.Left, boundingBox.Top);
            //tex.TranslateTransform(-25, -25);
            tex.ScaleTransform(boundingBox.Width / imgBb.Width, boundingBox.Height / imgBb.Height);

            return tex;
        }

        /// <summary>
        /// Moves an edge by the specified distance.
        /// </summary>
        /// <param name="index">The index of the edge as specified by the first of the two boundaries defining it in
        /// <see cref="KeyDefinition.Boundaries"/>.</param>
        /// <param name="diff">The distance to move the edge.</param>
        /// <returns>A new key definition with the moved edge.</returns>
        protected override DirectInputElementDefinition MoveEdge(int index, Size diff) {
            if (index < 0 || index >= this.Boundaries.Count)
                throw new Exception("Attempting to move a non-existent edge.");

            bool doUpdate(int i) => i == index || i == (index + 1) % this.Boundaries.Count;

            // Project the mouse movement onto the orthogonal vector.
            var edgeBoundaries = this.Boundaries.Where((b, i) => doUpdate(i)).ToList();
            var edgeVector = (SizeF)(edgeBoundaries[1] - edgeBoundaries[0]);
            var othogonalVector = edgeVector.RotateDegrees(90);
            var projectedDiff = ((SizeF)diff).ProjectOn(othogonalVector);

            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.Select((b, i) => !doUpdate(i) ? b : b + projectedDiff).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Moves the text inside the key by the specified ditsance.
        /// </summary>
        /// <param name="diff">The distance to move the text.</param>
        /// <returns>A new key definition with the moved text.</returns>
        protected override DirectInputElementDefinition MoveText(Size diff) {
            return new DirectInputDpadDefinition(
                this.Id,
                this.Boundaries.ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.DpadNumber,
                this.ChangeOnCaps,
                this.DrawMode,
                this.TextPosition + diff,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Returns a new version of this element definition with the specified properties changed.
        /// </summary>
        /// <param name="boundaries">The new boundaries, or <c>null</c> if not changed.</param>
        /// <param name="deviceId">The new Device Id, or <c>null</c> if not changed.</param>
        /// <param name="buttonNumber">The new Button Number, or <c>0</c> if not changed.</param>
        /// <param name="text">The new text, or <c>null</c> if not changed.</param>
        /// <param name="shiftText">The new shift text, or <c>null</c> if not changed.</param>
        /// <param name="changeOnCaps">The new change on caps, or <c>null</c> if not changed.</param>
        /// <param name="textPosition">The new text position, or <c>null</c> if not changed.</param>
        /// <returns>The new element definition.</returns>
        public DirectInputDpadDefinition Modify(
            List<TPoint> boundaries = null, string deviceId = null, int dpadNumber = 0, string text = null, string shiftText = null,
            bool? changeOnCaps = null, DrawMode? drawMode = null, TPoint textPosition = null) {
            return new DirectInputDpadDefinition(
                this.Id,
                boundaries ?? this.Boundaries.Select(x => x.Clone()).ToList(),
                text ?? this.Text,
                shiftText ?? this.ShiftText,
                deviceId != null && Guid.Parse(deviceId) != Guid.Empty ? Guid.Parse(deviceId) : this.DeviceId,
                dpadNumber != 0 ? dpadNumber : this.DpadNumber,
                changeOnCaps ?? this.ChangeOnCaps,
				drawMode ?? this.DrawMode,
                textPosition ?? this.TextPosition,
                this.CurrentManipulation);
        }

        #region Private methods

        /// <summary>
        /// Determines whether to use the shift text or the regular text for this key depening on the shift, caps lock
        /// state and the key's properties. Returns the text that should be displayed for this state.
        /// </summary>
        /// <param name="shift">Whether shift is pressed.</param>
        /// <param name="capsLock">Whether caps lock is active.</param>
        /// <returns>The text to display for this key.</returns>
        private string GetText(bool shift, bool capsLock) {
            if (GlobalSettings.Settings.Capitalization != CapitalizationMethod.FollowKeys) {
                // Caps lock is set based on the capitalization method.
                capsLock = GlobalSettings.Settings.Capitalization == CapitalizationMethod.Capitalize;

                // If follow shift for caps insensitive keys is true, then don't edit the shift value if ChangeOnCaps.
                // If follow shift for caps sensitive keys is true, then don't edit the shift value if not ChangeOnCaps.
                var preserveShift = GlobalSettings.Settings.FollowShiftForCapsInsensitive && !this.ChangeOnCaps
                                    || GlobalSettings.Settings.FollowShiftForCapsSensitive && this.ChangeOnCaps;
                // Shift is ignored, but only if the follow shift is not set for this key's ChangeOnCaps setting.
                shift &= preserveShift;
            }

            var capitalize = this.ChangeOnCaps && (capsLock ^ shift) || !this.ChangeOnCaps && shift;
            return capitalize ? this.ShiftText : this.Text;
        }

        #endregion
    }
}
