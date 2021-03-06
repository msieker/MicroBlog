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
    /// <para>The get shared link metadata arg object</para>
    /// </summary>
    public class GetSharedLinkMetadataArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<GetSharedLinkMetadataArg> Encoder = new GetSharedLinkMetadataArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<GetSharedLinkMetadataArg> Decoder = new GetSharedLinkMetadataArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GetSharedLinkMetadataArg" />
        /// class.</para>
        /// </summary>
        /// <param name="url">URL of the shared link.</param>
        /// <param name="path">If the shared link is to a folder, this parameter can be used to
        /// retrieve the metadata for a specific file or sub-folder in this folder. A relative
        /// path should be used.</param>
        /// <param name="linkPassword">If the shared link has a password, this parameter can be
        /// used.</param>
        public GetSharedLinkMetadataArg(string url,
                                        string path = null,
                                        string linkPassword = null)
        {
            if (url == null)
            {
                throw new sys.ArgumentNullException("url");
            }

            if (path != null)
            {
                if (!re.Regex.IsMatch(path, @"\A(?:/(.|[\r\n])*)\z"))
                {
                    throw new sys.ArgumentOutOfRangeException("path", @"Value should match pattern '\A(?:/(.|[\r\n])*)\z'");
                }
            }

            this.Url = url;
            this.Path = path;
            this.LinkPassword = linkPassword;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="GetSharedLinkMetadataArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public GetSharedLinkMetadataArg()
        {
        }

        /// <summary>
        /// <para>URL of the shared link.</para>
        /// </summary>
        public string Url { get; protected set; }

        /// <summary>
        /// <para>If the shared link is to a folder, this parameter can be used to retrieve the
        /// metadata for a specific file or sub-folder in this folder. A relative path should
        /// be used.</para>
        /// </summary>
        public string Path { get; protected set; }

        /// <summary>
        /// <para>If the shared link has a password, this parameter can be used.</para>
        /// </summary>
        public string LinkPassword { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="GetSharedLinkMetadataArg" />.</para>
        /// </summary>
        private class GetSharedLinkMetadataArgEncoder : enc.StructEncoder<GetSharedLinkMetadataArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(GetSharedLinkMetadataArg value, enc.IJsonWriter writer)
            {
                WriteProperty("url", value.Url, writer, enc.StringEncoder.Instance);
                if (value.Path != null)
                {
                    WriteProperty("path", value.Path, writer, enc.StringEncoder.Instance);
                }
                if (value.LinkPassword != null)
                {
                    WriteProperty("link_password", value.LinkPassword, writer, enc.StringEncoder.Instance);
                }
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="GetSharedLinkMetadataArg" />.</para>
        /// </summary>
        private class GetSharedLinkMetadataArgDecoder : enc.StructDecoder<GetSharedLinkMetadataArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="GetSharedLinkMetadataArg"
            /// />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override GetSharedLinkMetadataArg Create()
            {
                return new GetSharedLinkMetadataArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(GetSharedLinkMetadataArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "url":
                        value.Url = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "path":
                        value.Path = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "link_password":
                        value.LinkPassword = enc.StringDecoder.Instance.Decode(reader);
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
