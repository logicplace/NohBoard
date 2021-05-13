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

namespace ThoNohT.NohBoard.Hooking.Interop
{
    using System;
    using System.Collections.Generic;
    using System.Runtime.InteropServices;
    using System.Threading;
    using static Defines;
    using static FunctionImports;
    using static Structs;

    /// <summary>
    /// A manager containing functionality for managing keyboard and mouse hooks.
    /// </summary>
    /// <remarks>This class is heavily based on the following example:
    /// http://www.codeproject.com/Articles/7294/Processing-Global-Mouse-and-Keyboard-Hooks-in-C.
    /// It is rewritten to suit the needs of NohBoard and compare to the hooking functionality
    /// present in the original NohBoard.
    /// </remarks>
    public static partial class HookManager
    {
        /// <summary>
        /// The CallWndProc hook procedure is an application-defined or library-defined callback
        /// function used with the SetWindowsHookEx function. The HOOKPROC type defines a pointer
        /// to this callback function. CallWndProc is a placeholder for the application-defined
        /// or library-defined function name.
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies whether the hook procedure must process the message.
        /// If nCode is HC_ACTION, the hook procedure must process the message.
        /// If nCode is less than zero, the hook procedure must pass the message to the
        /// CallNextHookEx function without further processing and must return the
        /// value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies whether the message was sent by the current thread.
        /// If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        /// [in] Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        /// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        /// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        /// procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        /// <remarks>
        /// http://msdn.microsoft.com/library/default.asp?url=/library/en-us/winui/winui/windowsuserinterface/windowing/hooks/hookreference/hookfunctions/callwndproc.asp
        /// </remarks>
        internal delegate int HookProc(int nCode, int wParam, IntPtr lParam);

        internal delegate void TimerProc(object state);

        /// <summary>
        /// If <c>true</c>, keyboard or mouse events will not be propagate to other programs if their respective
        /// trap properties (<see cref="TrapKeyboard"/> and <see cref="TrapMouse"/> are <c>true</c>).
        /// </summary>
        private static bool trapEnabled;

        #region Mouse Hook

        /// <summary>
        /// This field is used to keep a reference to the delegate so GC won't clean it up.
        /// </summary>
        private static HookProc mouseDelegate;

        /// <summary>
        /// Stores the handle to the mouse hook procedure.
        /// </summary>
        private static int mouseHookHandle;

        /// <summary>
        /// A callback function which will be called every Time a mouse activity detected.
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies whether the hook procedure must process the message.
        /// If nCode is HC_ACTION, the hook procedure must process the message.
        /// If nCode is less than zero, the hook procedure must pass the message to the
        /// CallNextHookEx function without further processing and must return the
        /// value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies whether the message was sent by the current thread.
        /// If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        /// [in] Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        /// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        /// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        /// procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        private static int MouseHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode < 0) return CallNextHookEx(mouseHookHandle, nCode, wParam, lParam);

            //Marshall the data from callback.
            var info = (MouseLLHookStruct)Marshal.PtrToStructure(lParam, typeof(MouseLLHookStruct));

