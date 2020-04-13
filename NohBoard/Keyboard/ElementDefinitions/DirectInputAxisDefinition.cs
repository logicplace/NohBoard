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

    /// <summary>
    /// Represents a button or a on a mouse.
    /// </summary>
    [DataContract(Name = "DirectInputAxis", Namespace = "")]
    public class DirectInputAxisDefinition : DirectInputElementDefinition {

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
        public DirectInputAxisDefinition(
            int id,
            List<TPoint> boundaries,
            string normalText,
            string shiftText,
            string deviceId,
            bool changeOnCaps,
            TPoint textPosition = null,
            ElementManipulation manipulation = null) : base(id, boundaries, normalText, deviceId, textPosition, manipulation) {
        }

        public override DirectInputElementDefinition AddBoundary(TPoint location) {
            throw new NotImplementedException();
        }

        public override ElementDefinition Clone() {
            throw new NotImplementedException();
        }

        public override bool IsChanged(ElementDefinition other) {
            throw new NotImplementedException();
        }

        public override DirectInputElementDefinition ModifyMouse(List<TPoint> boundaries = null, string text = null, TPoint textPosition = null) {
            throw new NotImplementedException();
        }

        public override DirectInputElementDefinition RemoveBoundary() {
            throw new NotImplementedException();
        }

        public override ElementDefinition Translate(int dx, int dy) {
            throw new NotImplementedException();
        }

        public override DirectInputElementDefinition UnionWith(List<DirectInputElementDefinition> keys) {
            throw new NotImplementedException();
        }

        protected override DirectInputElementDefinition MoveBoundary(int index, Size diff) {
            throw new NotImplementedException();
        }

        protected override DirectInputElementDefinition MoveEdge(int index, Size diff) {
            throw new NotImplementedException();
        }

        protected override DirectInputElementDefinition MoveText(Size diff) {
            throw new NotImplementedException();
        }
    }
}