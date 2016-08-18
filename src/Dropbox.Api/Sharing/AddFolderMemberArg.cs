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
    /// <para>The add folder member arg object</para>
    /// </summary>
    public class AddFolderMemberArg
    {
        #pragma warning disable 108

        /// <summary>
        /// <para>The encoder instance.</para>
        /// </summary>
        internal static enc.StructEncoder<AddFolderMemberArg> Encoder = new AddFolderMemberArgEncoder();

        /// <summary>
        /// <para>The decoder instance.</para>
        /// </summary>
        internal static enc.StructDecoder<AddFolderMemberArg> Decoder = new AddFolderMemberArgDecoder();

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AddFolderMemberArg" />
        /// class.</para>
        /// </summary>
        /// <param name="sharedFolderId">The ID for the shared folder.</param>
        /// <param name="members">The intended list of members to add.  Added members will
        /// receive invites to join the shared folder.</param>
        /// <param name="quiet">Whether added members should be notified via email and device
        /// notifications of their invite.</param>
        /// <param name="customMessage">Optional message to display to added members in their
        /// invitation.</param>
        public AddFolderMemberArg(string sharedFolderId,
                                  col.IEnumerable<AddMember> members,
                                  bool quiet = false,
                                  string customMessage = null)
        {
            if (sharedFolderId == null)
            {
                throw new sys.ArgumentNullException("sharedFolderId");
            }
            if (!re.Regex.IsMatch(sharedFolderId, @"\A(?:[-_0-9a-zA-Z:]+)\z"))
            {
                throw new sys.ArgumentOutOfRangeException("sharedFolderId", @"Value should match pattern '\A(?:[-_0-9a-zA-Z:]+)\z'");
            }

            var membersList = enc.Util.ToList(members);

            if (members == null)
            {
                throw new sys.ArgumentNullException("members");
            }

            if (customMessage != null)
            {
                if (customMessage.Length < 1)
                {
                    throw new sys.ArgumentOutOfRangeException("customMessage", "Length should be at least 1");
                }
            }

            this.SharedFolderId = sharedFolderId;
            this.Members = membersList;
            this.Quiet = quiet;
            this.CustomMessage = customMessage;
        }

        /// <summary>
        /// <para>Initializes a new instance of the <see cref="AddFolderMemberArg" />
        /// class.</para>
        /// </summary>
        /// <remarks>This is to construct an instance of the object when
        /// deserializing.</remarks>
        public AddFolderMemberArg()
        {
            this.Quiet = false;
        }

        /// <summary>
        /// <para>The ID for the shared folder.</para>
        /// </summary>
        public string SharedFolderId { get; protected set; }

        /// <summary>
        /// <para>The intended list of members to add.  Added members will receive invites to
        /// join the shared folder.</para>
        /// </summary>
        public col.IList<AddMember> Members { get; protected set; }

        /// <summary>
        /// <para>Whether added members should be notified via email and device notifications
        /// of their invite.</para>
        /// </summary>
        public bool Quiet { get; protected set; }

        /// <summary>
        /// <para>Optional message to display to added members in their invitation.</para>
        /// </summary>
        public string CustomMessage { get; protected set; }

        #region Encoder class

        /// <summary>
        /// <para>Encoder for  <see cref="AddFolderMemberArg" />.</para>
        /// </summary>
        private class AddFolderMemberArgEncoder : enc.StructEncoder<AddFolderMemberArg>
        {
            /// <summary>
            /// <para>Encode fields of given value.</para>
            /// </summary>
            /// <param name="value">The value.</param>
            /// <param name="writer">The writer.</param>
            public override void EncodeFields(AddFolderMemberArg value, enc.IJsonWriter writer)
            {
                WriteProperty("shared_folder_id", value.SharedFolderId, writer, enc.StringEncoder.Instance);
                WriteListProperty("members", value.Members, writer, Dropbox.Api.Sharing.AddMember.Encoder);
                WriteProperty("quiet", value.Quiet, writer, enc.BooleanEncoder.Instance);
                if (value.CustomMessage != null)
                {
                    WriteProperty("custom_message", value.CustomMessage, writer, enc.StringEncoder.Instance);
                }
            }
        }

        #endregion


        #region Decoder class

        /// <summary>
        /// <para>Decoder for  <see cref="AddFolderMemberArg" />.</para>
        /// </summary>
        private class AddFolderMemberArgDecoder : enc.StructDecoder<AddFolderMemberArg>
        {
            /// <summary>
            /// <para>Create a new instance of type <see cref="AddFolderMemberArg" />.</para>
            /// </summary>
            /// <returns>The struct instance.</returns>
            protected override AddFolderMemberArg Create()
            {
                return new AddFolderMemberArg();
            }

            /// <summary>
            /// <para>Set given field.</para>
            /// </summary>
            /// <param name="value">The field value.</param>
            /// <param name="fieldName">The field name.</param>
            /// <param name="reader">The json reader.</param>
            protected override void SetField(AddFolderMemberArg value, string fieldName, enc.IJsonReader reader)
            {
                switch (fieldName)
                {
                    case "shared_folder_id":
                        value.SharedFolderId = enc.StringDecoder.Instance.Decode(reader);
                        break;
                    case "members":
                        value.Members = ReadList<AddMember>(reader, Dropbox.Api.Sharing.AddMember.Decoder);
                        break;
                    case "quiet":
                        value.Quiet = enc.BooleanDecoder.Instance.Decode(reader);
                        break;
                    case "custom_message":
                        value.CustomMessage = enc.StringDecoder.Instance.Decode(reader);
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