            ushort subCode;
            switch (wParam)
            {
                case WM_LBUTTONDOWN:
                    MouseState.AddPressedElement(MouseKeyCode.LeftButton);

                    break;
                case WM_LBUTTONUP:
                    MouseState.RemovePressedElement(MouseKeyCode.LeftButton, PressHold);

                    break;
                case WM_RBUTTONDOWN:
                    MouseState.AddPressedElement(MouseKeyCode.RightButton);

                    break;
                case WM_RBUTTONUP:
                    MouseState.RemovePressedElement(MouseKeyCode.RightButton, PressHold);
                    break;

                case WM_MBUTTONDOWN:
                    MouseState.AddPressedElement(MouseKeyCode.MiddleButton);
                    break;

                case WM_MBUTTONUP:
                    MouseState.RemovePressedElement(MouseKeyCode.MiddleButton, PressHold);
                    break;

                case WM_MOUSEWHEEL:
                    subCode = HiWord(info.MouseData);

                    if (subCode == 120)
                        MouseState.AddScrollDirection(MouseScrollKeyCode.ScrollUp);
                    if (subCode == 65416)
                        MouseState.AddScrollDirection(MouseScrollKeyCode.ScrollDown);

                    break;
                case WM_MOUSEHWHEEL:
                    subCode = HiWord(info.MouseData);

                    if (subCode == 120)
                        MouseState.AddScrollDirection(MouseScrollKeyCode.ScrollRight);
                    if (subCode == 65416)
                        MouseState.AddScrollDirection(MouseScrollKeyCode.ScrollLeft);

                    break;
                case WM_XBUTTONDOWN:
                    subCode = HiWord(info.MouseData);

                    if (subCode == XBUTTON1)
                        MouseState.AddPressedElement(MouseKeyCode.X1Button);
                    if (subCode == XBUTTON2)
                        MouseState.AddPressedElement(MouseKeyCode.X2Button);

                    break;
                case WM_XBUTTONUP:
                    subCode = HiWord(info.MouseData);

                    if (subCode == XBUTTON1)
                        MouseState.RemovePressedElement(MouseKeyCode.X1Button, PressHold);
                    if (subCode == XBUTTON2)
                        MouseState.RemovePressedElement(MouseKeyCode.X2Button, PressHold);

                    break;
                case WM_MOUSEMOVE:
                    MouseState.RegisterLocation(new System.Drawing.Point(info.Point.X, info.Point.Y), info.Time);

                    break;
            }

            if (trapEnabled && TrapMouse)
                return 1;

            return CallNextHookEx(mouseHookHandle, nCode, wParam, lParam);
        }

        #endregion Mouse Hook

        #region Keyboard Hook

        /// <summary>
        /// This field is used to keep a reference to the delegate so GC won't clean it up.
        /// </summary>
        private static HookProc keyboardDelegate;

        /// <summary>
        /// Stores the handle to the Keyboard hook procedure.
        /// </summary>
        private static int keyboardHookHandle;

        /// <summary>
        /// This field is used to keep a reference to the delegate so GC won't clean it up.
        /// </summary>
        private static TimerProc directInputDelegate;

        /// <summary>
        /// Stores the handle to the Keyboard hook procedure.
        /// </summary>
        private static Timer directInputTimerHandle;

        /// <summary>
        /// This flag will stop the DirectInput polling timer
        /// </summary>
        private static bool directInputTimerStop;

        /// <summary>
        /// A callback function which will be called every Time a keyboard activity detected.
        /// </summary>
        /// <param name="nCode">
        /// [in] Specifies whether the hook procedure must process the message.
        /// If nCode is HC_ACTION, the hook procedure must process the message.
        /// If nCode is less than zero, the hook procedure must pass the message to the
        /// CallNextHookEx function without further processing and must return the
        /// value returned by CallNextHookEx.
        /// </param>
        /// <param name="wParam">
        /// [in] Specifies whether the message was sent by the current thread.
        /// If the message was sent by the current thread, it is nonzero; otherwise, it is zero.
        /// </param>
        /// <param name="lParam">
        /// [in] Pointer to a CWPSTRUCT structure that contains details about the message.
        /// </param>
        /// <returns>
        /// If nCode is less than zero, the hook procedure must return the value returned by CallNextHookEx.
        /// If nCode is greater than or equal to zero, it is highly recommended that you call CallNextHookEx
        /// and return the value it returns; otherwise, other applications that have installed WH_CALLWNDPROC
        /// hooks will not receive hook notifications and may behave incorrectly as a result. If the hook
        /// procedure does not call CallNextHookEx, the return value should be zero.
        /// </returns>
        private static int KeyboardHookProc(int nCode, int wParam, IntPtr lParam)
        {
            if (nCode < 0) return CallNextHookEx(keyboardHookHandle, nCode, wParam, lParam);

            //Marshall the data from callback.
            var info = (KeyboardHookStruct)Marshal.PtrToStructure(lParam, typeof(KeyboardHookStruct));

            var extended = (info.Flags & LLKHF_EXTENDED) != 0;
            var code = extended && info.VirtualKeyCode == VK_RETURN ? 1025 : info.VirtualKeyCode;

            switch (wParam)
            {
                case WM_KEYDOWN:
                case WM_SYSKEYDOWN:
                    KeyboardState.AddPressedElement(code, PressHold);
                    break;
                case WM_KEYUP:
                case WM_SYSKEYUP:
                    KeyboardState.RemovePressedElement(code, PressHold);

                    // Toggle the mouse trap.
                    if (code == TrapToggleKeyCode) trapEnabled = !trapEnabled;
                    break;
            }

            if (KeyboardInsert?.Invoke(code) ?? false || (trapEnabled && TrapKeyboard))
                return 1;

            return CallNextHookEx(keyboardHookHandle, nCode, wParam, lParam);
        }

