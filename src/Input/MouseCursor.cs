// MonoGame - Copyright (C) The MonoGame Team
// This file is subject to the terms and conditions defined in
// file 'LICENSE.txt', which is part of this source code package.

using System;
using System.Runtime.InteropServices;
using Microsoft.Xna.Framework.Graphics;
using SDL2;

namespace Microsoft.Xna.Framework.Input
{
    public class MouseCursor : IDisposable
    {
        /// <summary>
        /// Gets the default arrow cursor.
        /// </summary>
        public static MouseCursor Arrow { get; private set; }

        /// <summary>
        /// Gets the cursor that appears when the mouse is over text editing regions.
        /// </summary>
        public static MouseCursor IBeam { get; private set; }

        /// <summary>
        /// Gets the waiting cursor that appears while the application/system is busy.
        /// </summary>
        public static MouseCursor Wait { get; private set; }

        /// <summary>
        /// Gets the crosshair ("+") cursor.
        /// </summary>
        public static MouseCursor Crosshair { get; private set; }

        /// <summary>
        /// Gets the cross between Arrow and Wait cursors.
        /// </summary>
        public static MouseCursor WaitArrow { get; private set; }

        /// <summary>
        /// Gets the northwest/southeast ("\") cursor.
        /// </summary>
        public static MouseCursor SizeNWSE { get; private set; }

        /// <summary>
        /// Gets the northeast/southwest ("/") cursor.
        /// </summary>
        public static MouseCursor SizeNESW { get; private set; }

        /// <summary>
        /// Gets the horizontal west/east ("-") cursor.
        /// </summary>
        public static MouseCursor SizeWE { get; private set; }

        /// <summary>
        /// Gets the vertical north/south ("|") cursor.
        /// </summary>
        public static MouseCursor SizeNS { get; private set; }

        /// <summary>
        /// Gets the size all cursor which points in all directions.
        /// </summary>
        public static MouseCursor SizeAll { get; private set; }

        /// <summary>
        /// Gets the cursor that points that something is invalid, usually a cross.
        /// </summary>
        public static MouseCursor No { get; private set; }

        /// <summary>
        /// Gets the hand cursor, usually used for web links.
        /// </summary>
        public static MouseCursor Hand { get; private set; }

        /// <summary>
        /// Creates a mouse cursor from the specified texture.
        /// </summary>
        /// <param name="texture">Texture to use as the cursor image.</param>
        /// <param name="originx">X cordinate of the image that will be used for mouse position.</param>
        /// <param name="originy">Y cordinate of the image that will be used for mouse position.</param>
        public static MouseCursor FromTexture2D(Texture2D texture, int originx, int originy)
        {
            if (texture.Format != SurfaceFormat.Color)
                throw new ArgumentException("Only Color textures are accepted for mouse cursors", "texture");

            IntPtr surface = IntPtr.Zero;
            IntPtr handle = IntPtr.Zero;
            try
            {
                var bytes = new byte[texture.Width * texture.Height * 4];
                texture.GetData(bytes);

			    GCHandle gcHandle = GCHandle.Alloc(bytes, GCHandleType.Pinned);
                surface = SDL.SDL_CreateRGBSurfaceFrom(gcHandle.AddrOfPinnedObject(), texture.Width, texture.Height, 32, texture.Width * 4, 0x000000ff, 0x0000FF00, 0x00FF0000, 0xFF000000);
                gcHandle.Free();
                if (surface == IntPtr.Zero)
                    throw new InvalidOperationException("Failed to create surface for mouse cursor: " + SDL.SDL_GetError());

                handle = SDL.SDL_CreateColorCursor(surface, originx, originy);
                if (handle == IntPtr.Zero)
                    throw new InvalidOperationException("Failed to set surface for mouse cursor: " + SDL.SDL_GetError());
            }
            finally
            {
                if (surface != IntPtr.Zero)
                    SDL.SDL_FreeSurface(surface);
            }

            return new MouseCursor(handle);
        }

        public IntPtr Handle { get; private set; }

        private bool _disposed;

        static MouseCursor()
        {
            Arrow = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_ARROW);
            IBeam = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_IBEAM);
            Wait = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_WAIT);
            Crosshair = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_CROSSHAIR);
            WaitArrow = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_WAITARROW);
            SizeNWSE = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENWSE);
            SizeNESW = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENESW);
            SizeWE = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEWE);
            SizeNS = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZENS);
            SizeAll = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_SIZEALL);
            No = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_NO);
            Hand = new MouseCursor(SDL.SDL_SystemCursor.SDL_SYSTEM_CURSOR_HAND);
        }

        private MouseCursor(IntPtr handle)
        {
            Handle = handle;
        }

        public void Dispose()
        {
            if (_disposed)
                return;

            if (Handle == IntPtr.Zero)
                return;

            SDL.SDL_FreeCursor(Handle);
            Handle = IntPtr.Zero;

            _disposed = true;
        }
        private MouseCursor(SDL.SDL_SystemCursor cursor)
        {
            Handle = SDL.SDL_CreateSystemCursor(cursor);
        }
    }
}