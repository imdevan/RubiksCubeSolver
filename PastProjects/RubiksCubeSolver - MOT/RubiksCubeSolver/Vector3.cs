/*
 * BSD Licence:
 * Copyright (c) 2001, 2002 Ben Houston [ ben@exocortex.org ]
 * Exocortex Technologies [ www.exocortex.org ]
 * All rights reserved.
 *
 * Redistribution and use in source and binary forms, with or without 
 * modification, are permitted provided that the following conditions are met:
 *
 * 1. Redistributions of source code must retain the above copyright notice, 
 * this list of conditions and the following disclaimer.
 * 2. Redistributions in binary form must reproduce the above copyright 
 * notice, this list of conditions and the following disclaimer in the 
 * documentation and/or other materials provided with the distribution.
 * 3. Neither the name of the <ORGANIZATION> nor the names of its contributors
 * may be used to endorse or promote products derived from this software
 * without specific prior written permission.
 *
 * THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS"
 * AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE
 * IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE
 * ARE DISCLAIMED. IN NO EVENT SHALL THE REGENTS OR CONTRIBUTORS BE LIABLE FOR
 * ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL
 * DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR
 * SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER
 * CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT 
 * LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY
 * OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH
 * DAMAGE.
 * 
 * 
 * =========================== CHANGE LOG ===========================
 *  
 * July 30, 2002 Ben Houston (ben@exocortex.org)
 * 
 *	- started change log
 *	- added .Absolute(), .GetAbsolute(), .Distance( Vector3 a, Vector3 b ), 
 *		.SquaredDistance( Vector3 a, Vector3 b ), .CompareTo() methods at
 *		Lee Childs' request. (lrchilds@attbi.com)
 * 
 * July 31, 2002 Ben Houston (ben@exocortex.org)
 * 
 *	- renamed Vector3D -> Vector3 at Lee Childs' request. (lrchilds@attbi.com)
 * 
 * August 11, 2002 Ben Houston (ben@exocortex.org)
 * 
 *	- added Serializable & TYpeConverter attributes as Lee Child's
 *		request (lrchilds@attbi.com).
 *	- replaced .Absolute() and .GetAbsolute() member functions with the
 *		static function .Abs( Vector3 v ) since it seems like
 *		a more logical arrangement (i.e. it mirrors how Math.Abs() works).
 * 
 * 
 * =========================== TO DO LIST ===========================
 * 
 *	- check whether Serializer & TypeConverter attributes work as expected.
 * 
 */


using System;
using System.ComponentModel;			// for TypeConverterAttribute
using System.Diagnostics;				// mostly for Debug.Assert(...)
using System.Runtime.InteropServices;	// for StructLayoutAttribute
using System.Xml.Serialization;			// for various Xml attributes


namespace RubiksCubeSolver 
{

    /// <summary>
    /// Represents a location in 3-space
    /// </summary>
    [XmlType("point3d"), StructLayout(LayoutKind.Sequential),
    Serializable, TypeConverter(typeof(ExpandableObjectConverter))]
    public struct Vector3 : ICloneable, IComparable
    {

        // ================================================================================

