using System.Runtime.InteropServices;

namespace Microsoft.Xna.Framework.Graphics
{
	[StructLayout(LayoutKind.Sequential, Pack = 1)]
	public struct VertexSdfShape : IVertexType
	{
		public VertexSdfShape(Vector3 position, Vector2 textureCoordinate, float shape, Color c1, Color c2, float thickness = 0f, float pixelSize = 1f, float width = 1.0f, float x = 0f)
		{
			if (thickness <= 0f)
			{
				c2 = c1;
				thickness = 0f;
			}

			Position = position;
			TextureCoordinate = textureCoordinate;
			Color1 = c1;
			Color2 = c2;

			Meta1 = new Vector4(thickness, shape, pixelSize, width);
			Meta2 = new Vector4(x, 0f, 0f, 0f);
		}

		public Vector3 Position;
		public Vector2 TextureCoordinate;
		public Color Color1;
		public Color Color2;
		public Vector4 Meta1;
		public Vector4 Meta2;
		public static readonly VertexDeclaration VertexDeclaration;

		VertexDeclaration IVertexType.VertexDeclaration => VertexDeclaration;

		public override int GetHashCode()
		{
			unchecked
			{
				var hashCode = Position.GetHashCode();
				hashCode = (hashCode * 397) ^ TextureCoordinate.GetHashCode();
				hashCode = (hashCode * 397) ^ Color1.GetHashCode();
				hashCode = (hashCode * 397) ^ Color2.GetHashCode();
				hashCode = (hashCode * 397) ^ Meta1.GetHashCode();
				return hashCode;
			}
		}

		public override string ToString()
		{
			return
				"{{Position:" + this.Position +
				" Color1:" + this.Color1 +
				" Color2:" + this.Color1 +
				" TextureCoordinate:" + this.TextureCoordinate +
				" Thickness:" + this.Meta1.X +
				" Shape:" + this.Meta1.Y +
				" PixelSize:" + this.Meta1.Z +
				" Width:" + this.Meta1.W +
				"}}";
		}

		public static bool operator ==(VertexSdfShape left, VertexSdfShape right)
		{
			return
				left.Position == right.Position &&
				left.TextureCoordinate == right.TextureCoordinate &&
				left.Color1 == right.Color1 &&
				left.Color2 == right.Color2 &&
				left.Meta1 == right.Meta1 &&
				left.Meta2 == right.Meta2;
		}

		public static bool operator !=(VertexSdfShape left, VertexSdfShape right)
		{
			return !(left == right);
		}

		public override bool Equals(object obj)
		{
			if (obj == null)
				return false;

			if (obj.GetType() != base.GetType())
				return false;

			return (this == ((VertexSdfShape)obj));
		}

		static VertexSdfShape()
		{
			var elements = new VertexElement[] {
				new VertexElement(0, VertexElementFormat.Vector3, VertexElementUsage.Position, 0),
				new VertexElement(sizeof(float) * 3, VertexElementFormat.Vector2, VertexElementUsage.TextureCoordinate, 0),
				new VertexElement(sizeof(float) * 5, VertexElementFormat.Color, VertexElementUsage.Color, 0),
				new VertexElement(sizeof(float) * 5 + sizeof(int), VertexElementFormat.Color, VertexElementUsage.Color, 1),
				new VertexElement(sizeof(float) * 5 + sizeof(int) * 2, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 1),
				new VertexElement(sizeof(float) * 9 + sizeof(int) * 2, VertexElementFormat.Vector4, VertexElementUsage.TextureCoordinate, 2)
			};
			VertexDeclaration = new VertexDeclaration(elements);
		}
	}
}
