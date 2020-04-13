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

    /// <summary>
    /// Represents a button or a on a mouse.
    /// </summary>
    [DataContract(Name = "DirectInputButton", Namespace = "")]
    public class DirectInputButtonDefinition : DirectInputElementDefinition {
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
        /// Indicates the number from 0 to 31 of the DirectInput joystick
        /// </summary>
        [DataMember]
        public int ButtonNumber { get; private set; }

        #endregion Properties

        /// <summary>
        /// Initializes a new instance of the <see cref="DirectInputAxisDefinition" /> class.
        /// </summary>
        /// <param name="id">The identifier of the key.</param>
        /// <param name="boundaries">The boundaries.</param>
        /// <param name="normalText">The normal text.</param>
        /// <param name="shiftText">The shift text.</param>
        /// <param name="changeOnCaps">Whether to change to shift text on caps lock.</param>
        /// <param name="textPosition">The new text position.
        /// If not provided, the new position will be recalculated from the bounding box of the key.</param>
        /// <param name="manipulation">The current manipulation.</param>
        public DirectInputButtonDefinition(
            int id,
            List<TPoint> boundaries,
            string normalText,
            string shiftText,
            string deviceId,
            int buttonNumber,
            bool changeOnCaps,
            TPoint textPosition = null,
            ElementManipulation manipulation = null) : base(id, boundaries, normalText, deviceId, textPosition, manipulation) {
                this.ButtonNumber = buttonNumber;
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

            return new DirectInputButtonDefinition(
                this.Id,
                newBoundaries,
                this.DeviceId,
                this.Text,
                this.ShiftText,
                this.ButtonNumber,
                this.ChangeOnCaps,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Returns a clone of this element definition.
        /// </summary>
        /// <returns>The cloned element definition.</returns>
        public override ElementDefinition Clone() {
            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.Select(x => x.Clone()).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                this.TextPosition,
                this.CurrentManipulation);
        }

        /// <summary>
        /// Checks whether the definition has changes relative to the specified other definition.
        /// </summary>
        /// <param name="other">The definition to compare against.</param>
        /// <returns>True if the definition has changes, false otherwise.</returns>
        public override bool IsChanged(ElementDefinition other) {
            if (!(other is DirectInputButtonDefinition kkd)) return true;

            if (this.Text != kkd.Text) return true;
            if (this.ShiftText != kkd.ShiftText) return true;
            if (this.ChangeOnCaps != kkd.ChangeOnCaps) return true;
            if (this.TextPosition.IsChanged(kkd.TextPosition)) return true;
            if (!this.DeviceId.ToSet().SetEquals(kkd.DeviceId)) return true;
            if (this.ButtonNumber != kkd.ButtonNumber) return true;

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

        public override DirectInputElementDefinition RemoveBoundary() {
            if (this.RelevantManipulation == null) return this;
            if (this.RelevantManipulation.Type != ElementManipulationType.MoveBoundary)
                throw new Exception("Attempting to remove something other than a boundary.");

            if (this.Boundaries.Count < 4)
                throw new Exception("Cannot have less than 3 boundary in an element.");

            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.Where((b, i) => i != this.RelevantManipulation.Index).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                this.TextPosition,
                this.RelevantManipulation);
        }

        public override ElementDefinition Translate(int dx, int dy) {
            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.Select(b => b.Translate(dx, dy)).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                this.TextPosition.Translate(dx, dy),
                this.CurrentManipulation);
        }

        public override DirectInputElementDefinition UnionWith(List<DirectInputElementDefinition> keys) {
            return this.UnionWith(keys.ConvertAll(x => (DirectInputButtonDefinition)x));
        }

        /// <summary>
        /// Updates the key definition to occupy a region of itself plus the specified other keys.
        /// </summary>
        /// <param name="keys">The keys to union with.</param>
        /// <returns>A new key definition with the updated region.</returns>
        private DirectInputButtonDefinition UnionWith(IList<DirectInputButtonDefinition> keys) {
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

            return new DirectInputButtonDefinition(
                this.Id,
                newBoundaries,
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps);
        }

        protected override DirectInputElementDefinition MoveBoundary(int index, Size diff) {
            if (index < 0 || index >= this.Boundaries.Count)
                throw new Exception("Attempting to move a non-existent boundary.");

            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.Select((b, i) => i != index ? b : b + diff).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        protected override DirectInputElementDefinition MoveEdge(int index, Size diff) {
            if (index < 0 || index >= this.Boundaries.Count)
                throw new Exception("Attempting to move a non-existent edge.");

            bool doUpdate(int i) => i == index || i == (index + 1) % this.Boundaries.Count;

            // Project the mouse movement onto the orthogonal vector.
            var edgeBoundaries = this.Boundaries.Where((b, i) => doUpdate(i)).ToList();
            var edgeVector = (SizeF)(edgeBoundaries[1] - edgeBoundaries[0]);
            var othogonalVector = edgeVector.RotateDegrees(90);
            var projectedDiff = ((SizeF)diff).ProjectOn(othogonalVector);

            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.Select((b, i) => !doUpdate(i) ? b : b + projectedDiff).ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                GlobalSettings.Settings.UpdateTextPosition ? null : this.TextPosition,
                this.CurrentManipulation);
        }

        protected override DirectInputElementDefinition MoveText(Size diff) {
            return new DirectInputButtonDefinition(
                this.Id,
                this.Boundaries.ToList(),
                this.Text,
                this.ShiftText,
                this.DeviceId,
                this.ButtonNumber,
                this.ChangeOnCaps,
                this.TextPosition + diff,
                this.CurrentManipulation);
        }
    }
}