        /// <summary>
        /// Creates a new vector set to ( x, y, z )
        /// </summary>
        public Vector3(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Creates a new vector set to ( element[0], element[1], element[2] )
        /// </summary>
        public Vector3(float[] elements)
        {
            Debug.Assert(elements != null);
            Debug.Assert(elements.Length >= 3);
            this.X = elements[0];
            this.Y = elements[1];
            this.Z = elements[2];
        }

        /// <summary>
        /// Creates a new vector set to the values of the given vector
        /// </summary>
        public Vector3(Vector3 vec)
        {
            this.X = vec.X;
            this.Y = vec.Y;
            this.Z = vec.Z;
        }

        // ================================================================================

        /// <summary>
        /// Create a new vector set to ( x, y, z )
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        /// <returns></returns>
        static public Vector3 FromXYZ(float x, float y, float z)
        {
            return new Vector3(x, y, z);
        }

        /// <summary>
        /// Create a new vector set to ( element[0], element[1], element[2] )
        /// </summary>
        /// <param name="elements"></param>
        /// <returns></returns>
        static public Vector3 FromXYZ(float[] elements)
        {
            return new Vector3(elements);
        }

        // ================================================================================

        /// <summary>
        /// Set the X, Y and Z coordinates of the vector at once.
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="z"></param>
        public void Set(float x, float y, float z)
        {
            this.X = x;
            this.Y = y;
            this.Z = z;
        }

        /// <summary>
        /// Set the vector to the same location as the given vector
        /// </summary>
        /// <param name="vec"></param>
        public void Set(Vector3 vec)
        {
            this.X = vec.X;
            this.Y = vec.Y;
            this.Z = vec.Z;
        }

        // ================================================================================

        /// <summary>
        /// this is a private implementation of an Interface
        /// </summary>
        /// <returns></returns>
        object ICloneable.Clone()
        {
            return new Vector3(this);
        }

        /// <summary>
        /// Create a copy of this vector
        /// </summary>
        /// <returns></returns>
        public Vector3 Clone()
        {
            return new Vector3(this);
        }

        /// <summary>
        /// this is a private implementation of an Interface
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        int IComparable.CompareTo(object obj)
        {
            if (obj is Vector3)
            {
                Vector3 vec = (Vector3)obj;
                float magnitudeSelf = this.GetMagnitude();
                float magnitudeOther = vec.GetMagnitude();

                if (magnitudeSelf < magnitudeOther)
                {
                    return -1;
                }
                else if (magnitudeSelf > magnitudeOther)
                {
                    return 1;
                }
                return 0;
            }
            return 0;
        }

        /// <summary>
        /// compares the magnitude of this instance against the 
        /// magnitude of the supplied vector.  
        /// </summary>
        /// <param name="vec">The vector to compare this instance with.</param>
        /// <returns>Less than 0: The magnitude of this instance is less than the magnitude of point.
        /// Zero: The magnitude of this instance equals the magnitude of vector.
        /// Greater than 0: The magnitude of this instance is greater than the magnitude of point.
        /// </returns>
        public int CompareTo(Vector3 vec)
        {
            float magnitudeSelf = this.GetMagnitude();
            float magnitudeOther = vec.GetMagnitude();

            if (magnitudeSelf < magnitudeOther)
            {
                return -1;
            }
            else if (magnitudeSelf > magnitudeOther)
            {
                return 1;
            }
            return 0;
        }

        // ================================================================================

        /// <summary>
        /// The X component of the vector
        /// </summary>
        [XmlAttribute("x")]
        public float X;

        /// <summary>
        /// The Y component of the vector
        /// </summary>
        [XmlAttribute("y")]
        public float Y;

        /// <summary>
        /// The Z component of the vector
        /// </summary>
        [XmlAttribute("z")]
        public float Z;

        /// <summary>
        /// An index accessor that maps [0] -> X, [1] -> Y and [2] -> Z.
        /// </summary>
        public float this[int index]
        {
            get
            {
                Debug.Assert(0 <= index && index <= 2);
                if (index <= 1)
                {
                    if (index == 0)
                    {
                        return this.X;
                    }
                    return this.Y;
                }
                return this.Z;
            }
            set
            {
                Debug.Assert(0 <= index && index <= 2);
                if (index <= 1)
                {
                    if (index == 0)
                    {
                        this.X = value;
                    }
                    else
                    {
                        this.Y = value;
                    }
                }
                else
                {
                    this.Z = value;
                }
            }
        }

        // ================================================================================

        /// <summary>
        /// Get the magnitude of the vector [i.e. Sqrt( X*X + Y*Y + Z*Z ) ]
        /// </summary>
        /// <returns></returns>
        public float GetMagnitude()
        {
            return (float)Math.Sqrt(this.X * this.X + this.Y * this.Y + this.Z * this.Z);
        }

        /// <summary>
        /// Get the squared magnitude of the vector [i.e. ( X*X + Y*Y + Z*Z ) ]
        /// </summary>
        /// <returns></returns>
        public float GetMagnitudeSquared()
        {
            return this.X * this.X + this.Y * this.Y + this.Z * this.Z;
        }

        // ================================================================================

        /// <summary>
        /// Get the absolute value (which is not it's magnitude!) of a vector.
        /// </summary>
        /// <param name="v"></param>
        /// <returns></returns>
        static public Vector3 Abs(Vector3 v)
        {
            return new Vector3(Math.Abs(v.X), Math.Abs(v.Y), Math.Abs(v.Z));
        }

        // ================================================================================



        /// <summary>
        /// Get the vector's unit vector.
        /// </summary>
        /// <returns></returns>
        public Vector3 GetUnit()
        {
            Vector3 vec = new Vector3(this);
            vec.Normalize();
            return vec;
        }

        /// <summary>
        /// Scale point so that the magnitude is one
        /// </summary>
        public void Normalize()
        {
            float magnitude = GetMagnitude();
            if (magnitude == 0)
            {
                throw new DivideByZeroException("Can not normalize a vector when it's magnitude is zero.");
            }
            float inv = 1 / magnitude;
            this.X *= inv;
            this.Y *= inv;
            this.Z *= inv;
        }

        // ================================================================================

        /// <summary>
        /// Convert the point into the array 'new float[]{ X, Y, Z }'.  Note that this
        /// function causes a new float[] array to be allocated with each call.  Thus it 
        /// is somewhat inefficient.
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        static public explicit operator float[](Vector3 vec)
        {
            float[] elements = new float[3];
            elements[0] = vec.X;
            elements[1] = vec.Y;
            elements[2] = vec.Z;
            return elements;
        }

        // ================================================================================

        /// <summary>
        /// A human understandable descrivecion of the point.
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return string.Format("( x={0}, y={1}, z={2} )", X, Y, Z);
        }

