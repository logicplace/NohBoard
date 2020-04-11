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

    class DirectInputState : StateBase<int> {

        /// <summary>
        /// Adds the specified mouse keycode to the list of pressed keys.
        /// </summary>
        /// <param name="keyCode">The keycode to add.</param>
        /// <param name="hold">The minimum time to hold keys.</param>
        public static void AddPressedElement(int keyCode, int hold) {
            lock (pressedKeys) {
                EnsureStopwatchRunning();

                var time = keyHoldStopwatch.ElapsedMilliseconds;

                if (pressedKeys.TryGetValue(keyCode, out var pressed)) {
                    pressed.startTime = time;
                    pressed.removed = false;
                    pressedKeys[keyCode] = pressed;
                } else {
                    pressedKeys.Add(
                        keyCode,
                        new KeyPress {
                            startTime = keyHoldStopwatch.ElapsedMilliseconds,
                            removed = false
                        });

                    updated = true;
                }

            }
        }
    }
}
