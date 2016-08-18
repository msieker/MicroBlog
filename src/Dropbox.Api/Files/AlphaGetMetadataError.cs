// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Files
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>The alpha get metadata error object</para>
    /// </summary>
    public class AlphaGetMetadataError
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<AlphaGetMetadataError> Encoder = new AlphaGetMetadataErrorEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<AlphaGetMetadataError> Decoder = new AlphaGetMetadataErrorDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AlphaGetMetadataError" />
        /// class.</para>
        /// </summary>
        public AlphaGetMetadataError()
        {
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is PropertiesError</para>
        /// </summary>
        public bool IsPropertiesError
        {
            get
            {
                return this is PropertiesError;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a PropertiesError, or <c>null</c>.</para>
        /// </summary>
        public PropertiesError AsPropertiesError
        {
            get
            {
                return this as PropertiesError;
            }
        }

        /// <summary>
        /// <para>Gets a value indicating whether this instance is Path</para>
        /// </summary>
        public bool IsPath
        {
            get
            {
                return this is Path;
            }
        }

        /// <summary>
        /// <para>Gets this instance as a Path, or <c>null</c>.</para>
        /// </summary>
        public Path AsPath
        {
            get
            {
                return this as Path;
            }
        }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="AlphaGetMetadataError" />.</para>
        /// </summary>
        private class AlphaGetMetadataErrorEncoder : enc.StructEncoder<AlphaGetMetadataError>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(AlphaGetMetadataError value, enc.IJsonWriter writer)
            {
                if (value is PropertiesError)
                {
                    WriteProperty(".tag", "properties_error", writer, enc.StringEncoder.Instance);
                    PropertiesError.Encoder.EncodeFields((PropertiesError)value, writer);
                    return;
                }
                if (value is Path)
                {
                    WriteProperty(".tag", "path", writer, enc.StringEncoder.Instance);
                    Path.Encoder.EncodeFields((Path)value, writer);
                    return;
                }
                throw new sys.InvalidOperationException();
            }
        }

        #endregion

        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="AlphaGetMetadataError" />.</para>
        /// </summary>
        private class AlphaGetMetadataErrorDecoder : enc.UnionDecoder<AlphaGetMetadataError>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="AlphaGetMetadataError"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override AlphaGetMetadataError Create()
            {
                return new AlphaGetMetadataError();
            }

            /// <summary>
            /// <para>Decode based on given tag.</para>
            /// </summary>
            /// <param name="tag">The tag.</param>
            /// <param name="reader">The json reader.</param>
            /// <returns>The decoded object.</returns>
            protected override AlphaGetMetadataError Decode(string tag, enc.IJsonReader reader)
            {
                switch (tag)
                {
                    case "properties_error":
                        return PropertiesError.Decoder.DecodeFields(reader);
                    case "path":
                        return Path.Decoder.DecodeFields(reader);
                    default:
                        throw new sys.InvalidOperationException();
                }
            }
        }

        #endregion

        /// <summary>
        /// <para>The properties error object</para>
        /// </summary>
        public sealed class PropertiesError : AlphaGetMetadataError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<PropertiesError> Encoder = new PropertiesErrorEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<PropertiesError> Decoder = new PropertiesErrorDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="PropertiesError" />
            /// class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public PropertiesError(LookUpPropertiesError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="PropertiesError" />
            /// class.</para>
            /// </summary>
            private PropertiesError()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public LookUpPropertiesError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="PropertiesError" />.</para>
            /// </summary>
            private class PropertiesErrorEncoder : enc.StructEncoder<PropertiesError>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(PropertiesError value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Files.LookUpPropertiesError.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="PropertiesError" />.</para>
            /// </summary>
            private class PropertiesErrorDecoder : enc.StructDecoder<PropertiesError>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="PropertiesError" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override PropertiesError Create()
                {
                    return new PropertiesError();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(PropertiesError value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "properties_error":
                            value.Value = Dropbox.Api.Files.LookUpPropertiesError.Decoder.Decode(reader);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            #endregion
        }

        /// <summary>
        /// <para>The path object</para>
        /// </summary>
        public sealed class Path : AlphaGetMetadataError
        {
            #pragma warning disable 108

            /// <summary>
            /// <para>The encoder instance.</para>
            /// </summary>
            internal static enc.StructEncoder<Path> Encoder = new PathEncoder();

            /// <summary>
            /// <para>The decoder instance.</para>
            /// </summary>
            internal static enc.StructDecoder<Path> Decoder = new PathDecoder();

            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Path" /> class.</para>
            /// </summary>
            /// <param name="value">The value</param>
            public Path(LookupError value)
            {
                this.Value = value;
            }
            /// <summary>
            /// <para>Initializes a new instance of the <see cref="Path" /> class.</para>
            /// </summary>
            private Path()
            {
            }

            /// <summary>
            /// <para>Gets the value of this instance.</para>
            /// </summary>
            public LookupError Value { get; private set; }

            #region Encoder class

            /// <summary>
            /// <para>Encoder for  <see cref="Path" />.</para>
            /// </summary>
            private class PathEncoder : enc.StructEncoder<Path>
            {
                /// <summary>
                /// <para>Encode fields of given value.</para>
                /// </summary>
                /// <param name="value">The value.</param>
                /// <param name="writer">The writer.</param>
                public override void EncodeFields(Path value, enc.IJsonWriter writer)
                {
                    Dropbox.Api.Files.LookupError.Encoder.EncodeFields(value.Value, writer);
                }
            }

            #endregion

            #region Decoder class

            /// <summary>
            /// <para>Decoder for  <see cref="Path" />.</para>
            /// </summary>
            private class PathDecoder : enc.StructDecoder<Path>
            {
                /// <summary>
                /// <para>Create a new instance of type <see cref="Path" />.</para>
                /// </summary>
                /// <returns>The struct instance.</returns>
                protected override Path Create()
                {
                    return new Path();
                }

                /// <summary>
                /// <para>Set given field.</para>
                /// </summary>
                /// <param name="value">The field value.</param>
                /// <param name="fieldName">The field name.</param>
                /// <param name="reader">The json reader.</param>
                protected override void SetField(Path value, string fieldName, enc.IJsonReader reader)
                {
                    switch (fieldName)
                    {
                        case "path":
                            value.Value = Dropbox.Api.Files.LookupError.Decoder.Decode(reader);
                            break;
                        default:
                            reader.Skip();
                            break;
                    }
                }
            }

            #endregion
        }
    }
}
