// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using Microsoft.Xna.Framework.Input;

namespace Microsoft.Xna.Framework
{
    /// <summary>
    /// This class is used in the <see cref="ImmService.TextInput"/> event as <see cref="EventArgs"/>.
    /// </summary>
    public struct TextInputEventArgs
    {
        /// <summary>
        /// Construct a text input event.
        /// </summary>
        public TextInputEventArgs(char character, Keys key = Keys.None)
        {
            Character = character;
            Key = key;
        }

        /// <summary>
        /// The character for the key that was pressed.
        /// </summary>
        public readonly char Character;

        /// <summary>
        /// The pressed key.
        /// </summary>
        public readonly Keys Key;
    }
}