        #endregion keyboard Hook

        private static List<SharpDX.DirectInput.Joystick> Devices = new List<SharpDX.DirectInput.Joystick>();
        private static SharpDX.DirectInput.DirectInput DirectInput = new SharpDX.DirectInput.DirectInput();

        #region DirectInput Hook

        private static IList<SharpDX.DirectInput.DeviceInstance> connectedJoysticks = new List<SharpDX.DirectInput.DeviceInstance>();

        /// <summary>
        /// Updates the state of DirectInput devices
        /// </summary>
        /// <param name="state"></param>
        private static void DirectInputTimerProc(object state) {
            // for each joystick connected to the system
            foreach (var device in Devices) {
                try {
                    var jState = device.GetCurrentState();

                    DirectInputState.UpdatedPressedElements(device.Information.ProductGuid, jState.Buttons);

                    DirectInputState.UpdatePressedDpads(device.Information.ProductGuid, jState.PointOfViewControllers);

                    DirectInputState.UpdateAxis(device.Information.ProductGuid, jState.X, jState.Y, jState.Z, jState.RotationX, jState.RotationY, jState.RotationZ);

                    if (DirectInputButtonInsert != null) {
                        for (int j = 0; j < device.Capabilities.ButtonCount; j++) {
                            if (jState.Buttons[j]) {
                                DirectInputButtonInsert.Invoke(j);
                                return;
                            }
                        }
                    }

                    if (DirectInputAxisInsert != null) {
                        string axisChanged = "";
                        if (jState.X != 0 && jState.X < 30000 || jState.X > 35000) {
                            axisChanged = "X";
                        } else if (jState.Y != 0 && jState.Y < 30000 || jState.Y > 35000) {
                            axisChanged = "Y";
                        } else if (jState.Z != 0 && jState.Z < 30000 || jState.Z > 35000) {
                            axisChanged = "Z";
                        } else if (jState.RotationX != 0 && jState.RotationX < 30000 || jState.RotationX > 35000) {
                            axisChanged = "RotationX";
                        } else if (jState.RotationY != 0 && jState.RotationY < 30000 || jState.RotationY > 35000) {
                            axisChanged = "RotationY";
                        } else if (jState.RotationZ != 0 && jState.RotationZ < 30000 || jState.RotationZ > 35000) {
                            axisChanged = "RotationZ";
                        }

                        if (!string.IsNullOrEmpty(axisChanged)) {
                            DirectInputAxisInsert.Invoke(axisChanged);
                            DirectInputAxisInsert = null;
                            return;
                        }
                    }

                    if (DirectInputDpadInsert != null) {
                        for (int j = 0; j < device.Capabilities.PovCount; j++) {
                            if (jState.PointOfViewControllers[j] != -1) {
                                DirectInputDpadInsert.Invoke(j);
                                return;
                            }
                        }
                    }
                }
                catch (Exception) { }
            }
        }

        #endregion
    }
}