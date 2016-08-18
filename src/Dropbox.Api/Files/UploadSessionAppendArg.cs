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
    /// <para>The upload session append arg object</para>
    /// </summary>
    public class UploadSessionAppendArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<UploadSessionAppendArg> Encoder = new UploadSessionAppendArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<UploadSessionAppendArg> Decoder = new UploadSessionAppendArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="UploadSessionAppendArg" />
        /// class.</para>
        /// </summary>
        /// <param name="cursor">Contains the upload session ID and the offset.</param>
        /// <param name="close">If true, the current session will be closed, at which point you
        /// won't be able to call <see
        /// cref="Dropbox.Api.Files.Routes.FilesRoutes.UploadSessionAppendV2Async" /> anymore
        /// with the current session.</param>
        public UploadSessionAppendArg(UploadSessionCursor cursor,
                                      bool close = false)
        {
            if (cursor == null)
            {
                throw new sys.ArgumentNullException("cursor");
            }

            this.Cursor = cursor;
            this.Close = close;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="UploadSessionAppendArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public UploadSessionAppendArg()
        {
            this.Close = false;
        }

        /// <summary>
        /// <para>Contains the upload session ID and the offset.</para>
        /// </summary>
        public UploadSessionCursor Cursor { get; protected set; }

        /// <summary>
        /// <para>If true, the current session will be closed, at which point you won't be able
        /// to call <see cref="Dropbox.Api.Files.Routes.FilesRoutes.UploadSessionAppendV2Async"
        /// /> anymore with the current session.</para>
        /// </summary>
        public bool Close { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="UploadSessionAppendArg" />.</para>
        /// </summary>
        private class UploadSessionAppendArgEncoder : enc.StructEncoder<UploadSessionAppendArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(UploadSessionAppendArg value, enc.IJsonWriter writer)
            {
                WriteProperty("cursor", value.Cursor, writer, Dropbox.Api.Files.UploadSessionCursor.Encoder);
                WriteProperty("close", value.Close, writer, enc.BooleanEncoder.Instance);
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="UploadSessionAppendArg" />.</para>
        /// </summary>
        private class UploadSessionAppendArgDecoder : enc.StructDecoder<UploadSessionAppendArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="UploadSessionAppendArg"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override UploadSessionAppendArg Create()
            {
                return new UploadSessionAppendArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(UploadSessionAppendArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "cursor":
                        value.Cursor = Dropbox.Api.Files.UploadSessionCursor.Decoder.Decode(reader);
                        break;
                    case "close":
                        value.Close = enc.BooleanDecoder.Instance.Decode(reader);
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