        // ================================================================================

        /// <summary>
        /// Are two points equal?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public bool operator ==(Vector3 a, Vector3 b)
        {
            return (a.X == b.X) && (a.Y == b.Y) && (a.Z == b.Z);
        }

        /// <summary>
        /// Are two point not equal?
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public bool operator !=(Vector3 a, Vector3 b)
        {
            return (a.X != b.X) || (a.Y != b.Y) || (a.Z != b.Z);
        }

        /// <summary>
        /// Is given object equal to current point?
        /// </summary>
        /// <param name="o"></param>
        /// <returns></returns>
        public override bool Equals(object o)
        {
            if (o is Vector3)
            {
                Vector3 vec = (Vector3)o;
                return (this.X == vec.X) && (this.Y == vec.Y) && (this.Z == vec.Z);
            }
            return false;
        }

        /// <summary>
        /// Get the hashcode of the point
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return this.X.GetHashCode() ^ (this.Y.GetHashCode() ^ (~this.Z.GetHashCode()));
        }

        // ================================================================================

        /// <summary>
        /// Do nothing.
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        static public Vector3 operator +(Vector3 vec)
        {
            return Vector3.FromXYZ(+vec.X, +vec.Y, +vec.Z);
        }

        /// <summary>
        /// Invert the direction of the point.  Result is ( -vec.X, -vec.Y, -vec.Z ).
        /// </summary>
        /// <param name="vec"></param>
        /// <returns></returns>
        static public Vector3 operator -(Vector3 vec)
        {
            return Vector3.FromXYZ(-vec.X, -vec.Y, -vec.Z);
        }

        /// <summary>
        /// Multiply vector vec by f.  Result is ( vec.X*f, vec.Y*f, vec.Z*f ).
        /// </summary>
        /// <param name="scale"></param>
        /// <param name="vec"></param>
        /// <returns></returns>
        static public Vector3 operator *(float scale, Vector3 vec)
        {
            return new Vector3(vec.X * scale, vec.Y * scale, vec.Z * scale);
        }

