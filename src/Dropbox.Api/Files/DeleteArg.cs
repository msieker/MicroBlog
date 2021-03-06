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
    /// <para>The delete arg object</para>
    /// </summary>
    public class DeleteArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<DeleteArg> Encoder = new DeleteArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<DeleteArg> Decoder = new DeleteArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="DeleteArg" /> class.</para>
        /// </summary>
        /// <param name="path">Path in the user's Dropbox to delete.</param>
        public DeleteArg(string path)
        {
            if (path == null)
            {
                throw new sys.ArgumentNullException("path");
            }
            if (!re.Regex.IsMatch(path, @"\A(?:(/(.|[\r\n])*)|(ns:[0-9]+(/.*)?))\z"))
            {
                throw new sys.ArgumentOutOfRangeException("path", @"Value should match pattern '\A(?:(/(.|[\r\n])*)|(ns:[0-9]+(/.*)?))\z'");
            }

            this.Path = path;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="DeleteArg" /> class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public DeleteArg()
        {
        }

        /// <summary>
        /// <para>Path in the user's Dropbox to delete.</para>
        /// </summary>
        public string Path { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="DeleteArg" />.</para>
        /// </summary>
        private class DeleteArgEncoder : enc.StructEncoder<DeleteArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(DeleteArg value, enc.IJsonWriter writer)
            {
                WriteProperty("path", value.Path, writer, enc.StringEncoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="DeleteArg" />.</para>
        /// </summary>
        private class DeleteArgDecoder : enc.StructDecoder<DeleteArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="DeleteArg" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override DeleteArg Create()
            {
                return new DeleteArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(DeleteArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "path":
                        value.Path = enc.StringDecoder.Instance.Decode(reader);
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
