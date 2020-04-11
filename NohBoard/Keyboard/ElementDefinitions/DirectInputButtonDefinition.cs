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
    public class DirectInputButtonDefinition : ElementDefinition {
        public override ElementDefinition Clone() {
            throw new NotImplementedException();
        }

        public override Rectangle GetBoundingBox() {
            throw new NotImplementedException();
        }

        public override bool Inside(Point point) {
            throw new NotImplementedException();
        }

        public override bool IsChanged(ElementDefinition other) {
            throw new NotImplementedException();
        }

        public override ElementDefinition Manipulate(Size diff) {
            throw new NotImplementedException();
        }

        public override void RenderEditing(Graphics g) {
            throw new NotImplementedException();
        }

        public override void RenderHighlight(Graphics g) {
            throw new NotImplementedException();
        }

        public override void RenderSelected(Graphics g) {
            throw new NotImplementedException();
        }

        public override bool StartManipulating(Point point, bool altDown, bool preview = false, bool translateOnly = false) {
            throw new NotImplementedException();
        }

        public override ElementDefinition Translate(int dx, int dy) {
            throw new NotImplementedException();
        }
    }
}