        /// <summary>
        /// Multiply vector vec by f.  Result is ( vec.X*f, vec.Y*f, vec.Z*f ).
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="scale"></param>
        /// <returns></returns>
        static public Vector3 operator *(Vector3 vec, float scale)
        {
            return new Vector3(vec.X * scale, vec.Y * scale, vec.Z * scale);
        }

        /// <summary>
        /// Divide vector vec by f.  Result is ( vec.X/f, vec.Y/f, vec.Z/f ).
        /// </summary>
        /// <param name="vec"></param>
        /// <param name="divisor"></param>
        /// <returns></returns>
        static public Vector3 operator /(Vector3 vec, float divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("can not divide a vector by zero");
            }
            float inv = 1 / divisor;
            return new Vector3(vec.X * inv, vec.Y * inv, vec.Z * inv);
        }

        /// <summary>
        /// Add two vectors.  Result is ( a.X + b.X, a.Y + b.Y, a.Z + b.Z )
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 operator +(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X + b.X, a.Y + b.Y, a.Z + b.Z);
        }

        /// <summary>
        /// Subtract two vectors.  Result is ( a.X - b.X, a.Y - b.Y, a.Z - b.Z )
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 operator -(Vector3 a, Vector3 b)
        {
            return new Vector3(a.X - b.X, a.Y - b.Y, a.Z - b.Z);
        }

        // ================================================================================

        /// <summary>
        /// Invert the direction of the vector.
        /// </summary>
        public void Invert()
        {
            this.X = -this.X;
            this.Y = -this.Y;
            this.Z = -this.Z;
        }

        /// <summary>
        /// Add 'vec' to self.  Much quicker than using '+' operator since no new objects are created.
        /// </summary>
        /// <param name="vec"></param>
        public void Add(Vector3 vec)
        {
            this.X += vec.X;
            this.Y += vec.Y;
            this.Z += vec.Z;
        }

        /// <summary>
        /// Subtract 'vec' from self.  Much quicker than using '-' operator since no new objects are created.
        /// </summary>
        /// <param name="vec"></param>
        public void Subtract(Vector3 vec)
        {
            this.X -= vec.X;
            this.Y -= vec.Y;
            this.Z -= vec.Z;
        }

        /// <summary>
        /// Multiply self by 'scale'.  Much quicker than using '*' operator since no new objects are created.
        /// </summary>
        /// <param name="scale"></param>
        public void Multiply(float scale)
        {
            this.X *= scale;
            this.Y *= scale;
            this.Z *= scale;
        }

        /// <summary>
        /// Divide self by 'divisor'.  Much quicker than using '/' operator since no new objects are created.
        /// </summary>
        /// <param name="divisor"></param>
        public void Divide(float divisor)
        {
            if (divisor == 0)
            {
                throw new DivideByZeroException("can not divide a vector by zero");
            }
            float inv = 1 / divisor;
            this.X *= inv;
            this.Y *= inv;
            this.Z *= inv;
        }

        // ================================================================================

        /// <summary>
        /// Get the vector with the shortest magnitude
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 Min(Vector3 a, Vector3 b)
        {
            return (a.GetMagnitude() >= b.GetMagnitude()) ? b : a;
        }

        /// <summary>
        /// Get the vector with the greatest magnitude
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 Max(Vector3 a, Vector3 b)
        {
            return (a.GetMagnitude() >= b.GetMagnitude()) ? a : b;
        }

        /// <summary>
        /// Get the smallest of each of the components in vector a and vector b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 MinXYZ(Vector3 a, Vector3 b)
        {
            return new Vector3(
                Math.Min(a.X, b.X),
                Math.Min(a.Y, b.Y),
                Math.Min(a.Z, b.Z));
        }

        /// <summary>
        /// Get the greatest of each of the components in vector a and vector b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 MaxXYZ(Vector3 a, Vector3 b)
        {
            return new Vector3(
                Math.Max(a.X, b.X),
                Math.Max(a.Y, b.Y),
                Math.Max(a.Z, b.Z));
        }

        // ================================================================================

        /// <summary>
        /// Calculate the distance between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public float Distance(Vector3 a, Vector3 b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            float dz = a.Z - b.Z;
            return (float)Math.Sqrt(dx * dx + dy * dy + dz * dz);
        }

        /// <summary>
        /// Calculate the squared distance between two points
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public float DistanceSquared(Vector3 a, Vector3 b)
        {
            float dx = a.X - b.X;
            float dy = a.Y - b.Y;
            float dz = a.Z - b.Z;
            return (dx * dx + dy * dy + dz * dz);
        }

        // ================================================================================

        /// <summary>
        /// Calculate the dot project (i.e. inner product) of a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public float Dot(Vector3 a, Vector3 b)
        {
            return DotProduct(a, b);
        }

        /// <summary>
        /// Calculate the dot project (i.e. inner product) of a and b.
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public float DotProduct(Vector3 a, Vector3 b)
        {
            // make it easier to see what is happening
            float x0 = a.X, y0 = a.Y, z0 = a.Z;
            float x1 = b.X, y1 = b.Y, z1 = b.Z;
            return x0 * x1 + y0 * y1 + z0 * z1;
        }

        /// <summary>
        /// Calculate the cross product (i.e. outer product) of a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 Cross(Vector3 a, Vector3 b)
        {
            return CrossProduct(a, b);
        }

        /// <summary>
        /// Calculate the cross product (i.e. outer product) of a and b
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <returns></returns>
        static public Vector3 CrossProduct(Vector3 a, Vector3 b)
        {
            // make it easier to see what is happening
            float x0 = a.X, y0 = a.Y, z0 = a.Z;
            float x1 = b.X, y1 = b.Y, z1 = b.Z;
            return Vector3.FromXYZ(y0 * z1 - z0 * y1, z0 * x1 - x0 * z1, x0 * y1 - y0 * x1);
        }

        // ================================================================================

        /// <summary>
        /// Determine whether sequency a-b-c is Clockwise, Counterclockwise or Collinear
        /// </summary>
        /// <param name="a"></param>
        /// <param name="b"></param>
        /// <param name="c"></param>
        /// <returns></returns> 
        static public int Orientation(Vector3 a, Vector3 b, Vector3 c)
        {
            float length = Vector3.CrossProduct(b - a, b - c).GetMagnitude();
            if (length > 0)
            {
                return 1;
            }
            if (length < 0)
            {
                return -1;
            }
            if (length == 0)
            {
                return 0;
            }
            Debug.Fail("should never get here");
            return 0;
        }

        // interpolate between two points
        /*static public	Vector3	Interpolate( Vector3 a, Vector3 b, float f ) {
            Debug.Assert( f >= 0 );
            Debug.Assert( f <= 1 );
            float alpha = 1 - f;
            float beta = f;
            return Vector3.FromXYZ(
                a.X * alpha + b.X * beta, 
                a.Y * alpha + b.Y * beta, 
                a.Z * alpha + b.Z * beta );
        }  */

        // ================================================================================

        /// <summary>
        /// Zero (0,0,0)
        /// </summary>
        static public readonly Vector3 Zero = new Vector3(0, 0, 0);

        /// <summary>
        /// Origin (0,0,0)
        /// </summary>
        static public readonly Vector3 Origin = new Vector3(0, 0, 0);

        /// <summary>
        /// X-axis unit vector (1,0,0)
        /// </summary>
        static public readonly Vector3 XAxis = new Vector3(1, 0, 0);

        /// <summary>
        /// Y-axis unit vector (0,1,0)
        /// </summary>
        static public readonly Vector3 YAxis = new Vector3(0, 1, 0);

        /// <summary>
        /// Z-axis unit vector (0,0,1)
        /// </summary>
        static public readonly Vector3 ZAxis = new Vector3(0, 0, 1);

        // ================================================================================

    }

    // ================================================================================
    // ================================================================================

}
