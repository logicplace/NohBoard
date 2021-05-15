/*
Copyright (C) 2020 by Emanuele Ciriachi <e.c.p.emanuele.ciriachi@gmail.com>

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

namespace ThoNohT.NohBoard.Hooking {

    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using static Interop.Defines;
    using static Interop.FunctionImports;

    public class DirectInputState : StateBase<int> {

        /// <summary>
        /// Initializes the state of state keys.
        /// </summary>
        static DirectInputState() {
        }

        /// <summary>
        /// Replaces the current button matrix for the Direct Input device with the guid passed as parameter
        /// </summary>
        /// <param name="guid">the guid of the device we are updating</param>
        /// <param name="buttons">the boolean array of buttons</param>
        public static void UpdatedPressedElements(Guid guid, bool[] buttons) {
            lock (pressedButtons) {
                if (!pressedButtons.ContainsKey(guid)) return;

                pressedButtons[guid] = buttons;

                // Always update to keep checking whether to remove the key on the next render cycle.
                updated = true;
            }
        }

        /// <summary>
        /// Replaces the current button matrix for the Direct Input device with the guid passed as parameter
        /// </summary>
        /// <param name="guid">the guid of the device we are updating</param>
        /// <param name="dpads">the boolean array of dpad buttons</param>
        public static void UpdatePressedDpads(Guid guid, int[] dpads) {
            lock (pressedDpad) {
                if (!pressedDpad.ContainsKey(guid)) return;

                pressedDpad[guid] = dpads;

                // Always update to keep checking whether to remove the key on the next render cycle.
                updated = true;
            }
        }

        /// <summary>
        /// Updates the currently supported axis for the Direct Input device with the guid passed as parameter
        /// </summary>
        /// <param name="guid">the guid of the device we are updating</param>
        /// <param name="X">the X axis</param>
        /// <param name="Y">the Y axis</param>
        /// <param name="Z">the Z axis</param>
        /// <param name="RotationX">the RotationX axis</param>
        /// <param name="RotationY">the RotationY axis</param>
        /// <param name="RotationZ">the RotationZ axis</param>
        public static void UpdateAxis(Guid guid, int X, int Y, int Z, int RotationX, int RotationY, int RotationZ, int Slider0, int Slider1) {
            lock (directInputAxis) {
                if (!directInputAxis.ContainsKey(guid)) return;

                directInputAxis[guid][(int)DirectInputAxisNames.X] = X;
                directInputAxis[guid][(int)DirectInputAxisNames.Y] = Y;
                directInputAxis[guid][(int)DirectInputAxisNames.Z] = Z;
                directInputAxis[guid][(int)DirectInputAxisNames.RotationX] = RotationX;
                directInputAxis[guid][(int)DirectInputAxisNames.RotationY] = RotationY;
                directInputAxis[guid][(int)DirectInputAxisNames.RotationZ] = RotationZ;
                directInputAxis[guid][(int)DirectInputAxisNames.Slider0] = Slider0;
                directInputAxis[guid][(int)DirectInputAxisNames.Slider1] = Slider1;

                // Always update to keep checking whether to remove the key on the next render cycle.
                updated = true;
            }
        }
    }
}
