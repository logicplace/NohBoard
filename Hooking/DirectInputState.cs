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
        /// Adds the specified mouse keycode to the list of pressed keys.
        /// </summary>
        /// <param name="keyCode">The keycode to add.</param>
        /// <param name="hold">The minimum time to hold keys.</param>
        public static void AddPressedElement(int buttonNumber, Guid guid, int hold) {
            lock (pressedButtons) {
                EnsureStopwatchRunning();

                var time = keyHoldStopwatch.ElapsedMilliseconds;

                if (!pressedButtons.ContainsKey(guid)) {
                    pressedButtons.Add(guid, new bool[256]);
                }

                if (pressedButtons.TryGetValue(guid, out var deviceDictionary)) {
                    deviceDictionary[buttonNumber] = true;

                    // Always update to keep checking whether to remove the key on the next render cycle.
                    updated = true;
                }
            }
        }

        /// <summary>
        /// Removes the specified keycode from the list of pressed keys.
        /// </summary>
        /// <param name="keyCode">The keycode to remove.</param>
        /// <param name="hold">The minimum time to hold keys.</param>
        public static void RemovePressedElement(int buttonNumber, Guid guid, int hold) {
            lock (pressedButtons) {
                if (!pressedButtons.ContainsKey(guid)) return;

                if (pressedButtons.TryGetValue(guid, out var deviceDictionary)) {
                    deviceDictionary[buttonNumber] = false;

                    // Always update to keep checking whether to remove the key on the next render cycle.
                    updated = true;
                }
            }
        }

        /// <summary>
        /// Replaces the current button matrix with the updated one
        /// </summary>
        /// <param name="buttons">the boolean array of buttons</param>
        /// <param name="guid">the guid of the device we are updating</param>
        public static void UpdatedPressedElements(Guid guid, bool[] buttons) {
            lock (pressedButtons) {
                if (!pressedButtons.ContainsKey(guid)) return;

                pressedButtons[guid] = buttons;

                // Always update to keep checking whether to remove the key on the next render cycle.
                updated = true;
            }
        }
    }
}
