// <auto-generated>
// Auto-generated by StoneAPI, do not modify.
// </auto-generated>

namespace Dropbox.Api.Sharing
{
    using sys = System;
    using col = System.Collections.Generic;
    using re = System.Text.RegularExpressions;

    using enc = Dropbox.Api.Stone;

    /// <summary>
    /// <para>Arguments for <see
    /// cref="Dropbox.Api.Sharing.Routes.SharingRoutes.ListReceivedFilesContinueAsync"
    /// />.</para>
    /// </summary>
    public class ListFilesContinueArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<ListFilesContinueArg> Encoder = new ListFilesContinueArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<ListFilesContinueArg> Decoder = new ListFilesContinueArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFilesContinueArg" />
        /// class.</para>
        /// </summary>
        /// <param name="cursor">Cursor in <see
        /// cref="Dropbox.Api.Sharing.ListFilesResult.Cursor" /></param>
        public ListFilesContinueArg(string cursor)
        {
            if (cursor == null)
            {
                throw new sys.ArgumentNullException("cursor");
            }

            this.Cursor = cursor;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="ListFilesContinueArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public ListFilesContinueArg()
        {
        }

        /// <summary>
        /// <para>Cursor in <see cref="Dropbox.Api.Sharing.ListFilesResult.Cursor" /></para>
        /// </summary>
        public string Cursor { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="ListFilesContinueArg" />.</para>
        /// </summary>
        private class ListFilesContinueArgEncoder : enc.StructEncoder<ListFilesContinueArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(ListFilesContinueArg value, enc.IJsonWriter writer)
            {
                WriteProperty("cursor", value.Cursor, writer, enc.StringEncoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="ListFilesContinueArg" />.</para>
        /// </summary>
        private class ListFilesContinueArgDecoder : enc.StructDecoder<ListFilesContinueArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="ListFilesContinueArg" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override ListFilesContinueArg Create()
            {
                return new ListFilesContinueArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(ListFilesContinueArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "cursor":
                        value.Cursor = enc.StringDecoder.Instance.Decode(reader);
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
